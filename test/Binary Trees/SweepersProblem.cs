using System;
// ref: https://leetcode.com/problems/number-of-ways-to-reorder-array-to-get-same-bst/description/
namespace test.BinaryTrees
{
	public class SweepersProblem
	{
        const int MOD = 1000000007;
        static long[,] comb;

        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    comb = new long[n + 1, n + 1];
        //    ComputeCombinations(n);

        //    Console.WriteLine((CountWays(arr) + MOD) % MOD); // Subtract 1 to exclude original
        //}

        static void ComputeCombinations(int n) // Pascal triangle
        {
            for (int i = 0; i <= n; i++)
            {
                comb[i, 0] = comb[i, i] = 1;
                for (int j = 1; j < i; j++)
                {
                    comb[i, j] = (comb[i - 1, j - 1] + comb[i - 1, j]) % MOD;
                }
            }
        }

        static long CountWays(List<int> nums)
        {
            if (nums.Count <= 2) return 1;

            int root = nums[0];
            var left = new List<int>();
            var right = new List<int>();

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < root) left.Add(nums[i]);
                else right.Add(nums[i]);
            }

            long leftWays = CountWays(left);
            long rightWays = CountWays(right);

            long totalWays = comb[nums.Count - 1, left.Count]; // comb[left.Count + right.Count, left.Count OR right.Count];
            return (totalWays * leftWays % MOD * rightWays % MOD) % MOD;
        }

        static long CountWays(int[] arr)
        {
            return CountWays(new List<int>(arr));
        }
    }
}

