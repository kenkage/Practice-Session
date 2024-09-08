using System;
namespace test.DynamicProgramming
{
	public class TheNewClassmate
	{
		//static void Main()
		//{
  //          int n = Convert.ToInt32(Console.ReadLine());  
  //          string s = Console.ReadLine(); 

  //          int result = GreatestLexicographicalSequenceSize(n, s, 0, 0); 
  //          Console.WriteLine(result); 
  //      }

        static int GreatestLexicographicalSequenceSize(int n, string s, int index, int count)
        {
            char lastChar = (char)('a' - 1);

            if (index < n && s[index] >= lastChar)
            {
                lastChar = s[index];
                count++;
            }
            int size = GreatestLexicographicalSequenceSize(n, s, index + 1, count);
            return size;
        }
    }
}

