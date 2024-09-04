/*
 * https://leetcode.com/problems/unique-paths/
 */

using System;
namespace test.DynamicProgramming
{
	public class UniquePath1
	{
        
		//static void Main()
		//{
  //          string[] parts = Console.ReadLine().Split(' ');
  //          int m = int.Parse(parts[0]);
		//	int n = int.Parse(parts[1]);

		//	//int res = UniquePath(m, n);
  //          //Console.WriteLine(res);

  //          RecursiveSol recursiveSol = new RecursiveSol();
  //          int res1 = recursiveSol.UniquePathRec(m, n);

  //          Console.WriteLine(res1);
  //      }

		static int UniquePath(int m, int n)
		{
            int[,] dp = new int[m, n];
			dp[0, 0] = 0;
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }

            for(int i=1; i<m; i++)
            {
                for(int j=1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }
    }

    public class RecursiveSol
    {
        int[,] memo;
        public int UniquePathRec(int m, int n)
        {
            memo = new int[m + 1, n + 1];
            return helper(m, n);
        }

        int helper(int m, int n)
        {
            if (n == 1 || m == 1)
            {
                memo[m, n] = 1;
                return 1;
            }
            if (memo[m, n] != 0)
            {
                return memo[m, n];
            }
            memo[m, n] = helper(m - 1, n) + helper(m, n - 1);
            return memo[m, n];
        }
    }
}

