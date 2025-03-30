using System;
using System.Text;

namespace test.Strings
{
	public class MarsMission
	{
        static string ConvertToAlienSentence(string s)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            List<string> segments = new List<string>(); // Store segments
            int i = 0;

            while (i < s.Length)
            {
                // (CVC) case
                if (i + 2 < s.Length && !vowels.Contains(s[i]) && vowels.Contains(s[i + 1]) && !vowels.Contains(s[i + 2]))
                {
                    segments.Add(s.Substring(i, 3));
                    i += 3;
                }
                // (CV) case
                else if (i + 1 < s.Length && !vowels.Contains(s[i]) && vowels.Contains(s[i + 1]))
                {
                    segments.Add(s.Substring(i, 2));
                    i += 2;
                }
                i++;
            }

            return string.Join(" ", segments); // Efficient joining
        }

        //static void Main()
        //{
        //    //int n = int.Parse(Console.ReadLine());
        //    string s = Console.ReadLine();
        //    Console.WriteLine(ConvertToAlienSentence(s));
        //}
    }
}

