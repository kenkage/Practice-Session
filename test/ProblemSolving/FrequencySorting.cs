using System;
namespace test.ProblemSolving
{
	public class FrequencySorting
	{
        static string FrequencySort(string s)
        {
            // Step 1: Count the frequency of each character
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (freqMap.ContainsKey(c))
                    freqMap[c]++;
                else
                    freqMap[c] = 1;
            }

            // Step 2: Create a bucket array for sorting by frequency
            int n = s.Length;
            List<char>[] buckets = new List<char>[n + 1];

            foreach (var pair in freqMap)
            {
                int freq = pair.Value;
                char ch = pair.Key;
                if (buckets[freq] == null)
                    buckets[freq] = new List<char>();
                buckets[freq].Add(ch);
            }

            // Step 3: Build the result string from highest frequency to lowest
            char[] result = new char[n];
            int index = 0;

            for (int i = n; i > 0; i--)
            {
                if (buckets[i] != null)
                {
                    // Manual lexicographic sorting (Bubble Sort for simplicity)
                    for (int x = 0; x < buckets[i].Count - 1; x++)
                    {
                        for (int y = 0; y < buckets[i].Count - x - 1; y++)
                        {
                            if (buckets[i][y] > buckets[i][y + 1]) // Sorting alphabetically
                            {
                                char temp = buckets[i][y];
                                buckets[i][y] = buckets[i][y + 1];
                                buckets[i][y + 1] = temp;
                            }
                        }
                    }

                    // Append sorted characters to result array
                    foreach (char ch in buckets[i])
                    {
                        for (int j = 0; j < i; j++)
                            result[index++] = ch;
                    }
                }
            }

            return new string(result);
        }

        static string FrequencySort2(string s) // other way round
        {
            // Step 1: Count frequency of each character
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (freqMap.ContainsKey(c))
                    freqMap[c]++;
                else
                    freqMap[c] = 1;
            }

            // Step 2: Sort characters based on frequency and then lexically
            var sortedChars = freqMap.OrderByDescending(x => x.Value) // Sort by frequency (descending)
                                     .ThenBy(x => x.Key) // If same frequency, sort lexically
                                     .ToList();

            // Step 3: Build the output string
            string result = "";
            foreach (var pair in sortedChars)
            {
                result += new string(pair.Key, pair.Value);
            }

            return result;
        }
        //static void Main()
        //{
        //    string s = Console.ReadLine();

        //    Console.WriteLine(FrequencySort(s));
        //}
    }
}

