using System;
namespace test.Sorting
{
	public class waveArray
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

			FormWaveArray(arr);
        }

		static void FormWaveArray(int[] arr)
		{
			int temp;
			int n = arr.Length;

			for(int i = 0; i < arr.Length; i++)
			{
				if (i % 2 == 0 && i+1 < arr.Length)
				{
					temp = arr[i];
					arr[i] = arr[i + 1];
					arr[i + 1] = temp;
				}
			}

            // Swap adjacent elements in pairs
            //for (int i = 0; i < n - 1; i += 2)
            //{
            //    // Swap arr[i] and arr[i+1]
            //    temp = arr[i];
            //    arr[i] = arr[i + 1];
            //    arr[i + 1] = temp;
            //}

            for (int i =0; i < arr.Length; i++)
			{
				Console.Write(arr[i] + " ");
			}
		}
	}
}

