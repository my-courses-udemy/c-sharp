namespace HelloWorld.collections;

public class ListExample
{
    public static void main()
    {
        List<string> friends = new List<string>() { "Frank", "Joe", "John" };
        friends.ForEach(s => Console.WriteLine(s));
        friends.ForEach(Console.WriteLine);
        //! Streams
        Console.WriteLine("==========================");
        var friendsWhere = friends
            .Where(st => st.Length > 3)
            .Select(s => s.Length);
        foreach (var s in friendsWhere)
        {
            Console.WriteLine(s);
        }
    }
}