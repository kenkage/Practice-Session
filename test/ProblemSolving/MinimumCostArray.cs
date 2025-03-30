using System;
namespace test.ProblemSolving
{
	public class MinimumCostArray
	{
        public static int MinCostToDivideArray(int[] nums)
        {
            int n = nums.Length;
            int minSum = int.MaxValue;

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int cost1 = nums[0];
                    int cost2 = nums[i];
                    int cost3 = nums[j];

                    minSum = Math.Min(minSum, cost1 + cost2 + cost3);
                }
            }

            return minSum;
        }

        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        //    Console.WriteLine(MinCostToDivideArray(nums));
        //}
    }
}

