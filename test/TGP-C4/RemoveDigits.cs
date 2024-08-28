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