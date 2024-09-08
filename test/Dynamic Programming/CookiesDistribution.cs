/*
 * https://leetcode.com/problems/fair-distribution-of-cookies/
 */

using System;
namespace test.DynamicProgramming
{
	public class CookiesDistribution
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int k = int.Parse(Console.ReadLine());

        //    int[] cookies = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        //    int res = distributeCookies(cookies, k);
        //    Console.WriteLine(res);

        //}

        static int distributeCookies(int[] cookies, int k)
		{
            var children = new int[k];
            var min = int.MaxValue;

            Backtrack(0);

            return min;

            void Backtrack(int bag)
            {
                if (bag == cookies.Length)
                {
                    min = Math.Min(min, children.Max());
                    return;
                }

                for (var i = 0; i < k; i++)
                {
                    //Console.WriteLine($"left to right at index {i}");
                    children[i] += cookies[bag];
                    Backtrack(bag + 1);
                    //Console.WriteLine($"backtrack started at index {i}");
                    children[i] -= cookies[bag];
                    if (children[i] == 0)
                        return;
                }
            }
        }
    }
}

