namespace DynamicProxy
{
    using System;
    using System.Linq.Expressions;

    public enum Direction { In, Out }

    public partial interface IProxy<T>
    {
        /// <summary>
        /// Main fucntionOrProperty for adding transformers.
        /// </summary>
        /// <typeparam name="T1">Input Type</typeparam>
        /// <typeparam name="TResult">Result Type</typeparam>
        /// <param name="fucntionOrProperty">An expression pointing to the fucntion or a function or parameter</param>
        /// <param name="direction">Whether you want to transform the input or the output <see cref="Direction"/></param>
        /// <param name="transformer">The delegate containing the tranformer.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddTransformer<T1, TResult>(Expression fucntionOrProperty, Direction direction, Func<T1, TResult> transformer);

        /// <summary>
        /// Conveniance function for adding a transformer with the same input as output to a function.
        /// </summary>
        /// <typeparam name="T1">The in and output type.</typeparam>
        /// <param name="function">An expression pointing to a function.</param>
        /// <param name="direction">Whether you want to transform the result or a parameter.</param>
        /// <param name="transformer">The delegate containing the transformer.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddTransformer<T1>(Expression<Action<T>> function, Direction direction, Func<T1, T1> transformer);

        /// <summary>
        /// Function to add a transformer to a function.
        /// </summary>
        /// <typeparam name="T1">The in and output type.</typeparam>
        /// <typeparam name="TResult">The resulting type</typeparam>
        /// <param name="function">An expression pointing to a function.</param>
        /// <param name="direction">Whether you want to transform the result or a parameter.</param>
        /// <param name="transformer">The delegate containing the transformer.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddTransformer<T1, TResult>(Expression<Action<T>> function, Direction direction, Func<T1, TResult> transformer);

        /// <summary>
        /// Function to add a transformer to a function
        /// </summary>
        /// <typeparam name="T1">The in and output type.</typeparam>
        /// <typeparam name="TResult">The resulting type.</typeparam>
        /// <param name="property">An expression pointing to a function.</param>
        /// <param name="direction">Whether you want to transform the result or a parameter.</param>
        /// <param name="transformer">The delegate containing the transformer.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddTransformer<T1, TResult>(Expression<Func<T, T1>> property, Direction direction, Func<T1, TResult> transformer);
        
        /// <summary>
        /// Add interceptor to void function without parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor(Expression<Action<T>> function, Action<Action> interceptor);

        /// <summary>
        /// Add Interceptor to PropertyGet that doesn't change the type
        /// </summary>
        /// <typeparam name="TProp">Type of the property</typeparam>
        /// <param name="property">Expression pointing to the function</param>
        /// <param name="interceptor">The Interceptor delegate</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<TProp>(Expression<Func<T, TProp>> property, Func<Func<TProp>, TProp> interceptor);

        /// <summary>
        /// Add Interceptor to PropertyGet
        /// </summary>
        /// <typeparam name="TOriginal">Type of the property</typeparam>
        /// <typeparam name="TNew">The new type of the property</typeparam>
        /// <param name="property">Expression pointing to the function</param>
        /// <param name="interceptor">The Interceptor delegate</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<TOriginal, TNew>(Expression<Func<T, TOriginal>> property, Func<Func<TOriginal>, TNew> interceptor);

        /// <summary>
        /// Add Interceptor to PropertySet
        /// </summary>
        /// <typeparam name="TProp">Type of the property</typeparam>
        /// <param name="property">Expression pointing to the function</param>
        /// <param name="interceptor">The Interceptor delegate</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<TProp>(Expression<Func<T, TProp>> property, Action<Action<TProp>, TProp> interceptor);

        /// <summary>
        /// Add Interceptor to PropertySet
        /// </summary>
        /// <typeparam name="TOriginal">Type of the property</typeparam>
        /// <typeparam name="TNew">The new type of the property</typeparam>
        /// <param name="property">Expression pointing to the function</param>
        /// <param name="interceptor">The Interceptor delegate</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<TOriginal, TNew>(Expression<Func<T, TOriginal>> property, Action<Action<TOriginal>, TNew> interceptor);

        //IProxy<T> AddFunctionInterceptor(Expression<Action<T>> function, Func<Func<object[], object>, object[], object> func);
        //IProxy<T> AddPropertyInterceptor(Expression property, Func<Func<object[], object>, object[], object> func, Direction direction);
    }
}
