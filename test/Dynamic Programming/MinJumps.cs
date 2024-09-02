using System;
namespace test
{
	public class MinJumps
	{
		//static void Main()
		//{
		//	int N = int.Parse(Console.ReadLine());
		//	int[] arr = new int[N];
  //          arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

		//	//int result = MinJumpBruteForce(arr, N);
		//	int resultR = MinJumRecursive1(arr, N);
  //          Console.WriteLine($"MinJumps: {resultR}");
  //      }

		static int MinJumpBruteForce(int[] arr, int N)
		{
			int jump = 0;
			int newIdx = 0;

            for (int i = 0; i< arr.Length; i++)
			{
				if (newIdx <= arr.Length)
				{
					newIdx += arr[i];
					jump++;
					if (newIdx + arr[i] > arr.Length)
					{
						break;
					}
				}

			}
			return jump;
		}

		static int MinJumRecursive1(int[] arr, int N)
		{
            if (N == 1) return 0;
            if (arr[0] == 0) return -1;

            int maxReach = arr[0];  // The maximum index we can reach so far
            int steps = arr[0];     // Steps we can still take
            int jumps = 1;          // Number of jumps taken

            for (int i = 1; i < N; i++)
            {
                if (i == N - 1) return jumps;

                maxReach = Math.Max(maxReach, i + arr[i]);
                steps--;

                if (steps == 0)
                {
                    jumps++;
                    if (i >= maxReach) return -1; // If we can't move further
                    steps = maxReach - i;
                }
            }

            return -1;
        }

		static int MinJumRecursive(int[] arr)
		{
            int maxRightIdx = 0, currentRightIdx = 0, count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i > maxRightIdx) { return 0; }
                if (i > currentRightIdx)
                {
                    count++;
                    currentRightIdx = maxRightIdx;

                }
                if (i + arr[i] > maxRightIdx) {
                    maxRightIdx = i + arr[i];
                }
            }

            return count;
        }
	}
}

