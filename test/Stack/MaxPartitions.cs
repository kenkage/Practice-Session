using System;
namespace test.Stack
{
	public class MaxPartition
	{
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(MaxPartitions(arr));
        }

        static int MaxPartitions(int[] arr)
        {
            int maxSoFar = 0;
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                maxSoFar = Math.Max(maxSoFar, arr[i]);

                if (maxSoFar == i) // we can make a partition here
                {
                    count++;
                }
            }

            return count;
        }
    }
}

