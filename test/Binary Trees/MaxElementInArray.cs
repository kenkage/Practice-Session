using System;
namespace test.BinaryTrees
{
	public class MaxElementInArray
	{
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(FindPeakIndex(arr));
        }

        private static int FindPeakIndex(int[] arr)
        {
            int left = 0, right = arr.Length - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] < arr[mid + 1]) // peak is on the right
                {
                    left = mid + 1;
                }
                else 
                {
                    right = mid; // peak is at mid or on the left
                }
            }

            // At this point, left == right == index of peak
            if ((left == 0 || arr[left - 1] < arr[left]) &&
                (left == arr.Length - 1 || arr[left] > arr[left + 1]))
            {
                return left;
            }

            return 0; // No valid peak found
        }
    }
}

