using System;
using System.Collections.Generic;

class BerloggingVictory
{
    //static void Main(string[] args)
    //{
    //    int n = int.Parse(Console.ReadLine());

    //    // Initialize dictionaries
    //    Dictionary<string, int> scores = new Dictionary<string, int>();
    //    List<(string name, int round, int cumulativeScore)> scoreHistory = new List<(string, int, int)>();

    //    for (int i = 0; i < n; i++)
    //    {
    //        string[] input = Console.ReadLine().Split();
    //        string player = input[0];
    //        int scoreChange = int.Parse(input[1]);

    //        // Update cumulative score for the player
    //        if (!scores.ContainsKey(player))
    //        {
    //            scores[player] = 0;
    //        }
    //        scores[player] += scoreChange;

    //        // Record the round and cumulative score for the player
    //        scoreHistory.Add((player, i + 1, scores[player]));
    //    }

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

    //    Console.WriteLine(winner);
    //}
}