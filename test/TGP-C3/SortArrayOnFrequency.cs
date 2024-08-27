using System;
namespace test.TGPC3
{
	public class SortArrayOnFrequency
	{
		//static void Main()
		//{
		//	Console.WriteLine("Enter the string to be sorted");
		//	string s = Console.ReadLine();

		//	string result = FrequencySort(s);
		//	Console.WriteLine($"{result}");
		//}

		static string FrequencySort(string s)
		{
            var frequencyDict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (frequencyDict.ContainsKey(c))
                {
                    frequencyDict[c]++;
                }
                else
                {
                    frequencyDict[c] = 1;
                }
            }

            var sortedCharacters = frequencyDict
            .OrderByDescending(kv => kv.Value)  // Sort by frequency (descending)
            .ThenBy(kv => char.ToLower(kv.Key))
            //.ThenBy(kv => kv.Key.ToString(), StringComparer.Ordinal)  // Sort alphabetically (case-sensitive)
            //.ThenByDescending(kv => char.IsUpper(kv.Key))  // Prioritize uppercase letters

            .SelectMany(kv => new string(kv.Key, kv.Value));  // Create sorted string

            return string.Concat(sortedCharacters);
        }
	}
}

