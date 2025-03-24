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

            HashSet<int> used = new HashSet<int>(); // Keep track of used friends

            for (int i = 0; i < n - 1; i++)  // At least two people per group
            {
                if (used.Contains(i)) continue; // Skip used friends

                int totalFood = friends[i].food;
                int totalBudget = friends[i].budget;
                int count = 1; // Count of people in the group

                for (int j = i + 1; j < n; j++)
                {
                    if (used.Contains(j)) continue; // Skip used friends

                    totalFood += friends[j].food;
                    totalBudget += friends[j].budget;
                    count++;

                    // Check if this group is valid
                    if (count >= 2 && totalBudget >= totalFood)
                    {
                        // Mark these friends as used
                        used.Add(i);
                        used.Add(j);
                        days++;
                        break; // Move to the next day
                    }
                }
            }
            return days;
        }
    }
}

