using System;
namespace test.Stack
{
	public class Tunnel
	{
        public static int CheckTunnelSafety(int[] IN, int[] OUT, int n)
        {
            Stack<int> stack = new Stack<int>();

            foreach (int worker in IN)
            {
                stack.Push(worker);
            }

            foreach (int worker in OUT)
            {
                if (stack.Count == 0 || stack.Peek() != worker)
                {
                    return 0; // Order violation
                }
                stack.Pop();
            }

            return 1;
        }

        //public static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] IN = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        //    int[] OUT = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    Console.WriteLine(CheckTunnelSafety(IN, OUT, n));
        //}
    }
}

