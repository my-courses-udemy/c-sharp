namespace Advanced_Course.factory;

public static class FactoryPattern<TK, T> where T : class, TK, new()
{
    public static TK GetInstance()
    {
        TK objK = new T();
        return objK;
    }
}