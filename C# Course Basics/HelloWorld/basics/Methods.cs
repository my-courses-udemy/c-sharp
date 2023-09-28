namespace HelloWorld.basics;

public class Methods
{
    //! Static Method not public
    static void main()
    {
        WriteSomething();
        WriteSomethingSpecific("This is an argument");
    }

    private static void WriteSomething()
    {
        Console.WriteLine("hello from method");
    }

    //! This is call parameter in the method
    public static void WriteSomethingSpecific(string specific)
    {
        Console.WriteLine(specific);
    }
}