using System;
namespace test.DynamicProgramming
{
	public class CookiesDistribution
	{
		//static void Main()
		//{
		//	int n = int.Parse(Console.ReadLine());
		//	int k = int.Parse(Console.ReadLine());

		//	int[] cookies = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
		//	int res = distributeCookies(cookies, k);
		//	Console.WriteLine(res);

  //      }

		static int distributeCookies(int[] cookies, int k)
		{
			int sum = cookies.Sum();
			int distribute = sum / k;
			return 0;
        }

		


    }
}

