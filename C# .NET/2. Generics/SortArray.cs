namespace _2._Generics;

public class SortArray<T> where T : IComparable<T>
{
    public void BubbleSort(T[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
                // if (Comparer<T>.Default.Compare(arr[j], arr[j + 1]) > 0)
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
        }
    }
}