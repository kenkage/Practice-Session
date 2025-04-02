using System;
namespace test.Stack
{
	public class Tunnel
	{
        public static int CheckTunnelSafety(int[] IN, int[] OUT, int n)
        {
            Stack<int> stack = new Stack<int>();
            int outIndex = 0;

            foreach (int worker in IN)
            {
                stack.Push(worker);

                while (stack.Count > 0 && stack.Peek() == OUT[outIndex])
                {
                    stack.Pop();
                    outIndex++;
                }
            }

            return stack.Count == 0 ? 1 : 0;
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] IN = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] OUT = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(CheckTunnelSafety(IN, OUT, n));
        }
    }
}

