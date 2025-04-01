using System;
namespace test.ProblemSolving
{
	public class SortColorsSolution
	{
        public static void SortColors(int[] nums)
        {
            int left = 0, right = nums.Length - 1, index = 0;

            void Swap(int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            while (index <= right)
            {
                if (nums[index] == 0)
                {
                    Swap(left, index);
                    left++;
                    index++;
                }
                else if (nums[index] == 2)
                {
                    Swap(right, index);
                    right--;
                }
                else
                {
                    index++;
                }
            }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            SortColors(nums);
            Console.WriteLine("[" + string.Join(",", nums) + "]");
            //foreach (int num in nums)
            //{
            //  Console.Write(num + " ");
            //}
            //Console.WriteLine();
        }
    }
}

