using System;
namespace test.DynamicProgramming
{
	public class TheNewClassmate
	{
        static void Main()
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();

            int result = GreatestLexicographicalSequenceSize(s.Length, s);
            Console.WriteLine(result);
        }

        static int GreatestLexicographicalSequenceSize(int n, string s)
        {
            int minChar = 'a' - 0;
            //int result = helper(s, 0, 0, 0, minChar);
            int result = FindGreatestSequence(s, n - 1, s[n - 1]);
            return result;
        }

        //public static int helper(string s, int idx, int ans, int count, int minChar)
        //{

        //    if(idx == s.Length)
        //    {
        //        return Math.Max(ans, count);
        //    }

        //    if(minChar <= s[idx])
        //    {
        //        minChar = s[idx];
        //        ans = helper(s, idx + 1, ans, count + 1, minChar);
        //        return ans;
        //    }
        //    ans = helper(s, idx + 1, ans, count, minChar);
        //    return ans;
        //}

        static int FindGreatestSequence(string s, int i, char maxChar)
        {
            // Base case: when we reach the start of the string
            if (i < 0)
            {
                return 0;
            }

            // If the current character is greater than or equal to maxChar
            if (s[i] >= maxChar)
            {
                // Include the current character in the sequence and update maxChar
                return 1 + FindGreatestSequence(s, i - 1, s[i]);
            }
            else
            {
                // Skip the current character and continue recursion
                return FindGreatestSequence(s, i - 1, maxChar);
            }
        }
    }
}

