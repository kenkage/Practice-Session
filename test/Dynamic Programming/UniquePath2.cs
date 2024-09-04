/*
 * https://leetcode.com/problems/unique-paths-ii/
 */

using System;
namespace test.DynamicProgramming
{
	public class UniquePath2
	{
		static void Main()
		{
            string[] parts = Console.ReadLine().Split(' ');
            int m = int.Parse(parts[0]);
            int n = int.Parse(parts[1]);

            int[,] grid = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                string[] inputRow = Console.ReadLine().Split(' ');

                for (int j = 0; j < n; j++)
                {
                    grid[i, j] = int.Parse(inputRow[j]);
                }
            }

            int res = uniquePath(grid);
            Console.WriteLine(res);
            //RecursiveUniquePathSol recursiveSol = new RecursiveUniquePathSol();
            //int res1 = recursiveSol.UniquePathRec(m, n, grid);
            //Console.WriteLine(res1);

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
    }
}

