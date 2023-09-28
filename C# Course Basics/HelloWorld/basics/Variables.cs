namespace HelloWorld.basics;

public class Variables
{
    // ? Primitive data types
    // ? Explicitly
    public static string text = "hello world";
    private float price = 12f;
    string name = "hello maria";
    char letter = 'a';
    private int number = 2;
    private long number2 = 2;
    bool isOpen = false;
    // ? Implicitly
    // ! var = var java

    // ! Create description or documentation
    /// <summary>
    /// This is an entry point of our application
    /// </summary>
    public static void main()
    {
        // Console.WriteLine(text);
        // !Variables
        int a = 12;
        int b = 13;
        int c = a + b;
        Console.WriteLine("Result is: " + c);

        string hello = "hello world";
        string text = "Scope problem"; // !Scope

        float vat = 12f;
        float productA = 12.23f;
        float productB = 1.23f;

        var total = (productA + productB + vat) / 3;
        Console.WriteLine("Total: " + total);

        // Comments
        /*
         * Other comment
         * Other
         */

        Calculate();
    }

    public static void Calculate()
    {
        Console.WriteLine("Text is: " + text);
    }
}