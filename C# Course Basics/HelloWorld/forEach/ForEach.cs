namespace HelloWorld.forEach;

public class ForEach
{
    public static void main()
    {
        int[] array = { 1, 2, 3 };
        int[] aray2 = new int[2];
        aray2[0] = 1;
        aray2[1] = 1;

        foreach (var value in array)
        {
            Console.WriteLine(value);
        }
    }
}