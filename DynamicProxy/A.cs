namespace DynamicProxy
{
    public static class A<T>
    {
        public static T PlaceHolder
        {
            get { return default(T); }
        }

        public static T Selected
        {
            get { return default(T); }
        }
    }
}