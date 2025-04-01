using System;
namespace test.ProblemSolving
{
	public class MaximumGap
	{
        public static int MaxGap(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return 0;

            int minVal = int.MaxValue, maxVal = int.MinValue;
            foreach (int num in nums)
            {
                minVal = Math.Min(minVal, num);
                maxVal = Math.Max(maxVal, num);
            }

            if (minVal == maxVal) return 0;

            int bucketSize = Math.Max(1, (maxVal - minVal) / (n - 1));
            int bucketCount = (maxVal - minVal) / bucketSize + 1;

            int[] minBucket = new int[bucketCount];
            int[] maxBucket = new int[bucketCount];
            Array.Fill(minBucket, int.MaxValue);
            Array.Fill(maxBucket, int.MinValue);

            foreach (int num in nums)
            {
                int idx = (num - minVal) / bucketSize;
                minBucket[idx] = Math.Min(minBucket[idx], num);
                maxBucket[idx] = Math.Max(maxBucket[idx], num);
            }

            int maxGap = 0, prevMax = minVal;

            for (int i = 0; i < bucketCount; i++)
            {
                if (minBucket[i] == int.MaxValue) continue;
                maxGap = Math.Max(maxGap, minBucket[i] - prevMax);
                prevMax = maxBucket[i];
            }

            return maxGap;
        }

        //public static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        //    Console.WriteLine(MaxGap(nums));
        //}
    }
}

