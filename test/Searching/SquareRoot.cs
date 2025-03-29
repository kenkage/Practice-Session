using System;
namespace test.Searching
{
	public class SquareRootClass
	{
        static int SquareRoot(int n)
        {
            if (n == 0 || n == 1) return n;

            int low = 1, high = n, ans = 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                long square = (long)mid * mid;

                if (square == n)
                    return mid;
                else if (square < n)
                {
                    ans = mid; // Store the closest integer square root
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            // Rounding logic: check which is closer: ans or ans + 1
            return (n - ans * ans <= (ans + 1) * (ans + 1) - n) ? ans : ans + 1;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(SquareRoot(n));
        }
    }
}

