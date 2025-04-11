using System;

//ref: https://www.youtube.com/watch?v=RiNzHfoA2Lo
namespace test.DynamicProgramming
{
	public class LongestPalindromicSubsequence
	{
		static void Main()
		{
            string s = Console.ReadLine();
            Console.WriteLine(LongestPalindromeSubseq(s));
        }

        private static int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[,] dp = new int[n, n];

            for(int g = 0; g < n; g++)
            {
                for(int i = 0, j = g; j < n; i++, j++)
                {
                    if (g == 0)
                    {
                        dp[i, j] = 1;
                    } else if(g == 1)
                    {
                        dp[i, j] = s[i] == s[j] ? 2 : 1;
                    }
                    else
                    {
                        if (s[i] == s[j])
                        {
                            dp[i, j] = 2 + dp[i + 1, j - 1];
                        }
                        else
                        {
                            dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                        }
                    }
                }
            }
            return dp[0, n - 1];
        }
    }
}

