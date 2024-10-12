/*

Critical Connection
Given a network of n servers connected by undirected server-to-server connections, identify all the critical connections in the network.
A critical connection is defined as a connection that, if removed, would result in some servers being unable to reach other servers.

Definitions:

Servers are numbered from 0ton - 1.
Connections are represented by pairs of integers [ai, bi], indicating a bidirectional connection between servers aiandbi.
A server can reach another server if there is a path of connections from one to the other.
Input Format:

The first line contains two space-separated integers nandm, where nis the number of servers andm is the number of connections.
The next m lines each contain two space-separated integers representing a connection between two servers.
Output Format:

Print the critical connections in any order. Each critical connection should be printed as two space-separated integers per line.
If there are no critical connections, print -1.
Sample Input:

7 8
6 1
4 2
2 5
1 5
0 1
1 2
2 0
1 3
Sample Output:

1 6
2 4
1 3
Constraints:

	2 <= n <= 10^5
	n - 1 <= connections.length <= 10^5
	0 <= ai, bi <= n - 1
	ai != bi
	Connections are unique and undirected.

Explanation: In this example, the network consists of 7 servers and 8 connections. The critical connections are between servers 1-6, 2-4, and 1-3.
Removing any of these connections would result in at least one server being isolated from the rest of the network.

 */



using System;
namespace test.TGPC5
{
	public class CriticalConnection
	{
		public CriticalConnection()
		{
		}
	}
}

