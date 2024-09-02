/*
 * Group Anangrams
Given an array of strings strs, group the anagrams together.Print the group of anagrams with a single space between them and each group in new line.Also, Print output the list of anagrams in lexicographically sorted order.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Input Format:
* first line contains a single integer n (size of the array).
* second line contains n strings.

Output Format:
Print the group of anagrams with a single space between them
* Each group in new line

Constraints:
* 1 <= n <= 10^4
* 0 <= strs[i].length <= 100
* strs[i] consists of lowercase English letters.

Example:
Input:
6
eat tea tan ate nat bat
Output: 
ate eat tea
bat
nat tan
Explanation:
As ate comes before bat so the group of anagrams of ate should come before group of anagrams of bat. same for others.
 */

namespace test.TGPC3
{
    public class GroupAnagrams
	{
		//static void Main()
		//{
  //          int n = 6;
  //          //int n = int.Parse(Console.ReadLine());
  //          string[] strs = new string[n];
  //          strs = Console.ReadLine().Split(' ');
  //          //string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

  //          GroupAnagram(n, strs);
  //      }

		static void GroupAnagram(int n, string[] strs)
		{
            var anagramGroups = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var sortedStr = String.Concat(str.OrderBy(c => c));
                if (!anagramGroups.ContainsKey(sortedStr))
                {
                    anagramGroups[sortedStr] = new List<string>();
                }
                anagramGroups[sortedStr].Add(str);
            }

            var sortedGroups = anagramGroups
                .Select(group => group.Value.OrderBy(word => word).ToList())
                .OrderBy(group => group.First())
                .ToList();

            foreach (var group in sortedGroups)
            {
                Console.WriteLine(string.Join(" ", group));
            }
        }
	}
}

