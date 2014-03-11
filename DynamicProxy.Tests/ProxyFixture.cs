namespace DynamicProxy.Tests
{
    using System;
    using Xunit;
    using XunitShould;

    public interface ICallee
    {
        string Banaan(int input);
        void ThrowUp();
        void DoNothing();
        int Test(int i);
        string AlsoATest(int i, double d);
        T Test<T>(T input);
        int I { get; set; }
    }

    public class Callee
    {
        public virtual int Test(int i)
        {
            return i + 1;
        }

        public int Banaan(int input)
        {
            return input;
        }

        public void ThrowUp()
        {
            throw new Exception("Blergh!");
        }

        public void DoNothing()
        {
        }

        public virtual T Test<T>(T input)
        {
            if (typeof (T) != typeof (int)) return input;
            
            var iInput = Convert.ToInt32(input);
            
            return (T) (object) (iInput + 2);
        }

        public string AlsoATest(int i, double d)
        {
            return (i + d).ToString();
        }

        public int I { get; set; }
    }

    public class ProxyFixture
    {
        [Fact]
        public void ShouldThrowWhenTryingToProxyWithAConcreteType()
        {
            //Given, When, Then
            new Action(() => ProxyFactory<Callee>.Proxy<Callee>(new Callee())).ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void ShouldBeTransparentByDefault()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());

            //When
            var result = proxiedCallee.Test(5);

            //Then
            result.ShouldEqual(6);
        }

        [Fact]
        public void ShouldAlsoImplementIProxy()
        {
            //Given, When
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());

            //Then
            proxiedCallee.ShouldNotBeInstanceOf<IProxy<Callee>>();
        }

        [Fact]
        public void ShouldBeAbleToProxyAGenericMethod()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());

            //When
            var result = proxiedCallee.Test<int>(7);

            //Then
            result.ShouldEqual(9);
        }

        [Fact]
        public void ShouldBeAbleToProxyAProperty()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
           
            //When
            proxiedCallee.I = 5;
            proxiedCallee.I = 6;

            //Then
            proxiedCallee.I.ShouldEqual(6);
        }

        [Fact]
        public void ShouldBeAbleTransformTheReturnValueOfAFunction()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;
            proxy.AddTransformer<int, string>(c => c.Banaan(A<int>.PlaceHolder), Direction.Out, i => i.ToString());

            //When
            var d = proxiedCallee.Banaan(5);

            //Then
            d.ShouldEqual("5");
        }

        [Fact]
        public void ShouldBeAbleToTransformTheReturnValueOfAGenericFunction()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;

            proxy.AddTransformer<double>(c => c.Test(A<double>.PlaceHolder), Direction.Out, a => a + 2).AddTransformer<int>(c => c.Test(A<int>.PlaceHolder), Direction.Out, i => i + 1);
            
            //When
            var d = proxiedCallee.Test(5.0);

            //Then
            d.ShouldEqual(7.0);
        }

        [Fact]
        public void ShouldBeAbleToHaveATransformerForAGenericVersionAndANonGenericVersionOfAMethodWithTheSameName()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;

            proxy.AddTransformer<double>(c => c.Test(A<double>.PlaceHolder), Direction.Out, a => a + 2)
                 .AddTransformer<int>(c => c.Test(A<int>.PlaceHolder), Direction.Out, i => i + 1);

            //When
            var d = proxiedCallee.Test(5.0);

            //Then
            d.ShouldEqual(7.0);
        }

        [Fact]
        public void ShouldProxyExceptionsAswell()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());

            //When, Then
            new Action(proxiedCallee.ThrowUp).ShouldThrow<Exception>("Blergh!");
        }

        [Fact]
        public void ShouldBeAbleToInterceptAFunctionCall()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;
            
            //When
            proxy.AddInterceptor(callee => callee.DoNothing(), d => proxiedCallee.ThrowUp());

            //Then 
            new Action(proxiedCallee.DoNothing).ShouldThrow<Exception>("Blergh!");
        }

        [Fact]
        public void ShouldBeAbleToInterceptAFunctionCallWithAParameterAndAReturnValueOfTheSameType()
        {
            //Given
            var aFakedCallee = FakeItEasy.A.Fake<Callee>();
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(aFakedCallee);
            var proxy = proxiedCallee as IProxy<Callee>;

            //When
            proxy.AddInterceptor<int, int>(callee => callee.Test(A<int>.PlaceHolder), (f, arg) => arg + 3);
            var result = proxiedCallee.Test(5);
            
            //Then
            FakeItEasy.A.CallTo(() => aFakedCallee.Test(FakeItEasy.A<int>.Ignored)).MustHaveHappened(FakeItEasy.Repeated.Never);
            result.ShouldEqual(8);
        }

        [Fact]
        public void ShouldBeAbleToInterceptAGenericFunctionCall()
        {
            //Given
            var aFakedCallee = FakeItEasy.A.Fake<Callee>();
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(aFakedCallee);
            var proxy = proxiedCallee as IProxy<Callee>;

            //When
            proxy.AddInterceptor<double, int>(callee => callee.Test(A<double>.PlaceHolder), (f, arg) => (int)arg + 3);
            var result = proxiedCallee.Test(5.0);

            //Then
            FakeItEasy.A.CallTo(() => aFakedCallee.Test(FakeItEasy.A<double>.Ignored)).MustHaveHappened(FakeItEasy.Repeated.Never);
            result.ShouldEqual(8);
        }

        [Fact]
        public void ShouldBeAlbeToInterceptAFunctionCallWithMoreParameters()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;
            proxy.AddInterceptor<int, double, string>(c => c.AlsoATest(A<int>.PlaceHolder, A<double>.PlaceHolder), (func, i, arg3) => func(i, arg3));

            //When
            var result = proxiedCallee.AlsoATest(4, 4.0);

            //Then
            result.ShouldEqual("8");
        }

        [Fact]
        public void ShouldBeAbleToTransforAFunctionParameter()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;
            proxy.AddTransformer<double>(c => c.AlsoATest(A<int>.PlaceHolder, A<double>.Selected), Direction.In, d => d + 12.4);

            //When
            var result = proxiedCallee.AlsoATest(4, 4.0);

            //Then
            result.ShouldEqual("20.4");
        }

        [Fact]
        public void ShouldBeAbleToTransformTheInputOfAProperty()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;
            proxy.AddTransformer(c => c.I, Direction.In, d => (int)(d + 12.4));

            //When
            proxiedCallee.I = 8;

            //Then
            proxiedCallee.I.ShouldEqual(20);
        }

        [Fact]
        public void ShouldBeAbleToTransformTheOutputOfAProperty()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;
            proxy.AddTransformer(c => c.I, Direction.Out, d => (int)(d + 12.4));

            //When
            proxiedCallee.I = 8;

            //Then
            proxiedCallee.I.ShouldEqual(20);
        }

        [Fact]
        public void ShouldBeAbleToInterceptAPropertyGetter()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;

            //When
            proxy.AddInterceptor(c => c.I, func => 7);

            //Then
            proxiedCallee.I.ShouldEqual(7);
        }

        [Fact]
        public void ShouldBeAbleToInterceptAPropertySetter()
        {
            //Given
            var proxiedCallee = ProxyFactory<Callee>.Proxy<ICallee>(new Callee());
            var proxy = proxiedCallee as IProxy<Callee>;
            proxy.AddInterceptor<int, int>(c => c.I, (func, i) => func(i + 2));
            
            //When
            proxiedCallee.I = 5;
            
            //Then
            proxiedCallee.I.ShouldEqual(7);
        }

    }
}
