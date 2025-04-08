using System;
namespace test.DynamicProgramming
{
	public class StolenGifts
	{
        public static int CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);  // Step 1: Sort to handle duplicates
            List<IList<int>> result = new List<IList<int>>();
            Backtrack(candidates, target, 0, new List<int>(), result);
            return result.Count;
        }

        private static void Backtrack(int[] candidates, int target, int start, List<int> current, List<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current)); // Valid combination
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                // Skip duplicates
                if (i > start && candidates[i] == candidates[i - 1]) continue;

                if (candidates[i] > target) break; // No need to continue

                current.Add(candidates[i]);
                Backtrack(candidates, target - candidates[i], i + 1, current, result); // i + 1 since no reuse i.e. Go deeper with this choice.
                current.RemoveAt(current.Count - 1); // Backtrack... Undo that choice (so we can try the next option).
            }
        }

        static void Main()
        {
            string[] line1 = Console.ReadLine().Split();
            int n = int.Parse(line1[0]);
            int k = int.Parse(line1[1]);

            int[] gifts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(CombinationSum2(gifts, k));
        }
    }
}

