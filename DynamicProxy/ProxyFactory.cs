namespace DynamicProxy
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using ImpromptuInterface;


    internal static class BinderExtensions
    {
        public static IList<Type> GetTypeArguments(this InvokeMemberBinder binder)
        {
            return Impromptu.InvokeGet(binder, "Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder.TypeArguments") as IList<Type>;
        }
    }

    /// <summary>
    /// Contains extension methods for the <see cref="Expression"/> type.
    /// </summary>
    internal static class ExpressionExtensions
    {
        /// <summary>
        /// Retrieves the member that an expression is defined for.
        /// </summary>
        /// <param name="expression">The expression to retreive the member from.</param>
        /// <returns>A <see cref="MemberInfo"/> instance if the member could be found; otherwise <see langword="null"/>.</returns>
        internal static MemberInfo GetTargetMemberInfo(this Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Convert:
                    return GetTargetMemberInfo(((UnaryExpression)expression).Operand);
                case ExpressionType.Lambda:
                    return GetTargetMemberInfo(((LambdaExpression)expression).Body);
                case ExpressionType.Call:
                    return ((MethodCallExpression)expression).Method;
                case ExpressionType.MemberAccess:
                    return ((MemberExpression)expression).Member;
                default:
                    return null;
            }
        }

        internal static MethodCallExpression GetTargetMethodCall(this Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Convert:
                    return GetTargetMethodCall(((UnaryExpression)expression).Operand);
                case ExpressionType.Lambda:
                    return GetTargetMethodCall(((LambdaExpression)expression).Body);
                case ExpressionType.Call:
                    return ((MethodCallExpression)expression);
                default:
                    return null;
            }
        }
    }

    public partial class ProxyFactory<T> : DynamicObject, IProxy<T>
    {
        private readonly T _wrappedObject;
        private readonly Type _wrappedObjectType;
        
        private readonly Func<object, object> _identity = x => x; 

        private readonly Dictionary<string, PropertyInfo> _properties;
        private readonly Dictionary<Tuple<string, bool, int>, MethodInfo> _publicMethods;
        private readonly Dictionary<Tuple<string, bool>, Delegate> _interceptors = new Dictionary<Tuple<string, bool>, Delegate>();
        private readonly Dictionary<Tuple<string, Direction>, Delegate> _propertyInterceptors = new Dictionary<Tuple<string, Direction>, Delegate>();
        private readonly Dictionary<Tuple<string, bool>, Delegate> _outTransformers = new Dictionary<Tuple<string, bool>, Delegate>();
        private readonly Dictionary<string, Tuple<int, Delegate>> _inTransformers = new Dictionary<string, Tuple<int, Delegate>>();

        public static T1 Proxy<T1>(T obj) where T1 : class
        {
            if (!typeof(T1).IsInterface)
                throw new ArgumentException("T1 must be an Interface");
            
            return new ProxyFactory<T>(obj).ActLike<T1>(typeof(IProxy<T>));
        }

        private ProxyFactory(T obj)
        {
            _wrappedObject = obj;
            _wrappedObjectType = typeof(T);
            _properties = _wrappedObjectType.GetProperties().ToDictionary(p => p.Name, p => p);
            _publicMethods =
                _wrappedObjectType.GetMethods()
                    .Where(m => !m.IsSpecialName) //exclude property functions, more maybe needed here.
                    .Where(m => m.IsPublic)
                    .Where(m => m.DeclaringType == _wrappedObjectType)
                    .ToDictionary(m => Tuple.Create(m.Name, m.IsGenericMethod, m.GetParameters().Length), p => p);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var selectorTuple = Tuple.Create(binder.Name, Direction.Out);

            var outTransformer = _outTransformers.ContainsKey(Tuple.Create(binder.Name, false))
                ? _outTransformers[Tuple.Create(binder.Name, false)]
                : _identity;

            var interceptor = _propertyInterceptors.ContainsKey(selectorTuple)
                ? _propertyInterceptors[selectorTuple]
                : null;

            var property = _properties[binder.Name];

            object partialResult;

            if (interceptor != null)
            {
                Func<object, object> meth = property.GetValue;
                partialResult = interceptor.FastDynamicInvoke(new object[] { meth, new object [] {} });
            }
            else
            {
                partialResult = property.GetValue(_wrappedObject);
            }

            result = outTransformer.FastDynamicInvoke(partialResult);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var selectorTuple = Tuple.Create(binder.Name, Direction.In);
            var property = _properties[binder.Name];
            
            var inTransformer = _inTransformers.ContainsKey(binder.Name) ? _inTransformers[binder.Name].Item2 : _identity;
            var interceptor = _propertyInterceptors.ContainsKey(selectorTuple) ? _propertyInterceptors[selectorTuple] : null;
            var transformedValue = inTransformer.FastDynamicInvoke(value);

            if (interceptor != null)
            {
                Action<object, object> meth = property.SetValue;
                Func<object, Action<object>> curry = Impromptu.Curry(meth);
                Func<object[], object> curriedMethod = args =>
                {
                    curry(_wrappedObject)(args[0]);
                    return null;
                };
                interceptor.FastDynamicInvoke(new object [] { curriedMethod, new [] { transformedValue } });
            }
            else
            {
                property.SetValue(_wrappedObject, transformedValue);
            }

            return true;
        }
        
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Delegate outTransformer;
            MethodInfo method;
            Delegate interceptor;
            Tuple<int, Delegate> inTransformer;
            try
            {
                var typeArgs = binder.GetTypeArguments();
                var hasTypeArgs = typeArgs != null && typeArgs.Count > 0;
                var methodSelectorTuple = Tuple.Create(binder.Name, hasTypeArgs, args.Length);
                var selectorTuple = Tuple.Create(binder.Name, hasTypeArgs);

                method = _publicMethods[methodSelectorTuple];
                outTransformer = _outTransformers.ContainsKey(selectorTuple) ? _outTransformers[selectorTuple] : _identity;
                interceptor = _interceptors.ContainsKey(selectorTuple) ? _interceptors[selectorTuple] : null;
                inTransformer = _inTransformers.ContainsKey(binder.Name) ? _inTransformers[binder.Name] : null;
                
                if (hasTypeArgs)
                {
                    method = method.MakeGenericMethod(typeArgs.ToArray());
                }
            }
            catch
            {
                result = null;
                return false;
            }
            try
            {
                if (inTransformer != null)
                {
                    args[inTransformer.Item1] = inTransformer.Item2.FastDynamicInvoke(args[inTransformer.Item1]);
                }

                object partialResult;
                if (interceptor != null)
                {
                    Func<object, object[], object> meth = method.Invoke;
                    Func<object, Func<object[], object>> curry = Impromptu.Curry(meth);
                    var curriedMethod = curry(_wrappedObject);
                    partialResult = interceptor.FastDynamicInvoke(new object[] {curriedMethod, args});
                }
                else
                {
                    partialResult = method.Invoke(_wrappedObject, args);
                }
            
                result = outTransformer.FastDynamicInvoke(partialResult);
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
            return true;
        }

        public IProxy<T> AddTransformer<T2, TResult>(Expression fucntionOrProperty, Direction direction, Func<T2, TResult> transformer)
        {
            var memberInfo = fucntionOrProperty.GetTargetMemberInfo();
            var functionOrPropertyName = memberInfo.Name;
            var hasGenericTypeArguments = (memberInfo.MemberType == MemberTypes.Method) && ((MethodInfo) memberInfo).IsGenericMethod;

            if (direction == Direction.In)
            {
                switch (memberInfo.MemberType)
                {
                    case MemberTypes.Property:
                        _inTransformers.Add(functionOrPropertyName, Tuple.Create(0, (Delegate)transformer));
                        break;
                    case MemberTypes.Method:
                    {
                        var methodCall = fucntionOrProperty.GetTargetMethodCall();
                        var arg = methodCall.Arguments.Select((a, i) => Tuple.Create(i, (MemberExpression) a)).First(t => t.Item2.Member.Name == "Selected");
                        _inTransformers.Add(functionOrPropertyName, Tuple.Create(arg.Item1, (Delegate)transformer));
                    }
                    break;
                }
            }
            else
            {
                _outTransformers.Add(Tuple.Create(functionOrPropertyName, hasGenericTypeArguments), transformer);
            }
            return this;
        }

        public IProxy<T> AddTransformer<T1, T2>(Expression<Action<T>> function, Direction direction, Func<T1, T2> transformer)
        {
            return AddTransformer((Expression) function, direction, transformer);
        }

        public IProxy<T> AddTransformer<T1, T2>(Expression<Func<T, T1>> property, Direction direction, Func<T1, T2> transformer)
        {
            return AddTransformer((Expression) property, direction, transformer);
        }

        public IProxy<T> AddTransformer<T2>(Expression<Action<T>> function, Direction direction, Func<T2, T2> transformer)
        {
            return AddTransformer<T2, T2>(function, direction, transformer);
        }
        
        public IProxy<T> AddInterceptor<TResult>(Expression<Func<T, TResult>> property, Func<Func<TResult>, TResult> interceptor)
        {
            return AddPropertyInterceptor(property, (del, args) => interceptor(() => (TResult)del.FastDynamicInvoke()), Direction.Out);
        }

        public IProxy<T> AddInterceptor<TProp>(Expression<Func<T, TProp>> property, Action<Action<TProp>, TProp> func)
        {
            return AddPropertyInterceptor(property, (del, args) => { func(a => del(new object[] { a }), (TProp)args[0]); return null; }, Direction.In);
        }

        public IProxy<T> AddInterceptor(Expression<Action<T>> function, Action<Action> interceptor)
        {
            return AddFunctionInterceptor(function, (del, args) =>  { interceptor(() => del(args)); return null; });
        }

        /// <summary>
        /// Mother of all Interceptor add functions. Actually does the adding.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        private IProxy<T> AddFunctionInterceptor(Expression<Action<T>> function, Func<Func<object[], object>, object[], object> func)
        {
            var memberInfo = function.GetTargetMemberInfo();
            var functionOrPropertyName = memberInfo.Name;
            var hasGenericTypeArguments = (memberInfo.MemberType == MemberTypes.Method) && ((MethodInfo)memberInfo).IsGenericMethod;
            
            _interceptors.Add(Tuple.Create(functionOrPropertyName, hasGenericTypeArguments), new Func<Delegate, object[], object> ((del, args) => func(arg => del.FastDynamicInvoke(new object[] { arg }), args)));
            return this;
        }

        /// <summary>
        /// Mother of all Interceptor add functions. Actually does the adding.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="func"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private IProxy<T> AddPropertyInterceptor(Expression property, Func<Func<object[], object>, object[], object> func, Direction direction)
        {
            var memberInfo = property.GetTargetMemberInfo();
            var propertyName = memberInfo.Name;
         
            _propertyInterceptors.Add(Tuple.Create(propertyName, direction), new Func<Delegate, object[], object>((del, args) => func(arg => del.FastDynamicInvoke(new object[] { arg }), args)));
            return this;
        }
    }
}