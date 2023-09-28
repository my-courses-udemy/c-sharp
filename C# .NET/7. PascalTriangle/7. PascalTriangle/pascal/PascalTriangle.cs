namespace _7._PascalTriangle.pascal;

public class PascalTriangle
{
    public int[][] CreateTriangle(int size)
    {
        if (size == 0)
        {
            var array = new[] { new[] { 1 } };
            printTriangle(array);
            return array;
        }

        int[][] triangle = new int[size][];

        InitializeTriangle(triangle);
        // printTriangle(triangle);

        for (int i = 2; i < triangle.Length; i++)
        {
            for (int j = 1; j < triangle[i].Length - 1; j++)
            {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }
        }

        printTriangle(triangle);
        return triangle;
    }

    private void InitializeTriangle(int[][] triangle)
    {
        int counter = 1;
        for (int i = 0; i < triangle.Length; i++)
        {
            triangle[i] = Enumerable.Repeat(1, counter++).ToArray();
        }
    }

    private void printTriangle(int[][] triangle)
    {
        foreach (var ints in triangle)
        {
            foreach (var value in ints)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
    }
}