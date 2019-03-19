/*

*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bipartite
{
    class Node
    {
        internal int vertex;
        internal char color;
        internal List<Node> neighbors;

        internal Node(int v)
        {
            vertex = v;
            color = '\0';
            neighbors = new List<Node>();
        }
    }

    class Program
    {
        static bool IsBipartite(Node node)
        {
            Node tmp;
            char current_Color = 'B';
            Queue<Node> q = new Queue<Node>();
            node.color = current_Color; // Starting with Black
            q.Enqueue(node);
            while (q.Count > 0)
            {
                tmp = q.Dequeue();
                current_Color = (tmp.color == 'B')? 'W' : 'B';
                foreach (Node neighbor in tmp.neighbors) 
                {
                    if (neighbor.color == '\0') // Not visited yet
                    {
                        neighbor.color = current_Color;
                        q.Enqueue(neighbor);
                    }
                    else if(neighbor.color != current_Color) // Visited neighbor color mismatches with current
                    {
                        return false;
                    }
                }
            }
            return true;
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
            Console.WriteLine((IsBipartite(graph[0]))?"1":"0");

            //Console.ReadLine();
        }
    }
}
