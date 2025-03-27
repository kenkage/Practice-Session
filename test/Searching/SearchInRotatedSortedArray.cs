using System;
namespace test.Searching
{
	public class SearchInRotatedSortedArray
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        //    int target = int.Parse(Console.ReadLine());

        //    Console.WriteLine(SearchInRotatedSortedArrays(nums, target));
        //}

        private static int SearchInRotatedSortedArrays(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while(left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                // Check which half is sorted
                if (nums[left] <= nums[mid]) // Left half is sorted
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1; // Search in left half
                    else
                        left = mid + 1; // Search in right half
                } else //Right half is sorted
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1; // Search in Right half
                    else
                        right = mid - 1; // Search in left half
                }
            }
            return -1; // Target Not found
        }
    }
}

