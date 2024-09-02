using System;
namespace test
{
	public class RobHouse
	{
		//static void Main()
		//{
		//	int N = int.Parse(Console.ReadLine());
		//	int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

		//	int res = Rob(arr, N);
  //          Dictionary<int, int> memo = new Dictionary<int, int>();
  //          //int res = RobRecursive(arr, N, memo);

  //          Console.WriteLine(res);
		//}

		static int Rob(int[] arr, int N)
		{

			if (N == 0) return 0;

			if (N == 1) return arr[0];

			int[] dp = new int[N];
			dp[0] = 0;
			dp[1] = Math.Max(arr[0], arr[1]); // there are only two elements till yet. Therefore, taking max of those two

			for(int i=2; i<N; i++)
			{
				dp[i] = Math.Max(dp[i - 2] + arr[i], dp[i - 1]);
            }
			return dp[N - 1];
		}

		static int RobRecursive(int[] nums, int i, Dictionary<int, int> memo)
		{
            if (i == 0) return nums[0];
            if (i == 1) return Math.Max(nums[0], nums[1]);

            if (!memo.ContainsKey(i))
            {
                memo[i] = Math.Max(RobRecursive(nums, i - 1, memo), RobRecursive(nums, i - 2, memo) + nums[i]);
            }

            return memo[i];
        }

	}
}

