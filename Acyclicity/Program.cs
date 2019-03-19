/*
Check whether a given directed graph with 𝑛 vertices and 𝑚 edges contains a cycle.
Input Format. A graph is given in the standard format.
Constraints. 1 ≤ 𝑛 ≤ 1000, 0 ≤ 𝑚 ≤ 1000.
Output Format. Output 1 if the graph contains a cycle and 0 otherwise.
Memory Limit. 512MB.
Sample 1.
Input:
4 4
1 2
4 1
2 3
3 1
Output:
1
Explanation:
4   3
|  /^
v v |
1 ->2
This graph contains a cycle: 3 → 1 → 2 → 3.
Sample 2.
Input:
5 7
1 2
2 3
1 3
3 4
1 4
2 5
3 5
5
Output:
0
Explanation:
    4<- 3 ->5
    ^  ^ ^  ^
    | /   \ |
    1       2
There is no cycle in this graph. This can be seen, for example, by noting that all edges in this graph
go from a vertex with a smaller number to a vertex with a larger number.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acyclicity
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
            foreach(Node neighbor in v.neighbors)
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
            foreach(Node v in graph)
            {
                if (v.visited == false)
                    Explore(v);
            }

            // If there is an edge u, v with post of u < post of v then we could say that there is a cycle in the graph
            if(graph.Where(g => g.neighbors.Any(n => g.post < n.post)).Count() == 0)
                Console.WriteLine("0");
            else
                Console.WriteLine("1");
            //Console.ReadLine();
        }
    }
}
