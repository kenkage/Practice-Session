using System;
namespace test.Sorting
{
    class CombineBooks
    {
        static void Main()
        {
            // Read input sizes
            string[] sizes = Console.ReadLine().Split();
            int n = int.Parse(sizes[0]);
            int m = int.Parse(sizes[1]);

            // Read book inventories
            string[] alaraBooks = Console.ReadLine().Split();
            string[] balinBooks = Console.ReadLine().Split();

            // Merge the two arrays
            string[] mergedBooks = new string[n + m];
            Array.Copy(alaraBooks, 0, mergedBooks, 0, n);
            Array.Copy(balinBooks, 0, mergedBooks, n, m);

            // Sort the merged array using Merge Sort
            MergeSort(mergedBooks, 0, mergedBooks.Length - 1);

            // Print sorted book list
            Console.WriteLine(string.Join(" ", mergedBooks));
        }

        // Merge Sort function
        static void MergeSort(string[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                // Recursively sort left and right halves
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                // Merge the sorted halves
                Merge(arr, left, mid, right);
            }
        }

        // Merge function to merge two sorted halves
        static void Merge(string[] arr, int left, int mid, int right)
        {
            int leftSize = mid - left + 1;
            int rightSize = right - mid;

            string[] leftArray = new string[leftSize];
            string[] rightArray = new string[rightSize];

            // Copy data to temporary arrays
            for (int i = 0; i < leftSize; i++)
                leftArray[i] = arr[left + i];
            for (int j = 0; j < rightSize; j++)
                rightArray[j] = arr[mid + 1 + j];

            int iLeft = 0, iRight = 0, mergedIndex = left;

            // Merge sorted subarrays
            while (iLeft < leftSize && iRight < rightSize)
            {
                if (string.Compare(leftArray[iLeft], rightArray[iRight]) <= 0)
                    arr[mergedIndex++] = leftArray[iLeft++];
                else
                    arr[mergedIndex++] = rightArray[iRight++];
            }

            // add remaining elements
            while (iLeft < leftSize)
                arr[mergedIndex++] = leftArray[iLeft++];
            while (iRight < rightSize)
                arr[mergedIndex++] = rightArray[iRight++];
        }
    }
}

