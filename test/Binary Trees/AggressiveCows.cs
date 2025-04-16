using System;
//ref: https://www.youtube.com/watch?v=R_Mfw4ew-Vo
namespace test.BinaryTrees
{
	public class AggressiveCows
	{
		//public static void Main()
  //      {
  //          var input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
  //          int n = input1[0], k = input1[1];

  //          var stalls = Console.ReadLine().Split().Select(int.Parse).ToArray();
  //          Array.Sort(stalls);
  //          Console.WriteLine(AggresiveCows(n, k, stalls));
  //      }

        private static int AggresiveCows(int n, int k, int[] stalls)
        {
            int low = 1, high = stalls[n - 1] - stalls[0], mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (CanWePlace(stalls, mid, k))
                {   // On satisfying this condition, we can conclude that the number ‘mid’ is one of our possible answers.
                    // But we want the maximum number. So, we will eliminate the left half and consider the right half(i.e. low = mid+1).
                    low = mid + 1;
                }
                else
                {   // Otherwise, the value mid is greater than the distance we want.
                    // This means the numbers greater than ‘mid’ should not be considered and the right half of ‘mid’ consists of such numbers.
                    // So, we will eliminate the right half and consider the left half(i.e. high = mid-1).
                    high = mid - 1;
                }
            }
            return high; // high as the pointer will be pointing to the answer.
        }

        private static bool CanWePlace(int[] stalls, int dist, int cows)
        {
            int n = stalls.Length;
            int cntCows = 1; // no of cows placed & first cow is always placed at stalls[0]
            int lastCow = stalls[0];

            for(int i = 1; i < n; i++)// i<n because we've already placed first cow at oth index. Now we've to traverse from 1 -> n to place remaining cows.
            {
                if (stalls[i] - lastCow >= dist)
                {
                    cntCows++;
                    lastCow = stalls[i];
                    if (cntCows >= cows) return true;
                }
            }
            return false;
        }
    }
}

