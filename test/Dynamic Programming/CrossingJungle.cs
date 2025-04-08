using System;
namespace test.DynamicProgramming
{
	public class CrossingJungle
	{
        public static int MinimumStartingExp(int[,] grid, int n, int m, int x=0, int y=0)
        {
            if(x == n-1 || y == m - 1)
            {
                return grid[x, y];
            }
            if (x >= n || y >= m)
            {
                return 0;
            }
            int right = MinimumStartingExp(grid, n, m, x + 1, y) + grid[x, y];
            int down = MinimumStartingExp(grid, n, m, x, y + 1) + grid[x, y];
            int max = Math.Max(right, down);

            return 1 - max;
        }

        // Tabulation
        public static int Solve(int[,] grid, int n, int m)
        {
            int[,] dp = new int[n, m];
            dp[0, 0] = grid[0, 0];
            for(int i = 1; i < n; i++)
            {
                dp[i, 0] = grid[i, 0] + grid[i - 1, 0]; // populating first column of dp array
            }
            for (int i = 1; i < m; i++)
            {
                dp[0, i] = grid[0, i] + grid[0, i - 1]; // populating first row of dp array
            }
            for(int i=1; i < n; i++)
            {
                for(int j=1; j < m; j++)
                {
                    dp[i, j] = Math.Max(grid[i - 1, j], grid[i, j - 1]) + grid[i, j];
                }
            }

            return 1 - dp[n - 1, m - 1];
        }

        static void Main()
        {
            var inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);

            int[,] grid = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    grid[i, j] = int.Parse(row[j]);
                }
            }

            int result = Solve(grid, n, m);
            Console.WriteLine(result);
        }
    }
}

