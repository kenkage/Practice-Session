using System;
namespace test.Arrays
{
    public class RohanLoves0_2_
    {
        static void FindBalancedIndexes(int[] nums)
        {
            int n = nums.Length;
            int totalSum = 0, prefixSum = 0;
            List<int> result = new List<int>();

            // Compute total sum of the array
            foreach (int num in nums)
                totalSum += num;

            // Iterate and check when prefixSum == suffixSum
            for (int i = 0; i < n; i++)
            {
                int suffixSum = totalSum - prefixSum - nums[i];

                if (prefixSum == suffixSum)
                    result.Add(i);

                prefixSum += nums[i]; // Update prefix sum
            }

            // Print result or -1 if no index found
            if (result.Count == 0)
                Console.WriteLine("-1");
            else
                Console.WriteLine(string.Join(" ", result));
        }

        static void Main()
        {
            // Read input
            Console.WriteLine("Enter the size of the array:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the array elements:");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            // Call function to find balanced indexes
            FindBalancedIndexes(nums);
        }
    }
}

