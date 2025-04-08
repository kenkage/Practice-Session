using System;
namespace test.DynamicProgramming
{
	public class EggDrop
	{
        //public static void Main()
        //{
        //    int t = int.Parse(Console.ReadLine());
        //    for (int test = 0; test < t; test++)
        //    {
        //        var input = Console.ReadLine().Split();
        //        int eggs = int.Parse(input[0]);
        //        int floors = int.Parse(input[1]);

        //        Console.WriteLine(MinMoves(eggs, floors));
        //    }
        //}

        private static int MinMoves(int n, int k)
        {
            int[,] dp = new int[n + 1, k + 1];
            for(int i=1; i <= n; i++) // loop for eggs
            {
                for(int j=1; j <= k; j++) // loop for floors
                {
                    if (i == 1) // if there is 1 egg
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 1)
                    {
                        dp[i, j] = 1;
                    }
                    else
                    {
                        int min = int.MaxValue;
                        for(int mj = j-1, pj = 0; mj>=0; mj--, pj++)
                        {
                            int v1 = dp[i, mj]; // egg survives
                            int v2 = dp[i - 1, pj]; // egg breaks.. because we're taking i-1, and i represnts for eggs
                            int val = Math.Max(v1, v2);
                            min = Math.Min(val, min);
                        }
                        dp[i, j] = min + 1;
                    }
                }
            }
            return dp[n, k];
        }

        static int MinMoves2(int eggs, int floors) // second approach
        {
            int[,] dp = new int[floors + 1, eggs + 1];
            int moves = 0;

            while (dp[moves, eggs] < floors)
            {
                moves++;
                for (int e = 1; e <= eggs; e++)
                {
                    dp[moves, e] = dp[moves - 1, e - 1] + dp[moves - 1, e] + 1;
                }
            }

            return moves;
        }
    }
}

