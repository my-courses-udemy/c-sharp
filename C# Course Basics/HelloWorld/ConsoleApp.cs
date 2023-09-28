using System.Runtime.CompilerServices;
using HelloWorld.classes;
using HelloWorld.collections;
using HelloWorld.members;
using HelloWorld.properties;

namespace HelloWorld;

public class ConsoleApp
{
    static void Main()
    {
        //! Instance of human
        Human denis = new Human("zeze", "zeze", 2);
        denis.IntroduceMyself();

        Box box = new Box();
        box.Height = 2;
        box.Length = 2;
        Console.WriteLine(box.Length);
        box.DisplayInfo();

        Members members1 = new Members();
        Members members2 = new Members();
        Console.WriteLine(members1.ToString());
        ArrayListExample.main();
        ListExample.main();
    }
}