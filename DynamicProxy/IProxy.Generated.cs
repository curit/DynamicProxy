
namespace DynamicProxy
{
	using System;
	using System.Dynamic;
	using System.Linq.Expressions;

	public partial interface IProxy<T>
	{
		IProxy<T> AddInterceptor<T1, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, TResult>, T1, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, TResult>, T1, T2, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func);
	
		IProxy<T> AddInterceptor<T1>(Expression<Action<T>> functionOrProperty, Action<Action<T1>, T1> func);
		IProxy<T> AddInterceptor<T1, T2>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2>, T1, T2> func);
		IProxy<T> AddInterceptor<T1, T2, T3>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3>, T1, T2, T3> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> func);
		IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> func);
	}

	public partial class ProxyFactory<T> : DynamicObject, IProxy<T>
	{
		public IProxy<T> AddInterceptor<T1, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, TResult>, T1, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1)
                        => (TResult) del(new object[]
                        {
                            arg1
                        }), (T1)args[0]));
		}

		public IProxy<T> AddInterceptor<T1, T2, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, TResult>, T1, T2, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2
                        }), (T1)args[0], (T2)args[1]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3
                        }), (T1)args[0], (T2)args[1], (T3)args[2]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13]));
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Expression<Action<T>> functionOrProperty, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
		{
			return AddInterceptor(functionOrProperty,
                (del, args) =>
                    func((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15)
                        => (TResult) del(new object[]
                        {
                            arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15
                        }), (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14]));
		}

	
		public IProxy<T> AddInterceptor<T1>(Expression<Action<T>> functionOrProperty, Action<Action<T1>, T1> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1) =>
                        del(new object[]
                        {arg1}),
                    (T1)args[0]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2>, T1, T2> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2) =>
                        del(new object[]
                        {arg1, arg2}),
                    (T1)args[0], (T2)args[1]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3>, T1, T2, T3> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3) =>
                        del(new object[]
                        {arg1, arg2, arg3}),
                    (T1)args[0], (T2)args[1], (T3)args[2]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13]);
                return null;
            });
		}

		public IProxy<T> AddInterceptor<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Action<T>> functionOrProperty, Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
		{
			return AddInterceptor(functionOrProperty, (del, args) =>
            {
                action(
                    (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) =>
                        del(new object[]
                        {arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15}),
                    (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14]);
                return null;
            });
		}

	}
}