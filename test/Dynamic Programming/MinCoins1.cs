﻿/*
 * MIN COINS REQUIRED-II
Alice has coins of different denominations and he has to pay an amount to buy a item. Return the number of combinations that make up that amount. If that amount of money cannot be made up by any combination of the coins, return 0. You may assume that you have an infinite number of each kind of coin.

Constraints:

1 <= coins.length <= 300

1 <= coins[i] <= 5000

All the values of coins are unique.

0 <= amount <= 5000

Example:

**Input: ** amount = 5, coins = [1,2,5]

Output:
4
 */


using System;
namespace test
{
	public class MinCoins1
	{
		//static void Main()
		//{
		//	string[] parts = Console.ReadLine().Split(' ');
		//	int n = int.Parse(parts[0]);
		//	int sum = int.Parse(parts[1]);
		//	int[] coins = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

		//	int[,] dp = new int[n + 1, sum + 1];
		//	for (int i = 0; i < n + 1; i++)
		//	{
		//		for (int j = 0; j < sum + 1; j++)
		//		{
		//			dp[i, j] = -1;
		//		}
		//	}
		//	//int res = MinimumCoinsRecursion(coins, n, sum);
		//	//Console.WriteLine(res < 0 ? -1 : res);

		//	int count = 0;
		//	int resDP = MinimumCoinsDP(coins, n, sum, dp, count);
		//	Console.WriteLine(resDP);
		//}

		static int MinimumCoinsRecursion(int[] coins, int n, int sum)
		{
			
			if (sum == 0) return 1;

			if (sum < 0) return 0;

			if (n <= 0) return 0;

			return MinimumCoinsRecursion(coins, n, sum - coins[n - 1]) +  // including the current coin
				   MinimumCoinsRecursion(coins, n - 1, sum);  // excluding the current coin
		}

		static int MinimumCoinsDP(int[] coins, int n, int sum, int[, ] dp, int count)
		{
			if (sum == 0) return 1;

			if (sum < 0 || n <= 0) return int.MaxValue;

			if (dp[n, sum] != -1) return dp[n, sum];

			return dp[n, sum] = MinimumCoinsDP(coins, n, sum - coins[n - 1], dp, count + 1) + 
								MinimumCoinsDP(coins, n - 1, sum, dp, count);
		}
    }
}

