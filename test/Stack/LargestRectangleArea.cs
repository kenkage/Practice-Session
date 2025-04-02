using System;
namespace test.Stack
{
	public class LargestRectangleArea
	{
        public static int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;
            int n = heights.Length;

            for (int i = 0; i <= n; i++)
            {
                int h = (i == n) ? 0 : heights[i];
                while (stack.Count > 0 && heights[stack.Peek()] > h)
                {
                    int height = heights[stack.Pop()];
                    int width = (stack.Count == 0) ? i : (i - stack.Peek() - 1);
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

            Console.WriteLine(LargestRectangleArea(heights));
        }
    }
}

