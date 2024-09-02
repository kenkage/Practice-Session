/*
 * Remove K digits
Given a non-negative integer represented as a string num and an integer k, remove k digits from the number so that the new number is the smallest possible. The remaining digits should maintain their original order in the string. Return the result as a string.
Input Format:
* The first line contains the string num, representing the non-negative integer.
* The second line contains the integer k.
Output Format:
* Print the smallest possible integer as a string after removing k digits.
Sample Input 1:
1432219
3

Sample Output 1:
1219

Explanation:
Removing the digits 4, 3, and 2 from "1432219" leads to the new number "1219", which is the smallest possible result.

Sample Input 2:
10200
1

Sample Output 2:
200

Explanation:
Removing one digit (the leading 1) from "10200" results in "0200", and removing the leading zeroes gives "200" as the smallest possible result.
 */

using System;
using System.Text;

namespace test.TGPC4
{	
	public class RemoveDigits
	{
		//static void Main()
		//{
		//	string num = "1432219";
		//	int k = 3;
		//	string result = Remove_K_Digits(num, k);
        //   string res1 = Remove_K_Digits_UsingList(num, k);
		//	Console.WriteLine($"{res1}");
		//}

		static string Remove_K_Digits(string num, int k)
		{
            if(k == 0) return num;
            if (k == num.Length) return "0";

            var stack = new Stack<char>();
            foreach (var ch in num)
            {
                while (k > 0 && stack.Count > 0 && ch < stack.Peek())
                {
                    k--;
                    stack.Pop();
                }
                stack.Push(ch);
            }

            while (k-- > 0 && stack.Count > 0)
                stack.Pop();
            if (stack.Count == 0) return "0";

            var sb = new StringBuilder();
            foreach (var ch in stack)
                sb.Append(ch);

            var result = new StringBuilder();
            bool leadingZero = true;
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                if (leadingZero && sb[i] == '0') { continue; }
                leadingZero = false;
                result.Append(sb[i]);
            }

            return result.Length > 0 ? result.ToString() : "0";
        }

        static string Remove_K_Digits_UsingList(string num, int k)
        {
            var list = new List<char>();

            foreach (char digit in num)
            {
                // Remove digits from the list if the current digit is smaller
                // than the last digit in the list and we still need to remove more digits
                while (k > 0 && list.Count > 0 && list.Last() > digit)
                {
                    list.RemoveAt(list.Count - 1);
                    k--;
                }
                list.Add(digit);
            }

            // If we still need to remove digits, remove from the end
            while (k > 0)
            {
                list.RemoveAt(list.Count - 1);
                k--;
            }

            // Build the result string from the list
            var resultString = new string(list.ToArray()).TrimStart('0');

            // Handle the case where the result might be empty
            return resultString.Length == 0 ? "0" : resultString;
        }
	}
}

// https://leetcode.com/problems/remove-k-digits/description/