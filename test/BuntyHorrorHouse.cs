using System;
using System.IO;

namespace test
{
    class BuntyHorrorHouse
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int[][] maze = new int[N][];

            for (int i = 0; i < N; i++)
            {

                maze[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            }
            List<string> path = new List<string>();
            int totalPaths = CountPaths(maze, 0, 0, N, path);
            Console.WriteLine($"Total Paths: {totalPaths}");
        }

        static int CountPaths(int[][] maze, int i, int j, int N, List<string> path, string direction = null)
        {
            // Base case: If Bunty reaches the bottom-right corner
            if (i == N - 1 && j == N - 1)
            {
                path.Add($"({i},{j})");
                Console.WriteLine(string.Join(" -> ", path));
                path.RemoveAt(path.Count - 1);
                return 1;
            }

            // If the current position is out of bounds or blocked, return 0
            if (i < 0 || i >= N || j < 0 || j >= N || maze[i][j] == 0) return 0;

            // Mark the cell as visited
            maze[i][j] = 0;
            path.Add($"({i},{j})");

            // Explore all four directions
            int paths =   CountPaths(maze, i + 1, j, N, path, "Down")  // Down
                        + CountPaths(maze, i - 1, j, N, path, "Up")  // Up
                        + CountPaths(maze, i, j + 1, N, path, "Rigth")  // Right
                        + CountPaths(maze, i, j - 1, N, path, "Left");  // Left

            // Backtrack: Mark the cell as unvisited
            maze[i][j] = 1;
            path.RemoveAt(path.Count - 1);
            return paths;
        }
    }
}

