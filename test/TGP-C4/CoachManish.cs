using System;
namespace test.TGPC4
{
	public class CoachManish
	{
		//static void Main()
		//{
  //          string[] input = Console.ReadLine().Split();
  //          int d = int.Parse(input[0]);
  //          int n = int.Parse(input[1]);

  //          Console.WriteLine(MaxGCD(d, n));
  //      }

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

