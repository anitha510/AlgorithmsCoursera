/*
Given an directed graph with positive edge weights and with n vertices and m edges as well as two
vertices u and v, compute the weight of a shortest path between u and v (that is, the minimum total
weight of a path from u to v).
Input Format. A graph is given in the standard format. The next line contains two vertices u and v.
Constraints. 1 <= n <= 1000, 0 <= m <= 10^5, u != v, 1 <= u; v <= n, edge weights are non-negative integers not
exceeding 1000.
Output Format. Output the minimum weight of a path from u to v, or -1 if there is no path.
Memory Limit. 512Mb.
Sample 1.
Input:
4 4
1 2 1
4 1 2
2 3 2
1 3 5
1 3
Output:
3
There is a unique shortest path from vertex 1 to vertex 3 in this graph (1 - 2 - 3), and it has
weight 3.
4
Sample 2.
Input:
5 9
1 2 4
1 3 2
2 3 2
3 2 1
2 4 2
3 5 4
5 4 1
2 5 3
3 4 4
1 5
Output:
6
There are two paths from 1 to 5 of total weight 6: 1 - 3 - 5 and 1 - 3 - 2 - 5.
Sample 3.
Input:
3 3
1 2 7
1 3 5
2 3 2
3 2
Output:
-1
There is no path from 3 to 2.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinWeightedPath
{
    internal class PriorityQueue
    {
        int[] Vertices;
        internal int[] Distances;
        internal int[] Positions;
        int MaxSize;
        internal int Size;

        internal PriorityQueue(int capacity)
        {
            MaxSize = capacity;
            Size = 0;
            Vertices = new int[MaxSize];
            Distances = new int[MaxSize];
            Positions = new int[MaxSize];
            for(int p=0;p<MaxSize;p++)
            {
                Positions[p] = -1;
                Distances[p] = int.MaxValue;
                Vertices[p] = -1;
            }
        }

        internal void Insert(int vertex, int distance)
        {
            Vertices[Size] = vertex;
            Distances[Size] = distance;
            Positions[vertex] = Size; 
            SiftUp(Size++);

            //Console.WriteLine("After inserting " + vertex.ToString());
            //print();
        }

        internal void ExtractMin(out int vertex, out int distance)
        {
            vertex = Vertices[0];
            distance = Distances[0];
            Positions[vertex] = -1;
            --Size;
            Vertices[0] = Vertices[Size];
            Distances[0] = Distances[Size];
            Positions[Vertices[0]] = 0;
            Vertices[Size] = -1;
            Distances[Size] = int.MaxValue;

            SiftDown(0);
                        
            //Console.WriteLine("After Extracting " + vertex.ToString() + " with distance " + distance.ToString());
            //print();
        }

        internal void ChangePriority(int vertex, int newDistance)
        {
            int i = Positions[vertex];
            int oldDistance = Distances[i];
            Distances[i] = newDistance;
            if(newDistance < oldDistance)
                SiftUp(i);
            else
                SiftDown(i);
        }

        private void SiftUp(int i)
        {
            int parent = (i - 1) / 2;
            int tmpVertex;
            int tmpDistance;
            while (i > 0 && Distances[parent] > Distances[i])
            {
                tmpVertex = Vertices[i];
                Vertices[i] = Vertices[parent];
                Vertices[parent] = tmpVertex;

                tmpDistance = Distances[i];
                Distances[i] = Distances[parent];
                Distances[parent] = tmpDistance;

                Positions[Vertices[i]] = i;
                Positions[Vertices[parent]] = parent;
                
                i = parent;
                parent = (i - 1) / 2;
            }
        }

        private void SiftDown(int i)
        {
            int tmpVertex;
            int tmpDistance;
            int minIndex = i;
            int left = (i * 2) + 1;
            int right = (i * 2) + 2;
            if (left < Size && Distances[left] < Distances[minIndex])
                minIndex = left;
            if (right < Size && Distances[right] < Distances[minIndex])
                minIndex = right;
            if (i != minIndex)
            {
                tmpVertex = Vertices[i];
                Vertices[i] = Vertices[minIndex];
                Vertices[minIndex] = tmpVertex;

                tmpDistance = Distances[i];
                Distances[i] = Distances[minIndex];
                Distances[minIndex] = tmpDistance;

                Positions[Vertices[i]] = i;
                Positions[Vertices[minIndex]] = minIndex;
                
                SiftDown(minIndex);
            }
        }

        private void print()
        {
            Console.WriteLine("Size: " + Size.ToString());
            Console.Write("Vertices\t");
            foreach(int v in Vertices)
                Console.Write(v.ToString() + '\t');
            Console.WriteLine();
            Console.Write("Distances\t");
            foreach(int d in Distances)
                Console.Write(d.ToString() + '\t');
            Console.WriteLine();
            Console.Write("Positions\t");
            foreach(int p in Positions)
                Console.Write(p.ToString() + '\t');
            Console.WriteLine();
        }
    }

    class Node
    {
        internal int vertex;
        internal int distance;
        internal List<Node> neighbors;
        internal List<int> weights;
        internal bool visited;

        internal Node(int v)
        {
            vertex = v;
            distance = int.MaxValue;
            neighbors = new List<Node>();
            weights = new List<int>();
        }

        public static bool operator <(Node left, Node right)
        {
            return left.distance < right.distance;
        }

        public static bool operator >(Node left, Node right)
        {
            return left.distance > right.distance;
        }
    }

    class Program
    {
        static int Dijkstra(PriorityQueue heap, Node[] graph, int destinationVertex)
        {
            int currentVertex, currentDistance, edgeWeight, nextVertex, nextDistance;
            while(heap.Size > 0)
            {
                heap.ExtractMin(out currentVertex, out currentDistance);
                if(currentVertex == destinationVertex)
                    return (currentDistance == int.MaxValue)? -1: currentDistance;
                for(int v=0;v<graph[currentVertex].neighbors.Count;v++)
                {
                    edgeWeight = graph[currentVertex].weights[v];
                    nextVertex = graph[currentVertex].neighbors[v].vertex;
                    if(heap.Positions[nextVertex] == -1)
                        continue;
                    nextDistance = heap.Distances[heap.Positions[nextVertex]];
                    if(nextDistance > currentDistance + edgeWeight && currentDistance != int.MaxValue)
                    {
                        heap.ChangePriority(nextVertex, currentDistance + edgeWeight);
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
            PriorityQueue heap = new PriorityQueue(vertices);

            for (int v = 0; v < vertices; v++)
            {
                graph[v] = new Node(v);
            }
            int vertex1, vertex2, weight;
            for (int e = 1; e <= edges; e++)
            {
                //Read each edge
                tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                vertex1 = tokens[0] - 1;
                vertex2 = tokens[1] - 1;
                weight = tokens[2];
                //Add each edge to th adj list
                graph[vertex1].neighbors.Add(graph[vertex2]);
                graph[vertex1].weights.Add(weight);
            }
            //Read the nodes for which the min weigh path has to be found
            tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            vertex1 = tokens[0] - 1; //Source
            vertex2 = tokens[1] - 1; //Destination

            graph[vertex1].distance = 0;
            heap.Insert(vertex1, 0);
            graph[vertex1].visited = true;

            for(int n=0; n<graph[vertex1].neighbors.Count;n++)
            {
                heap.Insert(graph[vertex1].neighbors[n].vertex, graph[vertex1].weights[n]);
                graph[vertex1].neighbors[n].visited = true;
            }
            foreach(Node node in graph.Where(g => g.visited == false))
            {
                heap.Insert(node.vertex, int.MaxValue);
            }

            Console.WriteLine(Dijkstra(heap, graph, vertex2).ToString());

            //Console.ReadLine();
        }
    }
}
