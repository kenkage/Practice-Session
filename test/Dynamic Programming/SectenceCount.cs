/*  Problem: 
    Sentence Count
    Given a string 's' and a dictionary of words 'dict' of length 'n', add spaces in s to construct a sentence where each word is a valid dictionary word. Each dictionary word can be used more than once. Return the number of such possible sentences.
    
    For example:
    
    consider this Input:
    
    n=8, dict = {he hebrew brew bible isa book is a}, s="hebrewbibleisabook"
    
    Output:
    
    he brew bible isa book.
    hebrew bible isa book.
    hebrew bible is a book.
    he brew bible is a book.
    Since there are 4 possible sentences, return 4.
    
    Input format:
    
    First line contains the number of words in dictionary denoted by integer n.
    Second line contains of n space separated strings for dictionary.
    Third line contains the string which is to be transformed into a sentence.
    Constraints:
    
    1 ≤ n ≤ 20
    
    1 ≤ dict[i] ≤ 15
    
    1 ≤ |s| ≤ 500
 */


using System;
namespace test.DynamicProgramming
{
	public class SectenceCount
	{
        //static void Main()
        //{
        //    // List<string> dict = new List<string> { "he", "hebrew", "brew", "bible", "isa", "book", "is", "a" };
        //    Console.WriteLine("Enter the number of dictionary words:");
        //    int n = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Enter the dictionary words:");
        //    List<string> dict = new List<string>(Console.ReadLine().Trim().Split(' '));

        //    Console.WriteLine("Enter the string to form sentences from:");
        //    string s = "hebrewbibleisabook"; // Console.ReadLine().Trim();

        //    int result = CountSentences(s, dict);
        //    Console.WriteLine($"{result}");
        //}

        static int CountSentences(string s, List<string> dict)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return Dfs(s, dict, 0, memo);
        }

        static int Dfs(string s, List<string> dict, int start, Dictionary<int, int> memo)
        {
            if (start == s.Length)
                return 1;

            if (memo.ContainsKey(start))
                return memo[start];

            int count = 0;
            for (int end = start + 1; end <= s.Length; end++)
            {
                string word = s.Substring(start, end - start);
                if (dict.Contains(word))
                {
                    count += Dfs(s, dict, end, memo);
                }
            }
            memo[start] = count;
            return count;
        }
    }
}

