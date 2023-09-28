namespace HelloWorld.arrays;

public class JaggedArrays
{
    static void main()
    {
        int[][] jaggedArray = new int[4][];
        jaggedArray[0] = new int[5];
        jaggedArray[1] = new int[1];
        jaggedArray[2] = new int[3];

        jaggedArray[3] = new[] { 1, 2, 3, 45 };

        int[][] jaggedArray2 = {
            new[] { 1, 2, 3 },
            new[] { 1, 2 },
            new[] { 1, 2, 3 }
        };
    }
}