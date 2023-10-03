using static System.DateTime;

namespace Delegate;

public class ClassDelegate
{
    public void LogtextToString(string message)
    {
        Console.WriteLine($"{Now}: {message}");
    }

    public void LogTextToFile(string message)
    {
        File.AppendAllText("log.txt", $"{Now}: {message}\n");
    }
}