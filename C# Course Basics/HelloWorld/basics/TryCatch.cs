namespace HelloWorld.basics;

public class TryCatch
{
    static void main(string[] args)
    {
        string input = Console.ReadLine();

        try
        {
            int parse = int.Parse(input);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.GetType().Name);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.GetType().Name);
        }
        finally
        {
            Console.WriteLine("Called finally");
        }
    }
}