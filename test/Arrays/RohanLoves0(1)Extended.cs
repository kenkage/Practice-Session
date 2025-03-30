using System;
namespace test.Arrays
{
	public class RohanLoves0_1_Extended
	{
        static void FindZeroSumSubarrays(int[] nums)
        {
            Dictionary<int, List<int>> prefixSumMap = new Dictionary<int, List<int>>();
            int prefixSum = 0;
            bool found = false;

            // To handle the case where prefixSum itself becomes zero
            prefixSumMap[0] = new List<int> { -1 };

            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];

                // If prefix sum is seen before, subarrays exist
                if (prefixSumMap.ContainsKey(prefixSum))
                {
                    foreach (int startIdx in prefixSumMap[prefixSum])
                    {
                        Console.WriteLine($"Subarray with sum 0 found: [{startIdx + 1}, {i}]");
                    }
                    found = true;
                }

                // Add current prefixSum to the map
                if (!prefixSumMap.ContainsKey(prefixSum))
                    prefixSumMap[prefixSum] = new List<int>();

                prefixSumMap[prefixSum].Add(i);
            }

            if (!found)
                Console.WriteLine("No subarray with sum 0 found.");
        }

        //static void Main()
        //{
        //    Console.WriteLine("Enter the size of the array:");
        //    int n = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Enter the array elements:");
        //    int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    FindZeroSumSubarrays(nums);
        //}
    }
}

