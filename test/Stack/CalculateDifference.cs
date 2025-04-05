using System;
namespace test.Stack
{
	public class CalculateDifference
	{
        private static long[] FindNearestSmaller(long[] arr, bool findLeft)
        {
            int n = arr.Length;
            long[] result = new long[n];
            Stack<int> stack = new Stack<int>(); // Store indices

            int start = findLeft ? 0 : n - 1;
            int end = findLeft ? n : -1;
            int step = findLeft ? 1 : -1;

            for (int i = start; i != end; i += step)
            {
                // Pop elements from stack that are >= current element
                // They cannot be the nearest smaller for subsequent elements
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }

                // If stack is empty, no smaller element found (use 0)
                // Otherwise, the top element is the nearest smaller
                result[i] = stack.Count == 0 ? 0 : arr[stack.Peek()];

                stack.Push(i);
            }
            return result;
        }

        //public static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());

        //    long[] arr = Console.ReadLine()
        //                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) // Handle multiple spaces
        //                      .Select(long.Parse)
        //                      .ToArray();

        //    if (arr.Length != n)
        //    {
        //        Console.WriteLine("Error: Number of elements provided does not match the specified size.");
        //        return;
        //    }

        //    long[] leftSmaller = FindNearestSmaller(arr, true);

        //    long[] rightSmaller = FindNearestSmaller(arr, false);

        //    // Calculate the maximum absolute difference
        //    long maxDifference = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        long currentDifference = Math.Abs(leftSmaller[i] - rightSmaller[i]);
        //        if (currentDifference > maxDifference)
        //        {
        //            maxDifference = currentDifference;
        //        }
        //        // Or simply: maxDifference = Math.Max(maxDifference, Math.Abs(leftSmaller[i] - rightSmaller[i]));
        //    }
        //    Console.WriteLine(maxDifference);
        //}
    }
}

