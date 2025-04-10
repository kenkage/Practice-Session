using System;

// https://www.youtube.com/watch?v=bUSaenttI24&t=1341s
namespace test.DynamicProgramming
{
	public class __1Knapsack
	{
        //public static void Main()
        //{
        //    // Input
        //    string[] line1 = Console.ReadLine().Split();
        //    int n = int.Parse(line1[0]);
        //    int W = int.Parse(line1[1]);

        //    int[] weights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        //    int[] values = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    // Output
        //    Console.WriteLine(SolveKnapsack(weights, values, n, W));
        //}

        static int SolveKnapsack(int[] wts, int[] vals, int n, int cap)
        {
            int[,] dp = new int[n + 1, cap + 1];
            for(int i = 1; i <= n; i++)
            {
                for(int j = 0; j <= cap ; j++)
                {
                    if(j >= wts[i - 1])
                    {
                        int rCap = j - wts[i - 1];
                        if (dp[i - 1, rCap] + vals[i - 1] > dp[i - 1, j])
                        {
                            dp[i, j] = dp[i - 1, rCap] + vals[i - 1]; // when i bats
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j]; // when i doesn't bat
                        }
                        // dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, rCap] + vals[i - 1]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j]; // when i doesn't bat
                    }
                }
            }
            return dp[n, cap];
        }
    }
}

