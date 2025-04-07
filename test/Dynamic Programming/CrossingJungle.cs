using System;
namespace test.DynamicProgramming
{
	public class CrossingJungle
	{
        public static int MinimumStartingExp(int[,] grid, int n, int m)
        {
            int[,] dp = new int[n, m];

            // Start from bottom-right cell
            dp[n - 1, m - 1] = Math.Max(1, 1 - grid[n - 1, m - 1]);

            // Fill last row
            for (int j = m - 2; j >= 0; j--)
            {
                dp[n - 1, j] = Math.Max(1, dp[n - 1, j + 1] - grid[n - 1, j]);
            }

            // Fill last column
            for (int i = n - 2; i >= 0; i--)
            {
                dp[i, m - 1] = Math.Max(1, dp[i + 1, m - 1] - grid[i, m - 1]);
            }

            // Fill remaining cells
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = m - 2; j >= 0; j--)
                {
                    int minNext = Math.Min(dp[i + 1, j], dp[i, j + 1]);
                    dp[i, j] = Math.Max(1, minNext - grid[i, j]);
                }
            }

            // Since player must end with positive EXP, subtract 1 to get minimal X
            return dp[0, 0] - 1;
        }

        //static void Main()
        //{
        //    var inputs = Console.ReadLine().Split();
        //    int n = int.Parse(inputs[0]);
        //    int m = int.Parse(inputs[1]);

        //    int[,] grid = new int[n, m];

        //    for (int i = 0; i < n; i++)
        //    {
        //        var row = Console.ReadLine().Split();
        //        for (int j = 0; j < m; j++)
        //        {
        //            grid[i, j] = int.Parse(row[j]);
        //        }
        //    }

        //    int result = MinimumStartingExp(grid, n, m);
        //    Console.WriteLine(result);
        //}
    }
}

