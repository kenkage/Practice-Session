using System;
namespace test.DynamicProgramming
{
	public class PartitionWithMiniSumDiff
	{
        int minDiff = int.MaxValue;
        //static void Main()
        //{
        //          int[] vec = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        //          Console.WriteLine(FindMin(vec));
        //      }

        static int FindMin(int[] arr)
        {
            int sumTotal = 0;
            foreach (int num in arr)
            {
                sumTotal += num;
            }
            return FindMinRec(arr, arr.Length, 0, sumTotal);
        }

        private static int FindMinRec(int[] arr, int i, int sumCalculated, int sumTotal)
        {
            if(i == 0)
            {
                return Math.Abs((sumTotal - sumCalculated) - sumCalculated);
            }

            int ans = Math.Min(
                FindMinRec(arr, i - 1, sumCalculated + arr[i - 1], sumTotal),
                FindMinRec(arr, i - 1, sumCalculated, sumTotal));

            return ans;
        }

        //private void Backtrack(int[] nums, int index, int currSum, int total) //create object to call this function
        //{
        //    if (index == nums.Length)
        //    {
        //        int otherSum = total - currSum;
        //        minDiff = Math.Min(minDiff, Math.Abs(currSum - otherSum));
        //        return;
        //    }

        //    // Include nums[index] in the current subset
        //    Backtrack(nums, index + 1, currSum + nums[index], total);

        //    // Exclude nums[index] from the current subset
        //    Backtrack(nums, index + 1, currSum, total);
        //}
    }
}

