using System;
namespace test.Sets
{
	public class Berlogging
	{
        //static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine()); // Number of rounds
        //    Dictionary<string, int> scores = new Dictionary<string, int>();
        //    Dictionary<string, int> firstReached = new Dictionary<string, int>();
        //    int maxScore = int.MinValue;

        //    // Process each round
        //    for (int i = 0; i < n; i++)
        //    {
        //        string[] input = Console.ReadLine().Split(' ');
        //        string name = input[0];
        //        int scoreChange = int.Parse(input[1]);

        //        // Update scores
        //        if (!scores.ContainsKey(name))
        //        {
        //            scores[name] = 0;
        //        }
        //        scores[name] += scoreChange;

        //        // Check for maximum score
        //        if (scores[name] > maxScore)
        //        {
        //            maxScore = scores[name];
        //        }

        //        // Track when each player reaches their scores
        //        if (!firstReached.ContainsKey(name))
        //        {
        //            firstReached[name] = 0; // Initialize if not present
        //        }

        //        // If the player's score has reached the maxScore, record the round number
        //        if (scores[name] >= maxScore)
        //        {
        //            firstReached[name] = i; // Store the round index when they reach or exceed max score
        //        }
        //    }

        //    List<string> potentialWinners = new List<string>();

        //    foreach (var player in scores)
        //    {
        //        if (player.Value == maxScore)
        //        {
        //            potentialWinners.Add(player.Key);
        //        }
        //    }

        //    // Find who reached maxScore first
        //    string winner = potentialWinners[0];
        //    int earliestRound = firstReached[winner];

        //    foreach (var player in potentialWinners)
        //    {
        //        if (firstReached[player] < earliestRound)
        //        {
        //            winner = player;
        //            earliestRound = firstReached[player];
        //        }
        //    }

        //    Console.WriteLine(winner);
        //}

        //static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());

        //    Dictionary<string, int> scores = new Dictionary<string, int>();
        //    List<(string name, int round, int cumulativeScore)> scoreHistory = new List<(string, int, int)>();

        //    // Process each round
        //    for (int i = 0; i < n; i++)
        //    {
        //        string[] input = Console.ReadLine().Split();
        //        string player = input[0];
        //        int scoreChange = int.Parse(input[1]);

        //        if (!scores.ContainsKey(player))
        //        {
        //            scores[player] = 0;
        //        }
        //        scores[player] += scoreChange;

        //        // Record the round and cumulative score for the player
        //        scoreHistory.Add((player, i + 1, scores[player]));
        //    }

        //    // Find the maximum score
        //    int maxScore = int.MinValue;
        //    foreach (var score in scores.Values)
        //    {
        //        if (score > maxScore)
        //        {
        //            maxScore = score;
        //        }
        //    }

        //    // Determine who reached the max score first
        //    string winner = null;
        //    foreach (var record in scoreHistory)
        //    {
        //        if (record.cumulativeScore >= maxScore)
        //        {
        //            winner = record.name;
        //            break;
        //        }
        //    }

        //    // Print the winner
        //    Console.WriteLine(winner);
        //}
    }
}