/*
 * Getting in faang companies
A learner at heycoach wants to grab a job in a faang companies, so he start following a schedule ( learning DSA, Practising questions and learning cs fundamentals ), Each day he performs one of these three activities and he can’t perform the same activity on two consecutive days. Each activity has some merit points on each day. These merit points will decide weather he is eligible to get into a faang company or not. Learner wants to improve everything to get a good job as early as possible. Can you help the learner in finding out the maximum merit point he can earn ?

Input Format:

The first line contains a single integer 'n' denoting the number of days.

The next 'n' lines contains three space separated integers denoting the merit values of each of the three activities on that day.

Output Format:

Return the maximum amount of merit points achievable.

Example

Input :

3

1 2 5 

3 1 1

3 3 3

Output : 11
Contraints:

1 <= N <= 10000

1 <= Value of PointsArray <= 100
 */

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

