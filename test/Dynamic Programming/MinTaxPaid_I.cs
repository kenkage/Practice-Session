/*
 * MIN TAX PAID_I
Given a m x n grid filled with non-negative numbers, A explorer is at top left cell and he has to find a path from top left to bottom right, but there is a condition he has to pay an amount equal to the cell if he choose to include a particular cell in his path, suggest a path which minimizes the money paid by the explorer

Example

Input: grid = [[1,3,1],[1,5,1],[4,2,1]]

Output: 7
Note: You can only move either down or right at any point in time.

Constraints:

m == grid.length

n == grid[i].length

1 <= m, n <= 200

0 <= grid[i][j] <= 200
 */

using System;
namespace test
{
	public class MinTaxPaid_I
	{
		//static void Main()
		//{
  //          Console.WriteLine("Enter the size of the grid (n):");
  //          //int n = int.Parse(Console.ReadLine());
  //          string[] parts = Console.ReadLine().Split(' ');
  //          int n = int.Parse(parts[0]);
  //          int m = int.Parse(parts[1]);


  //          int[,] grid = new int[n, n];

  //          Console.WriteLine("Enter the grid values row by row:");

  //          for (int i = 0; i < n; i++)
  //          {
  //              string[] inputRow = Console.ReadLine().Split(' ');

  //              for (int j = 0; j < n; j++)
  //              {
  //                  grid[i, j] = int.Parse(inputRow[j]);
  //              }
  //          }

  //          int result = MinPathSum(grid, n, m);
  //          Console.WriteLine("The minimum sum path is: " + result);
  //      }

        static int MinPathSum(int[,] grid, int n, int m)
        {
            int[,] dp = new int[n, m];

            dp[0, 0] = grid[0, 0];

            for (int i = 1; i < m; i++)
            {
                dp[0, i] = dp[0, i - 1] + grid[0, i]; // Moving right
            }
            for (int i = 1; i < n; i++)
            {

                dp[i, 0] = dp[i - 1, 0] + grid[i, 0]; // Moving down
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    int minPreviousCell = Math.Min(dp[i - 1, j], dp[i, j - 1]); // Down or Right

                    dp[i, j] = minPreviousCell + grid[i, j];
                }
            }

            return dp[n - 1, m - 1];
        }
    }
}

