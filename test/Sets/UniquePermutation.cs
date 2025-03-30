using System;
namespace test.Sets
{
	public class UniquePermutation
	{
        static void FindPermutations(string s, bool[] used, List<char> current, SortedSet<string> result)
        {
            if (current.Count == s.Length)
            {
                result.Add(new string(current.ToArray()));
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                // Skip already used characters
                if (used[i]) continue;

                // Skip duplicate characters to avoid redundant permutations
                if (i > 0 && s[i] == s[i - 1] && !used[i - 1]) continue;

                used[i] = true;
                current.Add(s[i]);

                FindPermutations(s, used, current, result);

                // Backtrack
                used[i] = false;
                current.RemoveAt(current.Count - 1);
            }
        }

        static void Main()
        {
            // Read input string
            string s = Console.ReadLine();

            // Sort the string to handle duplicates
            char[] arr = s.ToCharArray();
            Array.Sort(arr);
            s = new string(arr);

            SortedSet<string> result = new SortedSet<string>();
            FindPermutations(s, new bool[s.Length], new List<char>(), result);

            // Print each unique permutation
            foreach (string perm in result)
                Console.WriteLine(perm);
        }
    }
}

