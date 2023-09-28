using System.Collections;

namespace HelloWorld.collections;

public class ArrayListExample
{
    public static void main()
    {
        //! with undefined objects
        ArrayList arrayList = new ArrayList();
        //! with defined objects
        int size = 2;
        ArrayList arrayList2 = new ArrayList(size);

        //! It can store any kind of object
        arrayList.Add(3);
        arrayList.Add("string");
        arrayList.Add(true);
        arrayList.Add(12.23);
        arrayList.Add(13);
        arrayList.Add(23);
        arrayList.Add(3);

        //! delete element with specific value from the arraylist (first occurrence)
        arrayList.Remove(13);

        //! remove specific index
        arrayList.RemoveAt(0);

        int sum = 0;
        foreach (var value in arrayList)
        {
            if (value is int)
            {
                // sum += Convert.ToInt32(value);
                sum += (int)value;
            }
        }

        Console.WriteLine("Sum: " + sum);
    }
}