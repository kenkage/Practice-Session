using System;
namespace test.DynamicProgramming
{
	public class PartitionWithGivenDifference
	{
        static int MOD = 1000000007;

        public static int CountPartitions(int[] arr, int d)
        {
            int totalSum = 0;
            foreach (var num in arr) totalSum += num;

            if ((totalSum - d) < 0 || (totalSum - d) % 2 != 0)
                return 0;

            int target = (totalSum - d) / 2;

            return CountSubsetsWithSum(arr, target);
        }

        static int CountSubsetsWithSum(int[] arr, int target) // ref: https://www.youtube.com/watch?v=tRpkluGqINc
        {
            int n = arr.Length;
            int[,] dp = new int[n + 1, target + 1];

            dp[0, 0] = 1; // Base case: one way to make 0 sum with 0 elements

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    // exclude current
                    dp[i, j] = dp[i - 1, j];

                    // include current if it doesn't exceed current sum
                    if (j >= arr[i - 1])
                        dp[i, j] = (dp[i, j] + dp[i - 1, j - arr[i - 1]]) % MOD;
                }
            }

            return dp[n, target];
        }

        //static void Main(string[] args)
        //{
        //    // Read inputs
        //    string[] nm = Console.ReadLine().Split();
        //    int n = int.Parse(nm[0]);
        //    int d = int.Parse(nm[1]);

        //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    int result = CountPartitions(arr, d);
        //    Console.WriteLine(result);
        //}
    } 
}
/*
 * sum(A) + sum(B) = totalSum
 * sum(A) - sum(B) = d
 * 2sum(B) = totalSum - d
 * sum(B) = (totalSum - d)/2
 * 
 * So, the problem reduces to counting the number of subsets with sum = (totalSum - d)/2
 * Only if (totalSum - d) is even and non-negative
 */