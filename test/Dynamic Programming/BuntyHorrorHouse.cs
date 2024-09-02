/*
Problem: 
Bunty in the horror house
Bunty is stuck in a horror house that consists of a N*N maze with bunty being at room [0][0]. Find the total number paths that bunty can follow to reach the exit i.e. room[N-1][N-1]. He can move in any direc­tion ( left, right, up and down).
Value of every room in the maze can either be 0 or 1. Room with value 0 are blocked means they cant be accessed and those with value 1 are open.

Input Format:

The first line of input contains an integer 'N' representing the dimension of the maze.
The next N lines of input contain N space-separated integers representing the type of the cell.

Output Format :

For each test case, print the total number of paths possible from start to exit.

Constraints:

0 < N < 11

0 <= Maze[i][j] <=1

Sample Input 1 :

3
1 0 1

1 0 1

1 1 1
Sample Output 1 :

1

Explanation: Only 1 path is possible which is:

1 0 0 

1 0 0 

1 1 1 
(1 representing the path he took) Which is printed from left to right and then top to bottom in one line. 
 
 */

using System;
using System.IO;

namespace test
{
    class BuntyHorrorHouse
    {
        //static void Main()
        //{
        //    int N = int.Parse(Console.ReadLine());
        //    int[][] maze = new int[N][];

        //    for (int i = 0; i < N; i++)
        //    {

        //        maze[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        //    }
        //    List<string> path = new List<string>();
        //    int totalPaths = CountPaths(maze, 0, 0, N, path);
        //    Console.WriteLine($"Total Paths: {totalPaths}");
        //}

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

