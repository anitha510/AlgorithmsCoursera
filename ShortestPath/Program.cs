/*
Given an undirected graph with n vertices and m edges and two vertices u and v, compute the length
of a shortest path between u and v (that is, the minimum number of edges in a path from u to v).
Input Format. A graph is given in the standard format. The next line contains two vertices u and v.
Constraints. 2 <= n <= 10^5, 0 <= m <= 10^5, u != v, 1 <= u; v <= n.
Output Format. Output the minimum number of edges in a path from u to v, or -1 if there is no path
Memory Limit. 512Mb.
Sample 1.
Input:
4 4
1 2
4 1
2 3
3 1
2 4
Output:
2
Explanation:
4 3
|/|
1-2
There is a unique shortest path between vertices 2 and 4 in this graph: 2 - 1 - 4.
Sample 2.
Input:
5 4
5 2
1 3
3 4
1 4
3 5
Output:
-1
Explanation:
3-4   5
|/    |
1     2
There is no path between vertices 3 and 5 in this graph.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    class Node
    {
        internal int vertex;
        internal int distance;
        internal List<Node> neighbors;

        internal Node(int v)
        {
            vertex = v;
            distance = 0;
            neighbors = new List<Node>();
        }
    }

    class Program
    {
        static int ShortestPathBetween(Node u, Node v)
        {
            Node tmp;
            Queue<Node> q = new Queue<Node>();
            u.distance = 1;
            q.Enqueue(u);
            while (q.Count > 0)
            {
                tmp = q.Dequeue();
                foreach(Node neighbor in tmp.neighbors)
                {
                    if(neighbor.vertex == v.vertex) //Found the vertex 
                    {
                        return tmp.distance;
                    }

                    if(neighbor.distance == 0) //not visited yet
                    {
                        neighbor.distance = tmp.distance + 1;
                        q.Enqueue(neighbor);
                    }
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            int vertices = tokens[0];
            int edges = tokens[1];
            Node[] graph = new Node[vertices];
            for (int v = 0; v < vertices; v++)
            {
                graph[v] = new Node(v);
            }
            int vertex1, vertex2;
            for (int e = 1; e <= edges; e++)
            {
                //Read each edge
                tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                vertex1 = tokens[0] - 1;
                vertex2 = tokens[1] - 1;
                // Add neighbors for both vertices since this is an undirected graph
                graph[vertex1].neighbors.Add(graph[vertex2]);
                graph[vertex2].neighbors.Add(graph[vertex1]);
            }
            tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            vertex1 = tokens[0] - 1;
            vertex2 = tokens[1] - 1;
            Console.WriteLine(ShortestPathBetween(graph[vertex1], graph[vertex2]));

            //Console.ReadLine();
        }
    }
}
