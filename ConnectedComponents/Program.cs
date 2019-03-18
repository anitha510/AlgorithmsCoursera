/*
Given an undirected graph with 𝑛 vertices and 𝑚 edges, compute the number of connected components
in it.
Input Format. A graph is given in the standard format.
Constraints. 1 ≤ 𝑛 ≤ 1000, 0 ≤ 𝑚 ≤ 1000.
Output Format. Output the number of connected components.
Memory Limit. 512Mb.
Sample 1.
Input:
4 2
1 2
3 2
Output:
2
Explanation:
1--2
   |
4  3
There are two connected components here: {1, 2, 3} and {4}.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    class Node
    {
        internal int vertex;
        internal int component;
        internal bool visited;
        internal List<Node> neighbors = new List<Node>();

        internal Node(int v)
        {
            vertex = v;
        }
    }

    class Program
    {
        static void Explore(Node v, int component)
        {
            v.visited = true;
            v.component = component;
            foreach (Node neighbor in v.neighbors.Where(n => n.visited == false))
            {
                Explore(neighbor, component);
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
            int vertex1, vertex2, component = 0;
            for (int e = 1; e <= edges; e++)
            {
                //Read each edge
                tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                vertex1 = tokens[0] - 1;
                vertex2 = tokens[1] - 1;
                //Add each edge to th adj list
                graph[vertex1].neighbors.Add(graph[vertex2]);
                graph[vertex2].neighbors.Add(graph[vertex1]);
            }
            foreach(Node v in graph)
            {
                if (v.visited == false)
                    Explore(v, ++component);
            }
            Console.WriteLine(component.ToString());

            //Console.ReadLine();
        }
    }
}
