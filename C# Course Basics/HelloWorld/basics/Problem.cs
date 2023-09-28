namespace HelloWorld.basics;

public class Problem
{
    public static void main()
    {
        int a = 2, b = 3;

        int aux = a;
        a = b;
        b = aux;

        Console.WriteLine("a: " + a + ", b: " + b);
    }

    private static void swap(int a, int b)
    {
        (a, b) = (b, a);
    }
}