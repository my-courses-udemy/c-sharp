using System.Text;

namespace _10._String_Manipulation;

public class StringBuilderExample
{
    public static void Example()
    {
        //! Builder helps to create a string without create a new string
        //! it use a buffer to create a string
        //! It is better when you need to create a string with a lot of concatenations
        //! The data is mutable
        var names = new StringBuilder("hello world");
        names[0] = 'H';
        names.Append(", other hello!!")
            .Append(", other greeting!!!")
            .AppendLine()
            .AppendFormat($"This is a format {2 + 2}")
            .AppendLine();
        var namesCapacity = names.Capacity;
        Console.WriteLine(names);
        Console.WriteLine($"Capacity: {namesCapacity}");
    }
}