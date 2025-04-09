using System;
namespace test.DynamicProgramming
{
	public class PartitionWithGivenDifference
	{
        static int MOD = 1000000007;
        static int count = 0;
        //static void Main(string[] args)
        //{
        //    string[] nm = Console.ReadLine().Split();
        //    int n = int.Parse(nm[0]);
        //    int d = int.Parse(nm[1]);

        //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    CountPartitions(arr, d);
        //    Console.WriteLine(count);
        //}

        private static void CountPartitions(int[] arr, int d)
        {
            int sumTotal = 0;
            foreach (int num in arr)
            {
                sumTotal += num;
            }
            FindMinRec(arr, arr.Length, 0, sumTotal, d);
        }

        private static void FindMinRec(int[] arr, int i, int sumCalculated, int sumTotal, int d)
        {
            if (Math.Abs((sumTotal - sumCalculated) - sumCalculated) == d)
            {
                count++;
                //return Math.Abs((sumTotal - sumCalculated) - sumCalculated);
            }
            if (i == 0) return;

                FindMinRec(arr, i - 1, sumCalculated + arr[i - 1], sumTotal, d);
                FindMinRec(arr, i - 1, sumCalculated, sumTotal, d);
        }
    }
}

