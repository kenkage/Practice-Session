using System;
namespace test.DynamicProgramming
{
	public class MaxFallingPathSum2
	{
		static void Main()
		{
            int n = int.Parse(Console.ReadLine());
            int[][] grid = new int[n][];

            for (int i = 0; i < n; i++)
            {
                grid[i] = new int[n];
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    grid[i][j] = int.Parse(input[j]);
                }
            }
            int res = MaxFallingPathSum(grid);
            Console.WriteLine(res);
        }

        static int MaxFallingPathSum(int[][] grid)
        {
            int n = grid.Length;

            // Initialize prev row with the first row of the grid
            int[] prev = new int[n];
            for (int j = 0; j < n; j++)
            {
                prev[j] = grid[0][j];
            }

            // Traverse from the second row to the last row
            for (int i = 1; i < n; i++)
            {
                int[] curr = new int[n];
                int prevMax1 = int.MinValue, prevMax2 = int.MinValue;
                int prevMaxIndex = -1;

                // Find the max and second max from the previous row
                for (int j = 0; j < n; j++)
                {
                    if (prev[j] > prevMax1)
                    {
                        prevMax2 = prevMax1;
                        prevMax1 = prev[j];
                        prevMaxIndex = j;
                    }
                    else if (prev[j] > prevMax2)
                    {
                        prevMax2 = prev[j];
                    }
                }

                // Update current row values
                for (int j = 0; j < n; j++)
                {
                    if (j != prevMaxIndex)
                    {
                        curr[j] = grid[i][j] + prevMax1;
                    }
                    else
                    {
                        curr[j] = grid[i][j] + prevMax2;
                    }
                }

                // Move current row to previous row for the next iteration
                prev = curr;
            }

            // The result will be the maximum value in the last processed row (prev)
            int result = int.MinValue;
            for (int j = 0; j < n; j++)
            {
                result = Math.Max(result, prev[j]);
            }

            return result;
        }
    }
}

