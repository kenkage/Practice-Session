using System;
namespace test
{
	public class Tunnel
	{
        public static int CheckSequences(int n, int[] inSeq, int[] outSeq)
        {
            Stack<int> stack = new Stack<int>();
            int j = 0;

            for (int i = 0; i < n; i++)
            {
                stack.Push(inSeq[i]);
                while (stack.Count > 0 && stack.Peek() == outSeq[j])
                {
                    stack.Pop();
                    j++;
                }
            }

            return stack.Count == 0 ? 1 : 0;
        }
    }

    public class Program3
    {
        //public static void Main()
        //{
        //    int[] inSeq = new int[] {1,2,3,4,5};
        //    int[] outSeq = new int[] {5,4,3,2,1};
        //    int result = Tunnel.CheckSequences(5, inSeq, outSeq);
        //    Console.WriteLine(result);
        //}

    }
}

