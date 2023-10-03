// See https://aka.ms/new-console-template for more information


using Delegate;

delegate void LogDel(string message);
//! This delegate is accesible to all classes in the namespace

//! A delegate is a type safe function pointer
class Program
{
    private delegate int CalculateDel(int a, int b);

    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        CalculateDel calc = AddInteger;
        int result = calc(10, 20);
        Console.WriteLine($"The result is {result}");
        calc = SubtractInteger;
        result = calc(20, 10);
        Console.WriteLine($"The result is {result}");

        Console.WriteLine("Pass your name");
        var name = Console.ReadLine();

        //! LogDel log = LogtextToString;
        //! if (name != null) log(name);
        //! log = LogTextToFile;
        //! if (name != null) log(name);

        ClassDelegate classDelegate = new ClassDelegate();
        LogDel log = classDelegate.LogtextToString;
        log = classDelegate.LogTextToFile;
        // if (name != null) log(name);

        //! MULTICAST DELEGATES
        LogDel logTextString, logTextFile;
        logTextString = classDelegate.LogtextToString;
        logTextFile = classDelegate.LogTextToFile;
        //? This delegate will call both methods, they can be combined
        LogDel multipleLogs = logTextString + logTextFile;
        if (name != null) LogText(multipleLogs, name);
    }

    static int AddInteger(int a, int b)
    {
        return a + b;
    }

    static int SubtractInteger(int a, int b)
    {
        return a - b;
    }

    static void LogText(LogDel log, string message)
    {
        log(message);
    }
}