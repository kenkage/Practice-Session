using System;
namespace test.Stack
{
	public class CountTheOperation_Stack
	{
        static int CountReversals(string s)
        {
            int n = s.Length;
            if (n % 2 != 0)
                return -1; // Odd length can't be balanced

            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '{')
                {
                    stack.Push(c);
                }
                else // c == '}'
                {
                    if (stack.Count > 0 && stack.Peek() == '{')
                    {
                        stack.Pop(); // matched
                    }
                    else
                    {
                        stack.Push(c); // unmatched }
                    }
                }
            }

            int open = 0, close = 0;

            // Now count unmatched brackets
            while (stack.Count > 0)
            {
                if (stack.Pop() == '{') open++;
                else close++;
            }

            // Minimum reversals needed
            return (open + 1) / 2 + (close + 1) / 2;
        }

        //static void Main()
        //{
        //    string s = Console.ReadLine();
        //    Console.WriteLine(CountReversals(s));
        //}
    }
}

