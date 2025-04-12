using System;
// ref:https://www.youtube.com/watch?v=BXkK_Ko7uls
namespace test.DynamicProgramming
{
	public class BreakTheNumber
	{
        //public static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    Console.WriteLine(MaxProduct(n));
        //}

        private static int MaxProduct(int n)
        {
            if (n == 2) return 1;
            if (n == 3) return 2;
            int product = 1;

            while (n > 4)
            {
                product = product * 3;
                n = n - 3;
            }
            return product * n;
        }
    }
}

