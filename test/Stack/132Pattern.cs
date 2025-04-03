using System;
namespace test.Stack
{
	public class _32Pattern
	{
        public bool Find132pattern(int[] nums)
        {
            int n = nums.Length;
            if (n < 3)
            {
                return false;
            }

            Stack<int> stack = new Stack<int>();
            int second = int.MinValue;

            for (int i = n - 1; i >= 0; i--)
            {
                if (nums[i] < second)
                {
                    return true;
                }

                while (stack.Count > 0 && nums[i] > stack.Peek())
                {
                    second = stack.Pop();
                }

                stack.Push(nums[i]);
            }

            return false;
        }

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(input[i]);
            }

            _32Pattern solution = new _32Pattern();
            Console.WriteLine(solution.Find132pattern(nums).ToString().ToLower());
        }
    }
}

