using System;
namespace test.Stack
{
	public class CountTheOperation
	{
        static int CountReversals(string s)
        {
            int n = s.Length;

            if (n % 2 != 0) return -1; // Odd length can't be balanced

            int open = 0, close = 0;

            foreach (char c in s)
            {
                if (c == '{')
                {
                    open++;
                }
                else // c == '}'
                {
                    if (open > 0)
                        open--; // Match found
                    else
                        close++; // Unmatched }
                }
            }

            // ceil(open / 2) + ceil(close / 2) = (open + 1)/2 + (close + 1)/2
            return (open + 1) / 2 + (close + 1) / 2;
        }

        //static void Main()
        //{
        //    string s = Console.ReadLine();
        //    Console.WriteLine(CountReversals(s));
        //}
    }
}