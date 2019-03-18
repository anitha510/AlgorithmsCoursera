/*
Given an undirected graph and two distinct vertices 𝑢 and 𝑣, check if there is a path between 𝑢 and 𝑣.
Input Format. An undirected graph with 𝑛 vertices and 𝑚 edges. The next line contains two vertices 𝑢
and 𝑣 of the graph.
Constraints. 2 ≤ 𝑛 ≤ 1000; 1 ≤ 𝑚 ≤ 1000; 1 ≤ 𝑢, 𝑣 ≤ 𝑛; 𝑢 ̸= 𝑣.
Output Format. Output 1 if there is a path between 𝑢 and 𝑣 and 0 otherwise.
Memory Limit. 512Mb.
Sample 1.
Input:
4 4
1 2
3 2
4 3
1 4
1 4
Output:
1
Explanation:
1--2
|  |
4--3
In this graph, there are two paths between vertices 1 and 4: 1-4 and 1-2-3-4.
Sample 2.
Input:
4 2
1 2
3 2
1 4
Output:
0
Explanation:
1--2
   |
4  3
In this case, there is no path from 1 to 4. 
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphPathExists
{
    class Node
    {
        internal int vertex;
        internal bool visited;
        internal List<Node> neighbors = new List<Node>();

        internal Node(int v)
        {
            vertex = v;
        }
    }

    class Program
    {
        static bool Reachable(Node v1, Node v2)
        {
            v1.visited = true;
            foreach(Node neighbor in v1.neighbors.Where(n=>n.visited == false))
            {
                if (neighbor.vertex == v2.vertex)
                    return true;
                if (Reachable(neighbor, v2))
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            int vertices = tokens[0];
            int edges = tokens[1];
            Node[] graph = new Node[vertices];
            for(int v=0;v<vertices;v++)
            {
                graph[v] = new Node(v);
            }
            int vertex1, vertex2;
            for(int e=1;e<=edges;e++)
            {
                //Read each edge
                tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                vertex1 = tokens[0] - 1;
                vertex2 = tokens[1] - 1;
                //Add each edge to th adj list
                graph[vertex1].neighbors.Add(graph[vertex2]);
                graph[vertex2].neighbors.Add(graph[vertex1]);
            }
            //Read the vertices to find if there is path between them
            tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            vertex1 = tokens[0] - 1;
            vertex2 = tokens[1] - 1;

            if (Reachable(graph[vertex1], graph[vertex2]))
                Console.WriteLine("1");
            else
                Console.WriteLine("0");

            //Console.ReadLine();
        }
    }
}
