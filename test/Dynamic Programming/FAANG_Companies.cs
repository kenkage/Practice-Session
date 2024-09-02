using System;
namespace test
{
	public class FAANG_Companies
	{
		//static void Main()
		//{
  //          int N = int.Parse(Console.ReadLine());
  //          int[][] merits = new int[N][];

  //          for (int i = 0; i < N; i++)
  //          {
  //              merits[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
  //          }

  //          int res = MaxMeritPoints(merits);
  //          Console.WriteLine(res);
  //      }

		static int MaxMeritPoints(int[][] merits)
		{
            int n = merits.Length;
            int[,] dp = new int[n, 3];

            // Base case: Fill in the first day's merit points
            dp[0, 0] = merits[0][0];
            dp[0, 1] = merits[0][1];
            dp[0, 2] = merits[0][2];

            for(int i = 1; i<n; i++)
            {
                dp[i, 0] = merits[i][0] + Math.Max(dp[i - 1, 1], dp[i - 1, 2]);
                dp[i, 1] = merits[i][1] + Math.Max(dp[i - 1, 0], dp[i - 1, 2]);
                dp[i, 2] = merits[i][2] + Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
            }

            return Math.Max(dp[n - 1, 0], Math.Max(dp[n - 1, 1], dp[n - 1, 2]));
        }

    }
}

