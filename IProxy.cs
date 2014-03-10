namespace DynamicProxy
{
    using System;
    using System.Linq.Expressions;

    public enum Direction { In, Out }

    public partial interface IProxy<T>
    {
        IProxy<T> AddTransformer<T1, T2>(Expression<Action<T>> functionOrProperty, Direction direction, Func<T1, T2> transformer);
        IProxy<T> AddTransformer<T1>(Expression<Action<T>> functionOrProperty, Direction direction, Func<T1, T1> transformer);
        
        IProxy<T> AddInterceptor(Expression<Action<T>> functionOrProperty, Action<Action> action);
        //IProxy<T> AddInterceptor<T1>(Expression<Action<T>> functionOrProperty, Action<Action<T1>, T1> action);
        //IProxy<T> AddInterceptor<T1, T2>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2>, T1, T2> action);
        //IProxy<T> AddInterceptor<T1, T2, T3>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3>, T1, T2, T3> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action);
        
        //IProxy<T> AddInterceptor<T1, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, TResult>, T1, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, TResult>, T1, T2, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func);
        //IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func);
        
        IProxy<T> AddInterceptor(Expression<Action<T>> functionOrProperty, Func<Func<object[], object>, object[], object> func);
    }
}
