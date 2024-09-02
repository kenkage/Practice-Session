/*
 * Minimum jumps
Given an array of N integers arr[] where each element represents the maximum length of the jump that can be made forward from that element. This means if arr[i] = x, then we can jump any distance y such that y ≤ x.
Find the minimum number of jumps to reach the end of the array (starting from the first element). If an element is 0, then you cannot move through that element.

Note: Return -1 if you can't reach the end of the array.

Your task:

You don't need to read input or print anything. Your task is to complete function minJumps() which takes the array arr and it's size N as input parameters and returns the minimum number of jumps. If not possible return -1.
Example 1:

Input:

N = 11   
arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}    
Output: 3

Explanation:

First jump from 1st element to 2nd  element with value 3. Now, from here we jump to 5th element with value 9, and from here we will jump to the last. 
Example 2:

Input :

N = 6
arr = {1, 4, 3, 2, 6, 7}
Output: 2

Explanation:

First we jump from the 1st to 2nd element and then jump to the last element.

Constraints:

1 ≤ N ≤ 10^7
0 ≤ arr[i] ≤ 10^7
 */

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

