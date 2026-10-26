using System;
namespace test.Stack
{
    public class GoodStringSolution
    {
        public string MakeGood(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (stack.Count > 0 && Math.Abs(stack.Peek() - c) == 32)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            char[] result = stack.ToArray();
            Array.Reverse(result);
            return new string(result);
        }
    }

    // Example usage
    public class GoodString
    {
        public static void Run()
        {
            GoodStringSolution solution = new GoodStringSolution();
            string input = "leEeetcode";
            string result = solution.MakeGood(input);
            Console.WriteLine(result); // Output: "leetcode"

            input = "abBAcC";
            result = solution.MakeGood(input);
            Console.WriteLine(result); // Output: ""

            input = "s";
            result = solution.MakeGood(input);
            Console.WriteLine(result); // Output: "s"
        }
    }
}

