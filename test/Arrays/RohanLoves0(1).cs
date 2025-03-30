using System;
namespace test.Arrays
{
	public class RohanLoves0_1_
	{
        static bool HasZeroSumSubarray(int[] nums)
        {
            HashSet<int> prefixSums = new HashSet<int>();
            int prefixSum = 0;

            foreach (int num in nums)
            {
                prefixSum += num;

                // If prefix sum is 0 or is repeated, subarray exists
                if (prefixSum == 0 || prefixSums.Contains(prefixSum))
                    return true;

                // Store the prefix sum
                prefixSums.Add(prefixSum);
            }

            return false;
        }

        //static void Main()
        //{
        //    Console.WriteLine("Enter the size of the array:");
        //    int n = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Enter the array elements:");
        //    int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    Console.WriteLine(HasZeroSumSubarray(nums) ? "Yes" : "No");
        //}
    }
}

