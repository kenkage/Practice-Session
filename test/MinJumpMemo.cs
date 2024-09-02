using System;
namespace test
{
	public class MinJumpMemo
	{
		//static void Main()
		//{
  //          int N = int.Parse(Console.ReadLine()); // Length of array - not necessary to take as input from user we can directly use arr.Length.
  //          int[] arr = new int[N];
  //          arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

		//	int result = MinJumps(arr, N);
  //          Console.WriteLine("Minimum number of jumps: " + (result == int.MaxValue ? -1 : result));
  //      }

		static int MinJumps(int[] arr, int N)
		{
			int[] memo = new int[N];
			Array.Fill(memo, -1);
			int result = MinJumpsHelper(arr, 0, N, memo);
            return result == int.MaxValue ? -1 : result;
        }

		private static int MinJumpsHelper(int[] arr, int currentIndex, int N, int[] memo)
		{
			if (currentIndex >= N - 1) return 0;

			if (arr[currentIndex] == 0) return int.MaxValue;

			if (memo[currentIndex] != -1) return memo[currentIndex];

			int minJumps = int.MaxValue;

			int maxReach = Math.Min(currentIndex + arr[currentIndex], N-1);

			for(int i = currentIndex + 1; i <= maxReach; i++)
			{
				int jumps = MinJumpsHelper(arr, i, N, memo);
				if(jumps != int.MaxValue)
				{
					minJumps = Math.Min(minJumps, jumps + 1);
				}
			}
            memo[currentIndex] = minJumps;
            return minJumps;
		}

    }
}

