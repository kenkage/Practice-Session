using System;
namespace test.Searching
{
	public class SmallestDivisorSolution
	{
        static int SmallestDivisor(int[] nums, int limit)
        {
            int low = 1, high = nums[0];

            // Find the max element in nums
            foreach (int num in nums)
                high = Math.Max(high, num);

            int result = high;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int sum = GetSum(nums, mid);

                if (sum <= limit)
                {
                    result = mid;  // Update best divisor
                    high = mid - 1; // Try smaller divisor
                }
                else
                {
                    low = mid + 1; // Increase divisor to reduce sum
                }
            }
            return result;
        }

        static int GetSum(int[] nums, int divisor)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += (num + divisor - 1) / divisor; // Equivalent to Math.Ceiling(num / divisor)
            }
            return sum;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int limit = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestDivisor(nums, limit));
        }
    }
}

