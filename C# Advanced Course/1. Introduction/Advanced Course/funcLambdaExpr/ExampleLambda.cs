namespace Advanced_Course.funcLambdaExpr;

public class ExampleLambda
{
    public static void main()
    {
        Func<string, string> selector = str => str.ToUpper();
        var result = selector.Invoke("hello");
        Console.WriteLine(result);
    }
}