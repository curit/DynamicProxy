namespace DynamicProxy.Example
{
    using System;

    public interface IBook
    {
        int NumberOfPages { get; set; }
        int CurrentPage { get; }
        void NextPage();
    }

    public class Book
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

            //we don't have about the first 5 pages they're bullshit or emtpy.
            proxy.AddTransformer(c => c.NumberOfPages, Direction.Out, f => f - 5);
            
            Console.Out.WriteLine("Number of pages: " + proxiedBook.NumberOfPages);
            
            Console.In.ReadLine();
        }
    }
}