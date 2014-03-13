#DynamicProxy

A fast (hopefully), simple, transparant. easy to understand object proxy based on the DLR And Impromptu-Interface.

##So what does it do?

It lets you modify functions and properties in three ways.

But before we discus these three things we need to build the proxy.

And that goes something like this:

We have this class it's sealed and its thirdparty or legacy or whatever else why you don't want to meddle with it directly. Or maybe just for yourself.

```c#
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
```

You have to make an interface that looks like the class.

```c#
public interface IBook
{
    int NumberOfPages { get; set; }
	//notice you can unhide the setter for CurrentPage.
    int CurrentPage { get; set;  }
    void NextPage();
    int[] AddChapter(string name, int startpage, int endpage);
}
```

Then we make the proxy.

```c#
IBook proxiedBook = ProxyFactory<Book>.Proxy<IBook>(book);
```

This proxiedBook also implements the interface `IProxy<Book>` which contains the functions for adding Transformers and Interceptors.

```c#
IProxy<Book> proxy = proxiedBook as IProxy<Book>;
```

###Input or parameter Transformers

You can change the value or the type of a paramter.

```c#
proxy.AddTransformer<int>(c => c.AddChapter(A<string>.PlaceHolder, A<int>.Selected, A<int>.PlaceHolder), Direction.In, i => i - 1);
```

Or for a property:

```c#
proxy.AddTransformer(c => c.CurrentPage, Direction.In, i => i - 5);
```

###Returnvalue Transformers

The other way round:

for properties
```c#
proxy.AddTransformer(c => c.CurrentPage, Direction.In, i => i - 5);
```

for functions:
```c#
proxy.AddTransformer<int[]>(
    c => c.AddChapter(A<string>.PlaceHolder, A<int>.PlaceHolder, A<int>.PlaceHolder), Direction.Out,
    i => i.Reverse().ToArray());
```

###Interceptors

You can intercept function calls like this:
```c#
proxy.AddInterceptor<string, int, int, int[]>((b, name, start, end) => b.AddChapter(name, start, end),
    (func, s, i, i2) =>
    {
        Console.Out.WriteLine("Start: " + i);
        Console.Out.WriteLine("End: " + i2);
        Console.Out.WriteLine("Adding chapter " + s + " containing " + (i2 - i) + " pages");
        return func(s, i, i2);
    });
```

Or a void function without parameters:

```c#
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
```