using System;
namespace test.Sorting
{
	public class CombineBooks2
	{
        //static void Main()
        //{
        //    // Read input
        //    string[] sizes = Console.ReadLine().Split();
        //    int n = int.Parse(sizes[0]);
        //    int m = int.Parse(sizes[1]);

        //    string[] alara = Console.ReadLine().Split();
        //    string[] balin = Console.ReadLine().Split();

        //    // Merge the two sorted lists
        //    string[] merged = MergeSortedArrays(alara, balin, n, m);

        //    // Print the merged result
        //    Console.WriteLine(string.Join(" ", merged));
        //}

        static string[] MergeSortedArrays(string[] arr1, string[] arr2, int n, int m)
        {
            string[] result = new string[n + m];
            int i = 0, j = 0, k = 0;

            while (i < n && j < m)
            {
                if (string.Compare(arr1[i], arr2[j]) <= 0)
                    result[k++] = arr1[i++];
                else
                    result[k++] = arr2[j++];
            }

            while (i < n)
                result[k++] = arr1[i++];

            while (j < m)
                result[k++] = arr2[j++];

            return result;
        }
    }
}

