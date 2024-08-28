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

