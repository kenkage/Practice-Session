using System;
namespace test
{
	public class Solution
	{
            public IList<string> SimplifiedFractions(int n)
            {
                List<string> result = new List<string>();

                for (int denominator = 2; denominator <= n; denominator++)
                {
                    for (int numerator = 1; numerator < denominator; numerator++)
                    {
                        if (GCD(numerator, denominator) == 1)
                        {
                            result.Add($"{numerator}/{denominator}");
                        }
                    }
                }

                return result;
            }

            private int GCD(int a, int b){
                int result = Math.Min(a, b);
                while (result > 0)
                {
                    if (a % result == 0 && b % result == 0)
                    {
                        break;
                    }
                    result--;
                }
                return result;

                //while (b != 0)
                //{
                //    int temp = b;
                //    b = a % b;
                //    a = temp;
                //}
                //return a;
        }
    }

    public class Program5
    {
        public static void Main()
        {
            Solution solution = new Solution();
            IList<string> result = solution.SimplifiedFractions(4);

            foreach(var res in result)
            {
                Console.WriteLine(res);
            }
        }
    }
}

