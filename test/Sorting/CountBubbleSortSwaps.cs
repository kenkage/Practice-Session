using System;
namespace test.Sorting
{
	public class BubbleSortSwaps
	{
        static int CountBubbleSortSwaps(int[] arr)
        {
            int n = arr.Length;
            int swapCount = 0;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);   //tupple swap
                        swapCount++;
                        swapped = true;
                    }
                }
                // If no swaps occurred, array is already sorted
                if (!swapped) break;
            }

            return swapCount;
        }

        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] anishStones = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //    int[] binishStones = Console.ReadLine().Split().Select(int.Parse).ToArray();

        //    int anishSwaps = CountBubbleSortSwaps(anishStones);
        //    int binishSwaps = CountBubbleSortSwaps(binishStones);

        //    if (anishSwaps < binishSwaps)
        //        Console.WriteLine("Anish");
        //    else if (anishSwaps > binishSwaps)
        //        Console.WriteLine("Binish");
        //    else
        //        Console.WriteLine("Tie");
        //}
    }
}

