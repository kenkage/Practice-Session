using System;
namespace test.DynamicProgramming
{
	public class PartitionWithMiniSumDiff
	{
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
    }
}

