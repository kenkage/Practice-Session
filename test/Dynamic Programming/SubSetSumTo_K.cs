using System;
namespace test.DynamicProgramming
{
	public class SubSetSumTo_K
	{
		//static void Main()
		//{
  //          string[] parts = Console.ReadLine().Split(' ');
  //          int N = int.Parse(parts[0]);

  //          int K = int.Parse(parts[1]);

  //          int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

  //          Console.WriteLine(SubsetSum(arr, N, K));
  //      }

        static bool SubsetSum(int[] arr, int N, int K)
        {
            // Base case 1: If the sum is exactly 0, return true (subset found)
            if (K == 0)
            {
                return true;
            }

            // Base case 2: If no elements left or K becomes negative, return false
            if (N == 0 || K < 0)
            {
                return false;
            }

            // Recursive case:
            // 1. Include the current element arr[N-1] and reduce the sum K
            // 2. Exclude the current element and move to the next one
            return SubsetSum(arr, N - 1, K - arr[N - 1]) || SubsetSum(arr, N - 1, K);
        }
    }
}

