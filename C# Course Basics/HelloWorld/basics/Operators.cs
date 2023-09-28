namespace HelloWorld.basics;

public class Operators
{
    static void main()
    {
        int num1 = 5;
        int num2 = 3;
        int num3;

        //! Unary operators
        num3 = -num1;
        Console.WriteLine("Num3: is {0}", num3);

        bool isSunny = true;
        Console.WriteLine("is is sunny? {0}", !isSunny);

        // increment operators
        int num4 = 2;
        Console.WriteLine(num4++);
        Console.WriteLine(num4);
        Console.WriteLine(++num3);

        bool next = false;
        next = next && isSunny;
        next = next || isSunny;
        bool result = 12 > 2;
    }
}