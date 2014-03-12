namespace DynamicProxy.Example
{
    using System;

    public interface IBook
    {
        int NumberOfPages { get; set; }
        int CurrentPage { get; set;  }
        void NextPage();
    }

    public sealed class Book
    {
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; private set; }

        public void NextPage()
        {
            if (CurrentPage == NumberOfPages)
            {
                throw new EndOfBookException("You've reached the end");
            }
            CurrentPage++;
        }
    }

    public class EndOfBookException : Exception
    {
        public EndOfBookException(string message) : base(message) { }
    }


    public static class Program
    {
        static void Main(string[] args)
        {
            var book = new Book {NumberOfPages = 600};

            var proxiedBook = ProxyFactory<Book>.Proxy<IBook>(book);
            var proxy = proxiedBook as IProxy<Book>;
            //make the setter available;
            proxiedBook.CurrentPage = 5;

            //we don't have about the first 5 pages they're bullshit or emtpy.
            proxy.AddTransformer(c => c.NumberOfPages, Direction.Out, f => f - 5);
            proxy.AddTransformer(c => c.CurrentPage, Direction.Out, i => i - 5);
            
            //we don't want to see that exception. And we want it to return the currentpage
            proxy.AddInterceptor(c => c.NextPage(), action =>
            {
                try
                {
                    action();
                }
                catch (EndOfBookException)
                {
                }
            });

            Console.Out.WriteLine("Number of pages: " + proxiedBook.NumberOfPages);
            Console.Out.WriteLine("Current page: " + proxiedBook.CurrentPage);
              
            while (proxiedBook.CurrentPage <= proxiedBook.NumberOfPages)
            {
                proxiedBook.NextPage();
                Console.Out.Write(proxiedBook.CurrentPage + ", ");
            }

            Console.In.ReadLine();
        }
    }
}