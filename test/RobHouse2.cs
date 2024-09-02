using System;
namespace test
{
	public class RobHouse2
	{
		//static void Main()
		//{
  //          int N = int.Parse(Console.ReadLine());
  //          int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

  //          int res = Rob(arr, N);
  //          //int res = RobRecursive(arr, N);

  //          Console.WriteLine(res);
  //      }

        static int Rob(int[] arr, int N)
        {
            if (N == 0) return 0;

            if (N == 1) return arr[0];

            return Math.Max(RobHouseHelper(arr, 1, N-1), RobHouseHelper(arr, 0, N - 2));
        }

        static int RobHouseHelper(int[] arr, int st, int end)
        {
            int prev1 = 0, prev2 = 0;

            for(int i=st; i <= end; i++)
            {
                int temp = Math.Max(prev1, arr[i] + prev2);
                prev2 = prev1;
                prev1 = temp;
            }
            return prev1;
        }
    }
}

