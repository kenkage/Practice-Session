/*
 * https://leetcode.com/problems/unique-paths-ii/
 */

using System;
namespace test.DynamicProgramming
{
	public class UniquePath2
	{
		//static void Main()
		//{
  //          string[] parts = Console.ReadLine().Split(' ');
  //          int m = int.Parse(parts[0]);
  //          int n = int.Parse(parts[1]);

  //          int[,] grid = new int[m, n];

  //          for (int i = 0; i < m; i++)
  //          {
  //              string[] inputRow = Console.ReadLine().Split(' ');

  //              for (int j = 0; j < n; j++)
  //              {
  //                  grid[i, j] = int.Parse(inputRow[j]);
  //              }
  //          }

  //          int res = uniquePath2(grid);
  //          Console.WriteLine(res);
            //RecursiveUniquePathSol recursiveSol = new RecursiveUniquePathSol();
            //int res1 = recursiveSol.UniquePathRec(m, n, grid);
            //Console.WriteLine(res1);

        //}

        static int uniquePath(int[,] obstacleGrid)
        {
            var rowLenght = obstacleGrid.GetLength(0);
            var columnLenght = obstacleGrid.GetLength(1);

            if (rowLenght <= columnLenght)
            {
                int[] possiblePath = new int[rowLenght];
                possiblePath[0] = obstacleGrid[0, 0] == 0 ? 1 : 0;

                for (int i = 0; i < columnLenght; i++)
                    for (int j = 0; j < rowLenght; j++)
                        possiblePath[j] = obstacleGrid[j, i] == 1 ? 0 : j != 0 ? possiblePath[j - 1] + possiblePath[j] : possiblePath[j];

                return possiblePath[rowLenght - 1];
            }
            else
            {
                int[] possiblePath = new int[columnLenght];
                possiblePath[0] = obstacleGrid[0, 0] == 0 ? 1 : 0;

                for (int i = 0; i < rowLenght; i++)
                    for (int j = 0; j < columnLenght; j++)
                        possiblePath[j] = obstacleGrid[i, j] == 1 ? 0 : j != 0 ? possiblePath[j - 1] + possiblePath[j] : possiblePath[j];

                return possiblePath[columnLenght - 1];
            }
        }

        static int uniquePath2(int[,] obstacleGrid)
        {
            int rowLength = obstacleGrid.GetLength(0);
            int columnLength = obstacleGrid.GetLength(1);

            if (obstacleGrid[0, 0] == 1)
            {
                return 0;
            }

            int[,] dp = new int[rowLength, columnLength];
            dp[0, 0] = 1;

            for (int i = 1; i < columnLength; i++)
            {
                dp[0, i] = (obstacleGrid[0, i] == 0 && dp[0, i - 1] == 1) ? 1 : 0;
            }

            for (int i = 1; i < rowLength; i++)
            {
                dp[i, 0] = (obstacleGrid[i, 0] == 0 && dp[i - 1, 0] == 1) ? 1 : 0;
            }

            for (int i = 1; i < rowLength; i++)
            {
                for (int j = 1; j < columnLength; j++)
                {
                    dp[i, j] = obstacleGrid[i, j] == 0 ? dp[i - 1, j] + dp[i, j - 1] : 0;
                }
            }
            return dp[rowLength - 1, columnLength - 1];
        }

        public class RecursiveUniquePathSol
        {
            int[,] memo;
            public int UniquePathRec(int m, int n, int[,] grid)
            {
                memo = new int[m + 1, n + 1];
                return helper(m, n, grid);
            }

            int helper(int m ,int n, int[,] grid)
            {
                if(m == 1 || n == 1)
                {
                    memo[m, n] = 1;
                    return 1;
                }
                if(memo[m,n] != 0)
                {
                    return memo[m, n];
                }
                if (grid[m-1,n-1] == 0)
                {
                    memo[m, n] = helper(m - 1, n, grid) + helper(m, n - 1, grid);
                }
                return memo[m, n];
            }
        }

        
    }
}

