using System;
namespace test.Sets
{
	public class LongestSubarray
	{
        static int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> prefixMap = new Dictionary<int, int>();
            int maxLength = 0, prefixSum = 0;

            // Initialize with prefixSum 0 at index -1
            prefixMap[0] = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                // Convert 0 to -1
                prefixSum += (nums[i] == 0) ? -1 : 1;

                // If the prefixSum has been seen before, update maxLength
                if (prefixMap.ContainsKey(prefixSum))
                {
                    maxLength = Math.Max(maxLength, i - prefixMap[prefixSum]);
                }
                else
                {
                    // Store the first occurrence of this prefix sum
                    prefixMap[prefixSum] = i;
                }
            }
            return maxLength;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(FindMaxLength(nums));
        }
    }
}

