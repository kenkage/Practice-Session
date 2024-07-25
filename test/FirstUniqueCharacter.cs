//public class Solution
//{
//    public int FirstUniqChar(string s)
//    {
//        Dictionary<char, int> count = new Dictionary<char, int>();

//        foreach(var ch in s)
//        {
//            if (count.ContainsKey(ch)){
//                count[ch]++;
//            }
//            else
//            {
//                count[ch] = 1;
//            }
//        }

//        for(int i=0; i<s.Length; i++)
//        {
//            if (count[s[i]] == 1)
//            {
//                return i;
//            }
//        }

//        return -1;
//    }
//}

//// Example usage
//public class Program
//{
//    public static void Main()
//    {
//        Solution solution = new Solution();
//        string input = "loveleetcode";
//        int result = solution.FirstUniqChar(input);
//        Console.WriteLine(result); // Output: 0

        
//    }
//}