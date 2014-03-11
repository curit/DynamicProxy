namespace DynamicProxy
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using ImpromptuInterface;

    public static class A<T>
    {
        public static T PlaceHolder
        {
            get { return default(T); }
        }

        public static T Selected
        {
            get { return default(T); }
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
        private readonly Dictionary<string, PropertyInfo> _properties;
        private readonly Dictionary<Tuple<string, bool, int>, MethodInfo> _publicMethods;
        
        private readonly Dictionary<Tuple<string, bool>, Delegate> _interceptors = new Dictionary<Tuple<string, bool>, Delegate>();
        private readonly Dictionary<Tuple<string, bool>, Delegate> _outTransformers = new Dictionary<Tuple<string, bool>, Delegate>();
        private readonly Dictionary<string, Tuple<int, Delegate>> _inTransformers = new Dictionary<string, Tuple<int, Delegate>>();

        public static T1 Proxy<T1>(T obj) where T1 : class
        {
            if (!typeof(T1).IsInterface)
                throw new ArgumentException("T1 must be an Interface", "T1");
            
            return new ProxyFactory<T>(obj).ActLike<T1>(typeof(IProxy<T>));
        }

        //you can make the contructor private so you are forced to use the Proxy method.
        private ProxyFactory(T obj)
        {
            _wrappedObject = obj;
            _wrappedObjectType = typeof(T);
            _properties = _wrappedObjectType.GetProperties().ToDictionary(p => p.Name, p => p);
            _publicMethods =
                _wrappedObjectType.GetMethods()
                    .Where(m => !m.IsSpecialName) //exclude property functions
                    .Where(m => m.IsPublic)
                    .Where(m => m.DeclaringType == _wrappedObjectType)
                    .ToDictionary(m => Tuple.Create(m.Name, m.IsGenericMethod, m.GetParameters().Length), p => p);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var outTransformer = _outTransformers.ContainsKey(Tuple.Create(binder.Name, false))
                ? _outTransformers[Tuple.Create(binder.Name, false)]
                : new Func<object, object>(x => x);

            var interceptor = _interceptors.ContainsKey(Tuple.Create(binder.Name, false))
                ? _interceptors[Tuple.Create(binder.Name, false)]
                : null;

            var property = _properties[binder.Name];

            object partialResult;

            if (interceptor != null)
            {
                Func<object, object[], object> meth = property.GetValue;
                Func<object, Func<object[], object>> curry = Impromptu.Curry(meth);
                Func<object[], object> curriedMethod = curry(_wrappedObject);
                partialResult = interceptor.FastDynamicInvoke(new object[] { curriedMethod });
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
            var inTransformer = _inTransformers.ContainsKey(binder.Name)
                ? _inTransformers[binder.Name].Item2
                : new Func<object, object>(x => x);

            var interceptor = _interceptors.ContainsKey(Tuple.Create(binder.Name, false))
               ? _interceptors[Tuple.Create(binder.Name, false)]
               : null;

            var property = _properties[binder.Name];

            var transformedValue = inTransformer.FastDynamicInvoke(value);

            if (interceptor != null)
            {
                Action<object, object> meth = property.SetValue;
                Func<object, Action<object>> curry = Impromptu.Curry(meth);
                Action<object> curriedMethod = curry(_wrappedObject);
                interceptor.FastDynamicInvoke(new [] { curriedMethod, transformedValue });
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
                var typeArgs = Impromptu.InvokeGet(binder, "Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder.TypeArguments") as IList<Type>;
                var hasTypeArgs = typeArgs != null && typeArgs.Count > 0;
                method = _publicMethods[Tuple.Create(binder.Name, hasTypeArgs, args.Length)];
                outTransformer = _outTransformers.ContainsKey(Tuple.Create(binder.Name, hasTypeArgs))
                    ? _outTransformers[Tuple.Create(binder.Name, hasTypeArgs)]
                    : new Func<object, object>(x => x);
                
                interceptor = _interceptors.ContainsKey(Tuple.Create(binder.Name, hasTypeArgs))
                    ? _interceptors[Tuple.Create(binder.Name, hasTypeArgs)]
                    : null;

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
                    Func<object[], object> curriedMethod = curry(_wrappedObject);
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

        public IProxy<T> AddTransformer<T2, T3>(Expression functionOrProperty, Direction direction, Func<T2, T3> transformer)
        {
            var memberInfo = functionOrProperty.GetTargetMemberInfo();
            var functionOrPropertyName = memberInfo.Name;
            var hasGenericTypeArguments = (memberInfo.MemberType == MemberTypes.Method) &&
                                          ((MethodInfo) memberInfo).IsGenericMethod;

            if (direction == Direction.In)
            {
                if (memberInfo.MemberType == MemberTypes.Property)
                {
                    _inTransformers.Add(functionOrPropertyName, Tuple.Create(0, (Delegate)transformer));
                }
                else if (memberInfo.MemberType == MemberTypes.Method)
                {
                    var methodCall = functionOrProperty.GetTargetMethodCall();
                    var arg =
                        methodCall.Arguments.Select((a, i) => new Tuple<int, MemberExpression>(i, (MemberExpression) a))
                            .First(t => t.Item2.Member.Name == "Selected");
                    _inTransformers.Add(functionOrPropertyName, Tuple.Create(arg.Item1, (Delegate)transformer));
                }
            }
            else
            {
                _outTransformers.Add(Tuple.Create(functionOrPropertyName, hasGenericTypeArguments), transformer);
            }
            return this;
        }

        public IProxy<T> AddTransformer<T1, T2>(Expression<Action<T>> functionOrProperty, Direction direction, Func<T1, T2> transformer)
        {
            return AddTransformer((Expression) functionOrProperty, direction, transformer);
        }

        public IProxy<T> AddTransformer<T1, T2>(Expression<Func<T, T1>> functionOrProperty, Direction direction, Func<T1, T2> transformer)
        {
            return AddTransformer((Expression) functionOrProperty, direction, transformer);
        }

        public IProxy<T> AddTransformer<T2>(Expression<Action<T>> functionOrProperty, Direction direction, Func<T2, T2> transformer)
        {
            return AddTransformer<T2, T2>(functionOrProperty, direction, transformer);
        }

        public IProxy<T> AddInterceptor(Expression<Action<T>> functionOrProperty, Action<Action> action)
        {
            return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(() => del(args));
                return null;
            });
        }

        public IProxy<T> AddInterceptor(Expression<Action<T>> functionOrProperty, Func<Func<object[], object>, object[], object> func)
        {
            var memberInfo = functionOrProperty.GetTargetMemberInfo();
            var functionOrPropertyName = memberInfo.Name;
            var hasGenericTypeArguments = (memberInfo.MemberType == MemberTypes.Method) &&
                                          ((MethodInfo)memberInfo).IsGenericMethod;

            _interceptors.Add(Tuple.Create(functionOrPropertyName, hasGenericTypeArguments), new Func<Delegate, object[], object> ((del, args) => func(arg => del.FastDynamicInvoke(new object[] { arg }), args)));
            return this;
        }
    }
}