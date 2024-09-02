/*
 * Longest Common Substring
Given two strings, find out the longest common substring. A substring is a contiguous segment within a string.

Input:

str1 : First String

str2 : Second string
Output:

Return a string which is a longest common substring in both str1 and str2. If there are multiple substring with longest length return which has the smallest starting index.
Examples:

Example 1:

Input:

str1 = "abcdefgabcdegh"

str2 = "abcdeghabfvsnm"
Output:

"abcdegh"
Explanation:

For the strings "abcdefgabcdegh" and "abcdeghabfvsnm":

The longest common substring is "abcdegh", appearing in the same order in both strings.
Example 2:

Input:

str1 = "abc"

str2 = "def"
Output:

""
Constraints:

1 <= str1.length <= 1000

1 <= str2.length <= 1000

str1 & str2 consist only of lowercase English letters.

Explanation:

For the strings "abc" and "def":

No common substring is present.
 */

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
                        endingIndex = j;
                    }
                }
            }
            if (maxLength == 0)
            {
                return "";
            }
            int startIndex = endingIndex - maxLength + 1;

            return str2.Substring(endingIndex, maxLength);
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