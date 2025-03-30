using System;
using System.Collections.Generic;

namespace test.Arrays
{
	public class CountAnagram
	{
        static int CountAnagrams(string S, string C)
        {
            int n = S.Length, m = C.Length;
            if (m > n) return 0;

            // Frequency maps
            int[] freqC = new int[26]; // For pattern C
            int[] freqS = new int[26]; // For current window in S

            // Fill frequency of pattern C
            foreach (char ch in C)
                freqC[ch - 'a']++;

            // Fill frequency of first window in S
            for (int i = 0; i < m; i++)
                freqS[S[i] - 'a']++;

            int count = 0;

            // Sliding window
            for (int i = m; i < n; i++)
            {
                // Check if current window is an anagram
                if (IsEqual(freqC, freqS))
                    count++;

                // Slide the window
                freqS[S[i - m] - 'a']--; // Remove leftmost character
                freqS[S[i] - 'a']++;     // Add new character
            }

            // Check the last window
            if (IsEqual(freqC, freqS))
                count++;

            return count;
        }

        static bool IsEqual(int[] freqC, int[] freqS)
        {
            for (int i = 0; i < 26; i++)
                if (freqC[i] != freqS[i])
                    return false;
            return true;
        }

        //static void Main()
        //{
        //    Console.WriteLine("Enter string S:");
        //    string S = Console.ReadLine();

        //    Console.WriteLine("Enter string C:");
        //    string C = Console.ReadLine();

        //    int result = CountAnagrams(S, C);
        //    Console.WriteLine($"Output: {result}");
        //}
    }
}

