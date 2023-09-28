namespace HelloWorld.basics;

public class Input
{
    static void main(string[] args)
    {
        string? line = Console.ReadLine();
        Console.WriteLine(line);
        Console.WriteLine(Calculate());
    }

    static int Calculate()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();
        return int.Parse(first) * int.Parse(second);
    }
}