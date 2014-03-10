namespace DynamicProxy
{
    using System;
    using System.Linq.Expressions;

    public enum Direction { In, Out }

    public partial interface IProxy<T>
    {
        IProxy<T> AddTransformer<T1>(Expression<Action<T>> functionOrProperty, Direction direction, Func<T1, T1> transformer);
        IProxy<T> AddTransformer<T1, T2>(Expression<Action<T>> functionOrProperty, Direction direction, Func<T1, T2> transformer);
        IProxy<T> AddInterceptor(Expression<Action<T>> functionOrProperty, Action<Action> action);
        IProxy<T> AddInterceptor(Expression<Action<T>> functionOrProperty, Func<Func<object[], object>, object[], object> func);
    }
}
