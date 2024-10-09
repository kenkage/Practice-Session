using System;
using System.Collections.Generic;

namespace test.Sets
{
	public class NextLeastGreaterElement
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());

        //    int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    int[] result = ReplaceWithLeastGreater(nums, n);

        //    Console.WriteLine(string.Join(" ", result));
        //}

        static int[] ReplaceWithLeastGreater(int[] nums, int n)
        {
            int[] result = new int[n];
            SortedSet<int> set = new SortedSet<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                // Initialize the replacement value as -1
                result[i] = -1;

                // Check if there's a greater element in the set
                var greaterElements = set.GetViewBetween(nums[i] + 1, int.MaxValue);

                // If there's a greater element, replace result[i] with the smallest one
                if (greaterElements.Count > 0)
                {
                    result[i] = greaterElements.Min;
                }

                // Insert the current element into the sorted set
                set.Add(nums[i]);
            }

            return result;
        }
    }
}

