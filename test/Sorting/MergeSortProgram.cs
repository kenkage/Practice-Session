using System;
using System.Linq;

class MergeSortProgram
{
    // Merge function to merge two sorted subarrays
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        // Copy data to temp arrays
        Array.Copy(arr, left, leftArr, 0, n1);
        Array.Copy(arr, mid + 1, rightArr, 0, n2);

        //for (int i1 = 0; i1 < n1; i1++)
        //    leftArr[i1] = arr[left + i1];

        //for (int j1 = 0; j1 < n2; j1++)
        //    rightArr[j1] = arr[mid + 1 + j1];

        int i = 0, j = 0, k = left;

        // Merge the temp arrays back into arr[left...right]
        while (i < n1 && j < n2)
        {
            if (leftArr[i] <= rightArr[j])
                arr[k++] = leftArr[i++];
            else
                arr[k++] = rightArr[j++];
        }

        // Copy remaining elements of leftArr (if any)
        while (i < n1)
            arr[k++] = leftArr[i++];

        // Copy remaining elements of rightArr (if any)
        while (j < n2)
            arr[k++] = rightArr[j++];
    }

    // Merge Sort function
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    //static void Main()
    //{
    //    // Read input
    //    int n = int.Parse(Console.ReadLine());
    //    int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

    //    // Apply merge sort
    //    MergeSort(arr, 0, n - 1);

    //    // Print sorted array
    //    Console.WriteLine(string.Join(" ", arr));
    //}
}