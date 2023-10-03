namespace Advanced_Course.delegateExample;

//! Represent references to methods with a particular parameter list and return type.
public class DelegateExample
{
    delegate double del(int i, double j);

    public static void main()
    {
        del myDelegate = Method1;
        var result = myDelegate(5, 6.3);
        Console.WriteLine(result);
    }

    private static double Method1(int i, double j)
    {
        return (i * j);
    }
}