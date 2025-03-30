// https://www.youtube.com/watch?v=Rot0y4cmlNw

using System;
using System.Collections.Generic;

namespace test.Arrays
{
	public class FirstNegativeElement
	{
        static void FirstNegativeInEveryWindow(int[] arr, int k)
        {
            int n = arr.Length;
            Queue<int> negatives = new Queue<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < k; i++)
            {
                if (arr[i] < 0)
                    negatives.Enqueue(i);
            }

            // Slide the window across the array
            for (int i = k; i <= n; i++)
            {
                // Add first negative number of the window
                result.Add(negatives.Count > 0 ? arr[negatives.Peek()] : 0);

                // Remove elements that are out of the current window
                if (negatives.Count > 0 && negatives.Peek() <= i - k)
                {
                    negatives.Dequeue();
                }

                // Add new element to the queue if it is negative
                if (i < n && arr[i] < 0)
                {
                    negatives.Enqueue(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }

        static void Main()
        {
            Console.Write("Enter window size (k): ");
            int[] ip = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = ip[0];
            int k = ip[1];

            Console.Write("Enter the array elements (space-separated): ");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            FirstNegativeInEveryWindow(arr, k);
        }
    }
}

