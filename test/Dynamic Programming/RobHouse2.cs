/*
 * Max coins -II
Nitin is an explorer, and he has a map that consists of n number of houses. All houses at this place are arranged in a circle. Each house has a certain amount of money stashed. The only constraint stopping Nitin from getting each of them is that adjacent houses have security systems connected, and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given an integer array nums representing the amount of money of each house, return the maximum amount of money Nitin can rob tonight without alerting the police.

Examples:

Input:

nums = [1, 2, 3, 1]
Output:

4
Input:

nums = [2, 7, 9, 3, 1]
Output:

11
Constraints:

1 <= nums.length <= 100

0 <= nums[i] <= 900
 */

using System;
namespace test
{
	public class RobHouse2
	{
		//static void Main()
		//{
  //          int N = int.Parse(Console.ReadLine());
  //          int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

  //          int res = Rob(arr, N);
  //          //int res = RobRecursive(arr, N);

  //          Console.WriteLine(res);
  //      }

        static int Rob(int[] arr, int N)
        {
            if (N == 0) return 0;

            if (N == 1) return arr[0];

            return Math.Max(RobHouseHelper(arr, 1, N-1), RobHouseHelper(arr, 0, N - 2));
        }

        static int RobHouseHelper(int[] arr, int st, int end)
        {
            int prev1 = 0, prev2 = 0;

            for(int i=st; i <= end; i++)
            {
                int temp = Math.Max(prev1, arr[i] + prev2);
                prev2 = prev1;
                prev1 = temp;
            }
            return prev1;
        }
    }
}

