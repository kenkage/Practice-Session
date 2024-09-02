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

