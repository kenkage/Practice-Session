



/* This problem can be approached in two ways.
   1. Merge two sorted arrays and then find median.

		Time Complexity: O(m + n)
		•	We must iterate through both arrays to merge them, which violates the O(log(m + n)) constraint.
		•	Space Complexity: O(m + n)
		•	We need extra space for the merged array.

   2. Binary Search

		Instead of merging, we use binary search on the smaller array.
		•	Time Complexity: O(log(min(m, n)))
		•	Much faster than O(m + n).
		•	Space Complexity: O(1)
		•	No extra storage required.

*/
using System;
namespace test.Searching
{
	public class MedianOf2SortedArray
	{
		static void Main()
		{
			int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int m = arr[0], n = arr[1];

			int[] nums1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int[] nums2  = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

			int[] merged = MergeSortedArray(nums1, nums1.Length, nums2, nums2.Length);
			FindMedian(merged);
        }

        private static void FindMedian(int[] merged)
        {
            throw new NotImplementedException();
        }

        static int[] MergeSortedArray(int[] nums1, int n1, int[] nums2, int n2)
		{
			int[] result = new int[n1 + n2];

			int i = 0, j = 0, k = 0;

			while(i<n1 && j < n2)
			{
				if (nums1[i] < nums2[j])
					result[k++] = nums1[i++];
				else
					result[k++] = nums2[j++];
			}

			while (i < n1)
				result[k++] = nums1[i++];

			while (j < n2)
				result[k++] = nums2[j++];

			return result;
		}
	}
}

