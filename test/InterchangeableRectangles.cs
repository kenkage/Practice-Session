using System;
namespace test
{
	public class Solution
	{
        public long InterchangeableRectangles(int[][] rectangles)
        {
            Dictionary<(int, int), long> ratioCount = new Dictionary<(int, int), long>();

            foreach (var rectangle in rectangles)
            {
                int width = rectangle[0];
                int height = rectangle[1];
                int gcd = GCD(width, height);
                (int, int) ratio = (width / gcd, height / gcd);

                if (!ratioCount.ContainsKey(ratio))
                {
                    ratioCount[ratio] = 0;
                }
                ratioCount[ratio]++;
            }

            long pairs = 0;
            foreach (var count in ratioCount.Values)
            {
                if (count > 1)
                {
                    pairs += count * (count - 1) / 2;  // Combination formula nC2
                }
            }

            return pairs;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }

    public class Program6
    {
        //public static void Main()
        //{
        //    int[][] rectangles1 = new int[][]
        //{
        //    new int[] { 4, 8 },
        //    new int[] { 3, 6 },
        //    new int[] { 10, 20 },
        //    new int[] { 15, 30 }
        //};
        //    Solution solution = new Solution();
        //    long result = solution.InterchangeableRectangles(rectangles1);

        //    Console.WriteLine(result);
        //}
    }
}

