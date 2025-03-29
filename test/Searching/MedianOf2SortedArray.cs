



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

Ref: https://www.youtube.com/watch?v=jDJuW7tSxio

*/
using System;
namespace test.Searching
{
	public class MedianOf2SortedArray
	{
		//static void Main()
		//{
		//	int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
		//	int m = arr[0], n = arr[1];

		//	int[] nums1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
		//	int[] nums2  = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

  //          Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
  //      }

        private static int FindMedianSortedArrays(int[] a, int[] b)
        {
            // Ensure nums1 is the smaller array
            if (a.Length > b.Length)
			{
				//return	FindMedianSortedArrays(b, a);
				int[] temp = a;
				a = b;
				b = temp;

			}

			int lo = 0, hi = a.Length, te = a.Length + b.Length;
			
			while(lo <= hi)
			{
                int aLeft = (lo + hi) / 2;
                int bLeft = (te + 1) / 2 - aLeft;
				int alm1 = (aLeft == 0) ? int.MinValue : a[aLeft - 1];
				int al = (aLeft == a.Length) ? int.MaxValue : a[aLeft];
				int blm1 = (bLeft == 0) ? int.MinValue : b[bLeft - 1];
				int bl = (bLeft == b.Length) ? int.MaxValue : b[bLeft];

                if (alm1 <= bl && blm1 <= al) //Valid Scenario
				{
					int median;
					if (te % 2 == 0)
					{
                        int lMax = Math.Max(alm1, blm1);
                        int rMin = Math.Min(al, bl);
						median = (lMax + rMin) / 2;
                    } else
					{
						int lMax = Math.Max(alm1, blm1);
						median = lMax;
					}
					return median;
				}
				else if (alm1 > bl)
				{ //there're more elements to be picked in left part 'b' array and to do that automatically we'll reduce the hi of 'a' array
					hi = aLeft - 1;
				}
				else if (blm1 > al)
				{ // there're more elements to be picked in left part of 'a' array and to do that automatically we'll increase the low of 'a' array
					lo = aLeft + 1;
				}
            }
            return -1;
        }
    }
}

