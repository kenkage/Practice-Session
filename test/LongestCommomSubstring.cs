using System;
namespace test
{
	public class LongestCommomSubstrings
	{
        //static void Main()
        //{
        //    Console.Write("Enter the first string: ");
        //    string? str1 = Console.ReadLine();

        //    Console.Write("Enter the second string: ");
        //    string? str2 = Console.ReadLine();

        //    //string result = LCS(str1, str2);
        //    string result = FindLongestCommonSubstring(str1, str2);
            
        //    Console.WriteLine("Longest common substring: " + result);
        //}

        // With Dynamic Programming
        //public static string LCS(string? str1, string? str2)
        //      {
        //          int m = str1.Length;
        //          int n = str2.Length;
        //          int[,] arr = new int[m + 1, n + 1];
        //          int length = 0;
        //          int endingIndex = 0;

        //          for (int i = 1; i <= m; i++)
        //          {
        //              for (int j = 1; j <= n; j++)
        //              {
        //                  if (str1[i - 1] == str2[j - 1])
        //                  {
        //                      arr[i, j] = arr[i - 1, j - 1] + 1;
        //                      if (length < arr[i, j])
        //                      {
        //                          length = arr[i, j];
        //                          endingIndex = i;
        //                      }
        //                  }
        //                  else
        //                  {
        //                      arr[i, j] = 0;
        //                  }
        //              }
        //          }

        //          return str1.Substring(endingIndex - length, length);
        //      }

        public static string FindLongestCommonSubstring(string str1, string str2)
        {
            int maxLength = 0;
            int endingIndex = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    int length = LongestCommonSubstringRecursive(str1, str2, i, j, 0);

                    if (length > maxLength)
                    {
                        maxLength = length;
                        endingIndex = i;
                    }
                }
            }
            if (maxLength == 0)
            {
                return "";
            }
            int startIndex = endingIndex - maxLength + 1;

            return str1.Substring(startIndex, maxLength);
        }

        public static int LongestCommonSubstringRecursive(string str1, string str2, int i, int j, int count)
        {
            if (i >= str1.Length || j >= str2.Length)
            {
                return count;
            }

            if (str1[i] == str2[j])
            {
                count = LongestCommonSubstringRecursive(str1, str2, i + 1, j + 1, count + 1);
            }

            return count;
        }
    }
}

