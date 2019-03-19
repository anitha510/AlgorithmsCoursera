/*
Compute a topological ordering of a given directed acyclic graph (DAG) with 𝑛 vertices and 𝑚 edges.
Input Format. A graph is given in the standard format.
Constraints. 1 ≤ 𝑛 ≤ 10^5, 0 ≤ 𝑚 ≤ 10^5. The given graph is guaranteed to be acyclic.
Output Format. Output any topological ordering of its vertices. (Many DAGs have more than just one
topological ordering. You may output any of them.)
Memory Limit. 512MB.
Sample 1.
Input:
4 3
1 2
4 1
3 1
Output:
4 3 1 2
Sample 2.
Input:
4 1
3 1
Output:
2 3 1 4
Sample 3.
Input:
5 7
2 1
3 2
3 1
4 3
4 1
5 2
5 3
Output:
5 4 3 2 1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopologicalOrdering
{
    class Node
    {
        internal int vertex;
        internal int pre;
        internal int post;
        internal bool visited;
        internal List<Node> neighbors = new List<Node>();

        internal Node(int v)
        {
            vertex = v;
        }
    }

    class Program
    {
        static int count = 0;
        static void Explore(Node v)
        {
            v.visited = true;
            v.pre = count++;
            foreach (Node neighbor in v.neighbors)
            {
                if (neighbor.visited == false)
                    Explore(neighbor);
            }
            v.post = count++;
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
                //Add each edge to th adj list
                graph[vertex1].neighbors.Add(graph[vertex2]);
            }

            // Do a DFS and compute post order
            foreach (Node v in graph)
            {
                if (v.visited == false)
                    Explore(v);
            }

            StringBuilder result = new StringBuilder("");
            foreach (Node node in graph.OrderByDescending(g => g.post))
                result.Append((node.vertex + 1).ToString() + " ");

            Console.WriteLine(result);
            //Console.ReadLine();
        }
    }
}
