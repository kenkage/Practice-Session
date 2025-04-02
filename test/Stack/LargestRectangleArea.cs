using System;
// https://www.youtube.com/watch?v=0do2734xhnU
namespace test.Stack
{
	public class LargestRectangleArea
	{
        public static int LargestRectangleArea1(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;
            int n = heights.Length;

            for (int i = 0; i <= n; i++)
            {
                int h = (i == n) ? 0 : heights[i];
                while (stack.Count > 0 && heights[stack.Peek()] > h)
                {
                    int poppedHeight = stack.Pop();
                    int height = heights[poppedHeight];  // Gets the last stored height.
                    int width = (stack.Count == 0) ? i : (i - stack.Peek() - 1); //  (i - stack.Peek() - 1) = width between the popped index and the new top of stack.
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }

            return maxArea;
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] heights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(LargestRectangleArea1(heights));
        }
    }
}

