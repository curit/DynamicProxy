namespace DynamicProxy
{
	using System;
	using System.Dynamic;
	using System.Linq.Expressions;

	public partial interface IProxy<T>
	{
	    /// <summary>
        /// Add interceptor to function with 1 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, TResult>(Expression<Action<T, T1>> function, Func<Func<T1, TResult>, T1, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 2 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, TResult>(Expression<Action<T, T1, T2>> function, Func<Func<T1, T2, TResult>, T1, T2, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 3 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, TResult>(Expression<Action<T, T1, T2, T3>> function, Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 4 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, TResult>(Expression<Action<T, T1, T2, T3, T4>> function, Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 5 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, TResult>(Expression<Action<T, T1, T2, T3, T4, T5>> function, Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 6 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6>> function, Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 7 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 8 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 9 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 10 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 11 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 12 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 13 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 14 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> interceptor);
	
	    /// <summary>
        /// Add interceptor to function with 15 parameters that returns something;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> interceptor);
	

	    /// <summary>
        /// Add interceptor to a void function with 2 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2>(Expression<Action<T, T1, T2>> function, Action<Action<T1, T2>, T1, T2> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 3 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3>(Expression<Action<T, T1, T2, T3>> function, Action<Action<T1, T2, T3>, T1, T2, T3> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 4 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4>(Expression<Action<T, T1, T2, T3, T4>> function, Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 5 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5>(Expression<Action<T, T1, T2, T3, T4, T5>> function, Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 6 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6>(Expression<Action<T, T1, T2, T3, T4, T5, T6>> function, Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 7 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 8 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 9 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 10 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 11 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 12 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 13 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 14 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> interceptor);

	    /// <summary>
        /// Add interceptor to a void function with 15 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> interceptor);

}

	public partial class ProxyFactory<T>
	{
		public IProxy<T> AddInterceptor<T1, TResult>(Expression<Action<T, T1>> function, Func<Func<T1, TResult>, T1, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1) => (TResult) del(new object[] { arg1 }), (T1)args[0]));
		}

		public IProxy<T> AddInterceptor<T1, T2, TResult>(Expression<Action<T, T1, T2>> function, Func<Func<T1, T2, TResult>, T1, T2, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2) => (TResult) del(new object[] { arg1, arg2 }), (T1)args[0], (T2)args[1]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, TResult>(Expression<Action<T, T1, T2, T3>> function, Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3) => (TResult) del(new object[] { arg1, arg2, arg3 }), (T1)args[0], (T2)args[1], (T3)args[2]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, TResult>(Expression<Action<T, T1, T2, T3, T4>> function, Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4) => (TResult) del(new object[] { arg1, arg2, arg3, arg4 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, TResult>(Expression<Action<T, T1, T2, T3, T4, T5>> function, Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6>> function, Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> function, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => (TResult) del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14]));
		}

		
        public IProxy<T> AddInterceptor<T1>(Expression<Action<T, T1>> function, Action<Action<T1>, T1> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1) => del(new object[] { arg1 }), (T1)args[0]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2>(Expression<Action<T, T1, T2>> function, Action<Action<T1, T2>, T1, T2> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2) => del(new object[] { arg1, arg2 }), (T1)args[0], (T2)args[1]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3>(Expression<Action<T, T1, T2, T3>> function, Action<Action<T1, T2, T3>, T1, T2, T3> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3) => del(new object[] { arg1, arg2, arg3 }), (T1)args[0], (T2)args[1], (T3)args[2]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4>(Expression<Action<T, T1, T2, T3, T4>> function, Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4) => del(new object[] { arg1, arg2, arg3, arg4 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5>(Expression<Action<T, T1, T2, T3, T4, T5>> function, Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5) => del(new object[] { arg1, arg2, arg3, arg4, arg5 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6>(Expression<Action<T, T1, T2, T3, T4, T5, T6>> function, Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13]);
                return null;
            });
		}
		
        public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Action<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> function, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> interceptor)
		{
			return AddFunctionInterceptor(function, (del, args) => 
			{
                interceptor((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => del(new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15 }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14]);
                return null;
            });
		}
	}
}