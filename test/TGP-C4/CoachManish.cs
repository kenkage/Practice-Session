/*
 * Coach Manish
Manish is the coach of a high school football team. He has come up with a training regime of difficulty 'd' but he is afraid that it might result in his team getting exhausted quickly and prone to fatigue. 
So he has decided to break the training in 'n' number of days where every day has a certain amount of difficulty and the difficulty of each day adds up to 'd' the original difficulty.
But he also wants to make sure that his training results in a greater output so he cannot spread the difficulty of training without planning. The result can be determined by calculating the GCD of the difficulty of all the days. Return the greatest result that can be achieved from the training.

Input Format:
You are given two space-separated integers d and n, denoting the total difficulty and number of days it is divided into.

Output Format:
You have to return a single integer denoting the maximum result that can be achieved from the training.

Sample Input:
9 2

Sample Output:
3

Explanation:
We can break the difficulty in 3 and 6 whose GCD results in 3 which is the greatest output possible.

Constraints:
* 1 <= d <= 10^5
* 1<= n <= d
 */

using System;
namespace test.TGPC4
{
	public class CoachManish
	{
        //static void Main()
        //{
        //    string[] input = Console.ReadLine().Split();
        //    int d = int.Parse(input[0]);
        //    int n = int.Parse(input[1]);

        //    Console.WriteLine(MaxGCD(d, n));
        //}

        static int MaxGCD(int d, int n)
		{
            int maxGCD = 1;  // Initialize with the smallest possible GCD

            // Find all divisors of d
            for (int i = 1; i <= Math.Sqrt(d); i++)
            {
                if (d % i == 0)
                {
                    // i is a divisor
                    if (d / i >= n) // Check if the current divisor can be used to split into n parts
                    {
                        maxGCD = Math.Max(maxGCD, i);
                    }

                    // d / i is also a divisor
                    if (i != d / i && d / (d / i) >= n)
                    {
                        maxGCD = Math.Max(maxGCD, d / i);
                    }
                }
            }

            return maxGCD;
        }

    }
}

