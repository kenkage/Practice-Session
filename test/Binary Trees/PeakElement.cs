using System;
namespace test.BinaryTrees
{
	public class PeakElement
	{
        static int FindPeakElement(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[mid + 1])
                    right = mid; // Move left if mid is a peak candidate
                else
                    left = mid + 1; // Move right otherwise
            }
            return left; // The peak index
        }

        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        //    Console.WriteLine(FindPeakElement(nums));
        //}
    }
}

