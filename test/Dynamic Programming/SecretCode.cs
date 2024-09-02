/*
 * Secret Codes
You and your friend have decided to exchange messages in the form of secret codes. You will be communicating in numbers where number '1' represents 'a' number '2' represents 'b' and so on until the number '26' that represents 'z'. Every message has a difficulty which is represented as the total number of ways your message can be interpreted. For example: 23 can be interpreted as 'ab' as well as 'w' so it has a difficulty of 2. Given an array 'ar' containing n number of integers, calculate its difficulty.

Input Format:

The first line contains a single integer 'n' denoting the size of array.

Second line contains 'n' number of space separated integers.

Output:

Return the difficulty of the secret code which would be an integer.

Sample Input:

3

1 2 3

Sample Output:

3

Explanation: Since there are total 3 ways the message can be interpreted which are abc, lc, aw. Thus, the difficulty would be 3.

Constraints:

1<=n<=10^4

0<=a[i]<=9
 */

using System;
namespace test.DynamicProgramming
{
	public class SecretCode
	{
		//static void Main()
		//{
		//	int n = int.Parse(Console.ReadLine());
		//	int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

		//	int res = Solve(arr, 0, n);
		//	Console.WriteLine(res);
		//}

		static int Solve(int[] arr, int i, int n)
		{
			if (i == n) return 1;

			if (arr[i] == 0) return 0;

			int pick = Solve(arr, i + 1, n); // for single digit

			if(i + 1 <= n-1 && (arr[i] * 10 + arr[i+1]) <= 26)  // check if the next digit of double digit is not exceeding the length of array: i+1 <= n-1
        		{                                                   // to check if double digit formed will be less than 26
                		pick += Solve(arr, i + 2, n);
			}

			return pick;
		}
	}
}

