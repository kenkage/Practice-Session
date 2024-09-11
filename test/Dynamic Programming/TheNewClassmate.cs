using System;
using System.IO;

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
            char minChar = (char)('a' - 0);
            int result = Helper(s, 0, 0, 0, minChar);
            return result;
        }

        public static int Helper(string s, int idx, int ans, int count, char minChar)
        {
            if (idx == s.Length)
            {
                return Math.Max(ans, count);
            }
            if (minChar <= s[idx])
            {
                // minChar = s[idx]; // don't need to update minChar in not pick scneario
                Console.WriteLine($"Pick: {s[idx]}, MinChar: {minChar}");
                ans = Helper(s, idx + 1, ans, count + 1, s[idx]); // Pick
                int ans2 = Helper(s, idx + 1, ans, count, minChar); // Non-Pick
                return Math.Max(ans, ans2);
            }
            else
            {
                Console.WriteLine($"Not Pick: {s[idx]}");
                ans = Helper(s, idx + 1, ans, count, minChar); 
                return ans;
            }
        }
    }
}

