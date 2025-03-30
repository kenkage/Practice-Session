using System;
using System.Runtime.InteropServices;

namespace test.Sets
{
	public class UniquePermutation
	{
        static void FindPermutations(char[] chars, bool[] used, List<char> current, SortedSet<string> result)
        {
            if (current.Count == chars.Length)
            {
                result.Add(new string(current.ToArray()));
                return;
            }

            for (int i = 0; i < chars.Length; i++)
            {
                // Skip already used characters
                if (used[i]) continue;

                // Skip duplicate characters to avoid redundant permutations
                if (i > 0 && chars[i] == chars[i - 1] && !used[i - 1]) continue;

                used[i] = true;
                current.Add(chars[i]);

                FindPermutations(chars, used, current, result);

                // Backtrack
                used[i] = false;
                current.RemoveAt(current.Count - 1);
            }
        }

        //static void Main()
        //{
        //    // Read input string
        //    string s = Console.ReadLine().Trim();

        //    // Convert to lowercase (if needed) for case-insensitive lexicographical order
        //    char[] chars = s.ToCharArray();
        //    Array.Sort(chars); // Sort for lexicographical order

        //    SortedSet<string> result = new SortedSet<string>();
        //    FindPermutations(chars, new bool[chars.Length], new List<char>(), result);

        //    // Print each unique permutation
        //    foreach (string perm in result)
        //        Console.WriteLine(perm);
        //}
    }
}

