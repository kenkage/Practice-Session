using System;
namespace test
{
    public class FirstUniqueCharSolution
    {
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();

            foreach(var ch in s)
            {
                if (count.ContainsKey(ch)){
                    count[ch]++;
                }
                else
                {
                    count[ch] = 1;
                }
            }

            for(int i=0; i<s.Length; i++)
            {
                if (count[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }

    public class FirstUniqueCharacter
    {
        public static void Run()
        {
            FirstUniqueCharSolution solution = new FirstUniqueCharSolution();
            string input = "loveleetcode";
            int result = solution.FirstUniqChar(input);
            Console.WriteLine(result); // Output: 2
        }
    }
}
