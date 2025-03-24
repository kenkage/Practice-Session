using System;
using System.Collections.Generic;

namespace test.Sorting
{
	public class RestaurantTip
	{
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine()); // Read number of friends
            int[] food = Console.ReadLine().Split().Select(int.Parse).ToArray(); // Food consumption
            int[] budget = Console.ReadLine().Split().Select(int.Parse).ToArray(); // Budget

            Console.WriteLine(MaxDays(n, food, budget)); // Output max days
        }

        static int MaxDays(int n, int[] food, int[] budget)
        {
            List<(int food, int budget)> friends = new List<(int food, int budget)>();

            for (int i = 0; i < n; i++)
                friends.Add((food[i], budget[i]));

            int days = 0;

            friends.Sort((a, b) => b.budget.CompareTo(a.budget));

            //HashSet<int> used = new HashSet<int>(); // Keep track of used friends // this fails in case of duplicate budget/food amount.
            // 6
            // 2 3 6 9 5 7
            // 3 2 7 10 6 10
            bool[] used = new bool[n]; // Track used friends

            for (int i = 0; i < n; i++)
            {
                if (used[i]) continue; // Skip already used friends

                int totalFood = friends[i].food;
                int totalBudget = friends[i].budget;
                List<int> group = new List<int> { i }; // Store indices of the group

                for (int j = i + 1; j < n; j++)
                {
                    if (used[j]) continue; // Skip already used

                    totalFood += friends[j].food;
                    totalBudget += friends[j].budget;
                    group.Add(j);

                    // Ensure at least two people in a valid group
                    if (group.Count >= 2 && totalBudget >= totalFood)
                    {
                        // Mark these friends as used
                        foreach (var idx in group)
                            used[idx] = true;

                        days++;
                        break; // Move to the next day
                    }
                }
            }
            return days;
        }
    }
}

