/*
Given an directed graph with possibly negative edge weights and with n vertices and m edges, check
whether it contains a cycle of negative weight.
Input Format. A graph is given in the standard format.
Constraints. 1 <= n <= 1000, 0 <= m <= 10000, edge weights are integers of absolute value at most 1000.
Output Format. Output 1 if the graph contains a cycle of negative weight and 0 otherwise.
Memory Limit. 512Mb.
Sample 1.
Input:
4 4
1 2 -5
4 1 2
2 3 2
3 1 1
Output:
1
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace NegativeCycle
{
    class Node
    {
        internal int vertex;
        internal int distance;
        internal bool visited;
        internal Node(int v)
        {
            vertex = v;
            distance = int.MaxValue;
            visited = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            int vertices = tokens[0];
            int edges = tokens[1];
            Node[] graph = new Node[vertices];
            int[,] edgeList = new int[edges,3];
            bool relaxed = false;
            int vertex1, vertex2, weight, source;

            for (int v = 0; v < vertices; v++)
            {
                graph[v] = new Node(v);
            }

            for (int e = 0; e < edges; e++)
            {
                //Read each edge
                tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                edgeList[e, 0] = tokens[0] - 1;
                edgeList[e, 1] = tokens[1] - 1;
                edgeList[e, 2] = tokens[2];
            }

            //Repeat until -ve loop is found or untill all clusters are visited
            while(relaxed == false && graph.Any(g => g.visited == false)) 
            {
                //reset the distances
                foreach(Node node in graph)
                    node.distance = int.MaxValue;

                //choose a source which was not visited before
                source = graph.First(g => g.visited == false).vertex;
                graph[source].distance = 0;

                //Bellman–Ford algorithm
                for(int v=1;v<=vertices;v++)
                {
                    relaxed = false;
                    for(int e=0;e<edges;e++)
                    {
                        vertex1 = edgeList[e, 0];
                        vertex2 = edgeList[e, 1];
                        weight = edgeList[e, 2];
                        if(graph[vertex1].distance != int.MaxValue && graph[vertex1].distance + weight < graph[vertex2].distance)
                        {
                            graph[vertex2].distance = graph[vertex1].distance + weight;
                            relaxed = true;
                        }
                    }

                    // If none of the edges are relaxed in the last iteration, then there is no -ve loop
                    if(relaxed == false)
                        break;
                }
                
                //Mark all reachable nodes as visited
                foreach(Node node in graph.Where(g => g.distance != int.MaxValue))
                    node.visited = true;
            }
            
            if (relaxed)
                Console.WriteLine("1");
            else
                Console.WriteLine("0");
            //Console.ReadLine();
        }
    }
}
