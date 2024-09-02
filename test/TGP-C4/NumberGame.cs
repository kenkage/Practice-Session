using System;
namespace test.TGPC4
{
	public class NumberGame
	{
		//static void Main()
		//{
  //          string[] inputs = Console.ReadLine().Split(' ');
  //          int a = int.Parse(inputs[0]);
  //          int b = int.Parse(inputs[1]);
  //          int n = int.Parse(inputs[2]);

  //          while (true)
  //          {
  //              int gcdBholu = GCD(a, n);
  //              if (n < gcdBholu)
  //              {
  //                  Console.WriteLine(1); // Dholu wins
  //                  break;
  //              }
  //              n -= gcdBholu;

  //              int gcdDholu = GCD(b, n);
  //              if (n < gcdDholu)
  //              {
  //                  Console.WriteLine(0); // Bholu wins
  //                  break;
  //              }
  //              n -= gcdDholu;
  //          }
  //      }

        public static int GCD(int x, int y)
        {
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }
            return x;
        }

        //private static int GCD(int a, int b)
        //{
        //    int result = Math.Min(a, b);
        //    while (result > 0)
        //    {
        //        if (a % result == 0 && b % result == 0)
        //        {
        //            break;
        //        }
        //        result--;
        //    }
        //    return result;

        //    //while (b != 0)
        //    //{
        //    //    int temp = b;
        //    //    b = a % b;
        //    //    a = temp;
        //    //}
        //    //return a;
        //}
    }
}

