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

