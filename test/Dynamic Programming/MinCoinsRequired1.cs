/*
 Problem
    MIN COINS REQUIRED-I
    Alice has coins of different denominations and he has to pay an amount to buy an item. Return the fewest number of coins that Alice needs to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1. You may assume that you have an infinite number of each kind of coin.
    
    Constraints:
    
    1 <= coins.length <= 12
    
    1 <= coins[i] <= 2^31 - 1
    
    0 <= amount <= 10^4
    
    Example:
    
    Input:
    coins = [1,2,5], amount = 11
    
    Output:
    3
    
    Input:
    coins = [2], amount = 3
    
    Output:
    
    -1
*/

using System;
namespace test
{
    public class MinCoinsRequired1
    {

        //static void Main()
        //{
        //    string[] parts = Console.ReadLine().Split(' ');
        //    int n = int.Parse(parts[0]);
        //    int sum = int.Parse(parts[1]);
        //    int[] coins = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        //    //int res = MinimumCoinsRecursion(coins, n, sum);
        //    //Console.WriteLine(res < 0 ? -1 : res);
        //    if (sum != 0)
        //    {
        //        int[,] dp = new int[n + 1, sum + 1];
        //        for (int i = 0; i < n + 1; i++)
        //        {
        //            for (int j = 0; j < sum + 1; j++)
        //            {
        //                dp[i, j] = -1;
        //            }
        //        }
        //        int resDP = MinimumCoins(coins, 0, sum, 0);
        //        Console.WriteLine(resDP == int.MaxValue ? -1 : resDP);
        //    }
        //    else
        //    {
        //        Console.WriteLine(0);
        //    }
        //}

        static int MinimumCoins(int[] coins, int idx, int sum, int count)
        {
            if (sum == 0) return count;

            if (idx == coins.Length || sum < 0) return int.MaxValue;

            int p1 = MinimumCoins(coins, idx, sum - coins[idx], count + 1);
            int p2 = MinimumCoins(coins, idx + 1, sum, count);
            return Math.Min(p1, p2);
        }
    }
}

