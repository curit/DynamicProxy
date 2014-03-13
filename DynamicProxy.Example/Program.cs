namespace DynamicProxy.Example
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IBook
    {
        int NumberOfPages { get; set; }
        int CurrentPage { get; set;  }
        void NextPage();
        int[] AddChapter(string name, int startpage, int endpage);
    }

    public sealed class Book
    {
        public Book()
        {
            Chapters = new List<Tuple<string, int[]>>();
        }

        public int NumberOfPages { get; set; }
        public int CurrentPage { get; private set; }
        private List<Tuple<string,int[]>> Chapters { get; set; } 

        public void NextPage()
        {
            if (CurrentPage == NumberOfPages)
            {
                throw new EndOfBookException("You've reached the end");
            }
            CurrentPage++;
        }

        public int[] AddChapter(string name, int startpage, int endpage)
        {
            Chapters.Add(Tuple.Create(name, Enumerable.Range(startpage, endpage-startpage).ToArray()));
            return Enumerable.Range(startpage, endpage - startpage).ToArray();
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

            //we want to include an extra page in the chapter 
            proxy.AddTransformer<int>(c => c.AddChapter(A<string>.PlaceHolder, A<int>.Selected, A<int>.PlaceHolder), Direction.In, i => i - 1);

            //we want to intercept it because we can!
            proxy.AddInterceptor<string, int, int, int[]>((b, name, start, end) => b.AddChapter(name, start, end),
                (func, s, i, i2) =>
                {
                    Console.Out.WriteLine("Start: " + i);
                    Console.Out.WriteLine("End: " + i2);
                    Console.Out.WriteLine("Adding chapter " + s + " containing " + (i2 - i) + " pages");
                    return func(s, i, i2);
                });
            
            Console.Out.WriteLine("Number of pages: " + proxiedBook.NumberOfPages);
            Console.Out.WriteLine("Current page: " + proxiedBook.CurrentPage);
              
            while (proxiedBook.CurrentPage != proxiedBook.NumberOfPages)
            {
                proxiedBook.NextPage();
                Console.Out.Write(proxiedBook.CurrentPage + ", ");
            }
            //No exception here!
            Console.Out.WriteLine(proxiedBook.CurrentPage);

            proxiedBook.AddChapter("1st Chapter", 6, 42);
            Console.In.ReadLine();
        }
    }
}