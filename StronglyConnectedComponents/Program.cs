/*
Compute the number of strongly connected components of a given directed graph with 𝑛 vertices and
𝑚 edges.
Input Format. A graph is given in the standard format.
Constraints. 1 ≤ 𝑛 ≤ 10^4, 0 ≤ 𝑚 ≤ 10^4.
Output Format. Output the number of strongly connected components.
Memory Limit. 512MB.
Sample 1.
Input:
4 4
1 2
4 1
2 3
3 1
Output:
2
This graph has two strongly connected components: {1, 3, 2}, {4}.

Sample 2.
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
5
This graph has five strongly connected components: {1}, {2}, {3}, {4}, {5}.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace StronglyConnectedComponents
{
    class Node
    {
        internal int vertex;
        internal int pre;
        internal int post;
        internal bool visited_DFS;
        internal bool visited_SCC;
        internal List<Node> neighbors = new List<Node>();
        internal List<Node> neighbors_Reverse = new List<Node>();

        internal Node(int v)
        {
            vertex = v;
        }
    }

    class Program
    {
        static int count = 0;
        static void Explore_DFS(Node v)
        {
            v.visited_DFS = true;
            v.pre = count++;
            foreach (Node neighbor_R in v.neighbors_Reverse)
            {
                if (neighbor_R.visited_DFS == false)
                    Explore_DFS(neighbor_R);
            }
            v.post = count++;
        }

        static void Explore_SCC(Node v)
        {
            v.visited_SCC = true;
            foreach (Node neighbor in v.neighbors)
            {
                if (neighbor.visited_SCC == false)
                    Explore_SCC(neighbor);
            }
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
            int vertex1, vertex2, result = 0;
            for (int e = 1; e <= edges; e++)
            {
                //Read each edge
                tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                vertex1 = tokens[0] - 1;
                vertex2 = tokens[1] - 1;
                
                graph[vertex1].neighbors.Add(graph[vertex2]);
                //Reverse each edge and add it to th adj list
                graph[vertex2].neighbors_Reverse.Add(graph[vertex1]);
            }

            // Do a DFS and compute post order
            foreach (Node v in graph)
            {
                if (v.visited_DFS == false)
                    Explore_DFS(v);
            }
            
            foreach (Node node in graph.OrderByDescending(g => g.post))
            {
                if(node.visited_SCC == false)
                {
                    Explore_SCC(node);
                    result++;
                }
            }

            Console.WriteLine(result.ToString());
            //Console.ReadLine();
        }
    }
}
