using System;
namespace test.Sorting
{
	public class SortColorBall
	{
        static void SortColors(int[] arr, int maxColor)
        {
            int[] count = new int[maxColor + 1];

            // Step 1: Count occurrences of each color
            foreach (int num in arr)
            {
                count[num]++;
            }

            // Step 2: Overwrite the original array based on counts
            int index = 0;
            for (int i = 0; i <= maxColor; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    arr[index++] = i;
                }
            }
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxColor = arr.Max(); // Get the highest number in the input
            SortColors(arr, maxColor);
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}

