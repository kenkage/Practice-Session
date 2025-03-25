using System;
namespace test.Sorting
{
	public class CombineBooks
	{
        //static void Main()
        //{
        //    string[] sizes = Console.ReadLine().Split();
        //    int n = int.Parse(sizes[0]);
        //    int m = int.Parse(sizes[1]);

        //    string[] alaraBooks = Console.ReadLine().Split();
        //    string[] balinBooks = Console.ReadLine().Split();

        //    string[] mergedBooks = new string[n + m];
        //    Array.Copy(alaraBooks, 0, mergedBooks, 0, n);
        //    Array.Copy(balinBooks, 0, mergedBooks, n, m);

        //    // Sort the merged array using Merge Sort
        //    MergeSort(mergedBooks, 0, mergedBooks.Length - 1);

        //    // Print sorted book list
        //    Console.WriteLine(string.Join(" ", mergedBooks));
        //}

        private static void MergeSort(string[] mergedBooks, int left, int right)
        {
            if(left < right)
            {
                int mid = left + (right = left) / 2;
                MergeSort(mergedBooks, left, mid);
                MergeSort(mergedBooks, mid + 1, right);

                Merge(mergedBooks, left, mid, right);
            }
        }

        private static void Merge(string[] mergedBooks, int left, int mid, int right)
        {
            
        }
    }
}

