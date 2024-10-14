/*

Star graph
There is an undirected star graph consisting of n nodes labeled from 1 to n. A star graph is a graph where there is one center node and exactly n - 1 edges that connect the center node with every other node.

You are given a 2D integer array edges where each edges[i] = [ui, vi] indicates that there is an edge between the nodes ui and vi. Return the center of the given star graph.

Example 1

image

Input

edges = [[1,2],[2,3],[4,2]]
Output

2
Explanation:

Node 2 is connected to every other node, so 2 is the center.

Input Format:

The first line contains an integer n, representing the number of nodes in the star graph.
Following this, there are n - 1 lines, each containing two space-separated integers ui and vi, representing an edge between the nodes ui and vi.
Output Format:

Output a single integer representing the label of the center node in the given star graph.
Sample Input 1:

18
8 2
8 3
4 8
1 8
8 5
6 8
7 8
9 8
11 8
10 8
8 12
13 8
14 8
8 15
16 8
17 8
8 18
19 8
Sample Output 1:

8

 */


using System;
namespace test.TGPC5
{
	public class StarGraph
	{
        static int FindCenter(int[][] edges, int n)
        {
            //// The center of the star graph must appear in both of the first two edges
            //int u1 = edges[0][0], v1 = edges[0][1];
            //int u2 = edges[1][0], v2 = edges[1][1];

            //// If either u1 or v1 is common in both edges, that is the center
            //if (u1 == u2 || u1 == v2)
            //    return u1;
            //return v1;

            // Create a dictionary to store the degree (connection count) of each node
            Dictionary<int, int> degree = new Dictionary<int, int>();

            // Populate the degree of each node
            foreach (var edge in edges)
            {
                if (!degree.ContainsKey(edge[0])) degree[edge[0]] = 0;
                if (!degree.ContainsKey(edge[1])) degree[edge[1]] = 0;

                degree[edge[0]]++;
                degree[edge[1]]++;
            }

            // The center node must have exactly n-1 connections
            foreach (var node in degree)
            {
                if (node.Value == n - 1)
                {
                    return node.Key;
                }
            }

            // If no center is found, return -1 (should not happen in a valid star graph)
            return -1;
        }

        //public static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[][] edges = new int[n - 1][];

        //    // Read the edges
        //    for (int i = 0; i < n - 1; i++)
        //    {
        //        string[] input = Console.ReadLine().Split();
        //        edges[i] = new int[] { int.Parse(input[0]), int.Parse(input[1]) };
        //    }
            
        //    int center = FindCenter(edges, n);

        //    // Output the center
        //    Console.WriteLine(center);
        //}
    }
}

