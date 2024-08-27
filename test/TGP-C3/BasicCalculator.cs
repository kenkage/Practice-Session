using System;
namespace test.TGPC3
{
	public class BasicCalculator
	{
		//static void Main()
		//{
  //          Console.Write("Enter the expression: ");
  //          string s = Console.ReadLine();
		//	int result = Calculate(s);
  //          Console.WriteLine($"{result}");
  //      }

		static int Calculate(string s)
		{

            Stack<int> stack = new Stack<int>();
            int num = 0;
            int result = 0;
            int sign = 1; // 1 means positive, -1 means negative

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (char.IsDigit(c))
                {
                    num = 0;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        num = num * 10 + (s[i] - '0');
                        i++;
                    }
                    result += sign * num;
                    i--; // Decrement i since it will be incremented by the loop
                }
                else if (c == '+')
                {
                    sign = 1;
                }
                else if (c == '-')
                {
                    sign = -1;
                }
                else if (c == '(')
                {
                    // Push the current result and sign onto the stack for later
                    stack.Push(result);
                    stack.Push(sign);
                    // Reset result and sign for the new sub-expression
                    result = 0;
                    sign = 1;
                }
                else if (c == ')')
                {
                    // Complete the sub-expression
                    result = stack.Pop() * result + stack.Pop();
                }
            }

            return result;
        }
    }
}

