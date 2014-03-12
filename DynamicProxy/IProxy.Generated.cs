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
        /// Add interceptor to a void function with 1 parameters;
        /// </summary>
        /// <param name="function">An expression pointing to a function</param>
        /// <param name="interceptor">The delegate containing the interceptor.</param>
        /// <returns>The IProxy so you can chain adding Transformers and Interceptors.</returns>
        IProxy<T> AddInterceptor<T1>(Expression<Action<T, T1>> function, Action<Action<T1>, T1> interceptor);

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
	}
}