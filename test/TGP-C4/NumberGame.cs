/*
 * Number Game
Bholu and Dholu play a game. Initially each player receives one fixed positive integer that doesn't change throughout the game. Bholu receives number a and Dholu receives number b. They also have a heap of n stones. The players take turns to make a move and Bholu starts. During a move a player should take from the heap the number of stones equal to the greatest common divisor of the fixed number he has received and the number of stones left in the heap. A player loses when he cannot take the required number of stones (i. e. the heap has strictly less stones left than one needs to take).
Your task is to determine who wins the game.
Input
The only string contains space-separated integers a, b and n (1 ≤ a, b, n ≤ 100) — the fixed numbers Bholu and Dholu have received correspondingly and the initial number of stones in the pile.
Output
If Bholu wins, print "0" (without the quotes), otherwise print "1" (without the quotes).
Sample Input
3 5 9
Sample Output
0
Explanation
The greatest common divisor of two non-negative integers a and b is such maximum positive integer k, that a is divisible by k without remainder and similarly, b is divisible by k without remainder. Let gcd(a, b) represent the operation of calculating the greatest common divisor of numbers a and b. Specifically, gcd(x, 0) = gcd(0, x) = x.
In the first sample the game will go like that:
Bholu should take gcd(3, 9) = 3 stones from the heap. After his move the heap has 6 stones left.
Dholu should take gcd(5, 6) = 1 stone from the heap. After his move the heap has 5 stones left.
Bholu should take gcd(3, 5) = 1 stone from the heap. After his move the heap has 4 stones left.
Dholu should take gcd(5, 4) = 1 stone from the heap. After his move the heap has 3 stones left.
Bholu should take gcd(3, 3) = 3 stones from the heap. After his move the heap has 0 stones left.
Dholu should take gcd(5, 0) = 5 stones from the heap. As 0 < 5, it is impossible and Dholu loses.
 */

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

