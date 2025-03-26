using System;
using System.Linq;

namespace test.Searching
{
	public class MaximumSweetness
	{
        static bool CanPickToffees(int[] prices, int k, int minDiff)
        {
            int count = 1; // Pick the first toffee
            int lastPicked = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] - lastPicked >= minDiff)
                {
                    count++;
                    lastPicked = prices[i];

                    if (count == k) return true; // Successfully picked k toffees
                }
            }
            return false;
        }

        static int MaxSweetness(int[] prices, int k)
        {
            Array.Sort(prices); // Sort prices

            int low = 1, high = prices[^1] - prices[0]; // Max possible range
            int maxSweetness = 0;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (CanPickToffees(prices, k, mid))
                {
                    maxSweetness = mid; // Store the best possible sweetness
                    low = mid + 1; // Try for a larger minimum difference
                }
                else
                {
                    high = mid - 1; // Reduce the difference
                }
            }

            return maxSweetness;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(MaxSweetness(prices, k));
        }
    }
}

