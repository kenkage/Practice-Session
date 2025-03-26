using System;
namespace test.Sorting
{
	public class SpecialPairs
	{
        static long specialPairs = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            MergeSort(scores, 0, n - 1);

            Console.WriteLine(specialPairs);
        }

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

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            for (int i = 0; i < n1; i++)
                leftArr[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                rightArr[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, kIndex = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (leftArr[iIndex] <= rightArr[jIndex])
                    arr[kIndex++] = leftArr[iIndex++];
                else
                {
                    arr[kIndex++] = rightArr[jIndex++];
                    specialPairs += (n1 - iIndex); // Count inversions, // All remaining elements in leftArr will form special pairs

                }
            }

            while (iIndex < n1)
                arr[kIndex++] = leftArr[iIndex++];

            while (jIndex < n2)
                arr[kIndex++] = rightArr[jIndex++];
        }
    }
}

