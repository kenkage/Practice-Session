/*
 * MIN TAX PAID_II
Given a n x n grid filled with non-negative numbers,
A explorer is at top left cell and he has to find a path from top left to bottom right,
but there is a condition he has to pay an amount equal to the cell if he choose to include a particular cell in his path,
suggest a falling path which minimizes the money paid by the explorer. The explorer can move down, right or diagonally down.

Example

Input:

3 3
1 2 3
4 5 6
7 8 9
Output:

15

Explanation:

The explorer will start from matrix[0][0] that is from 1 then move to 5 then finally to 9 which is at matrix[n-1][n-1]. The total cost is 16 which is the minimum possible achievable.

Constraints:

n == matrix.length == matrix[i].length

1 <= n <= 100

-100 <= matrix[i][j] <= 100
 */

using System;
namespace test
{
	public class MinTaxPaid_II
	{

		//static void Main() {

  //          Console.WriteLine("Enter the size of the grid (n):");
  //          //int n = int.Parse(Console.ReadLine());
  //          string [] parts = Console.ReadLine().Split(' ');
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

  //          int result = MinPathSum(grid, n);
  //          Console.WriteLine("The minimum sum path is: " + result);
  //      }

        static int MinPathSum(int[,] grid, int n)
        {
            int[,] dp = new int[n, n];

            dp[0, 0] = grid[0, 0];

            for (int i = 1; i < n; i++)
            {
                dp[0, i] = dp[0, i - 1] + grid[0, i]; // Moving right
                dp[i, 0] = dp[i - 1, 0] + grid[i, 0]; // Moving down
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int minPreviousCell = Math.Min(dp[i - 1, j], dp[i, j - 1]); // Down/Right
                    if (i > 0 && j > 0)
                    {
                        minPreviousCell = Math.Min(minPreviousCell, dp[i - 1, j - 1]); // Diagonally down
                    }

                    dp[i, j] = minPreviousCell + grid[i, j];
                }
            }

            return dp[n - 1, n - 1];
        }
    }
}

