// https://leetcode.com/problems/maximum-width-ramp/

using System;
namespace test.Stack
{
	public class MaximumWidthRamp
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    Console.WriteLine(MaxWidthRamp(nums));
        //}

        static int MaxWidthRamp(int[] nums)
        {
            int n = nums.Length;
            Stack<int> stack = new Stack<int>();

            // Step 1: Build a decreasing stack of indices
            for (int i = 0; i < n; i++)
            {
                if (stack.Count == 0 || nums[i] < nums[stack.Peek()]) // finding the smallest value of nums[i] to compare with future nums[j].
                {
                    stack.Push(i);
                }
            }

            int maxWidth = 0;

            // Step 2: Traverse from right to left and find maximum width
            for (int j = n - 1; j >= 0; j--)
            {
                while (stack.Count > 0 && nums[j] >= nums[stack.Peek()])
                {
                    int i = stack.Pop();
                    maxWidth = Math.Max(maxWidth, j - i);
                }
            }

            return maxWidth;
        }
    }
}

