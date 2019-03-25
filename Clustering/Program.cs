/*
Given n points on a plane and an integer k, compute the largest possible value of d such that the
given points can be partitioned into k non-empty subsets in such a way that the distance between any
two points from different subsets is at least d.
Input Format. The first line contains the number n of points. Each of the following n lines defines a point
(xi; yi). The last line contains the number k of clusters.
Constraints. 2 <= k <= n <= 200; -1000 <= xi, yi <= 1000 are integers. All points are pairwise different.
Output Format. Output the largest value of d. The absolute value of the difference between the answer of
your program and the optimal value should be at most 10^-6. To ensure this, output your answer with
at least seven digits after the decimal point (otherwise your answer, while being computed correctly,
can turn out to be wrong because of rounding issues).
Memory Limit. 512Mb.
6
Sample 1.
Input:
12
7 6
4 3
5 1
1 7
2 7
5 7
3 3
7 8
2 8
4 4
6 7
2 6
3
Output:
2.828427124746
Sample 2.
Input:
8
3 1
1 2
4 6
9 8
9 9
8 9
3 11
4 12
4
Output:
5.000000000
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clustering
{
    // Minimum heap implementation
    internal class PriorityQueue
    {
        internal int[] Vertex1;
        internal int[] Vertex2;
        internal double[] Distances;
        internal int[,] Positions;
        int MaxSize;
        internal int Size;

        internal PriorityQueue(int capacity)
        {
            MaxSize = capacity * capacity;
            Size = 0;
            Vertex1 = new int[MaxSize];
            Vertex2 = new int[MaxSize];
            Distances = new double[MaxSize];
            Positions = new int[capacity, capacity];
        }

        internal void Insert(int vertex1, int vertex2, double distance)
        {
            Vertex1[Size] = vertex1;
            Vertex2[Size] = vertex2;
            Distances[Size] = distance;
            Positions[vertex1, vertex2] = Size;
            SiftUp(Size++);

            //Console.WriteLine("After inserting " + vertex.ToString());
            //print();
        }

        internal void ExtractMin(out int vertex1, out int vertex2, out double distance)
        {
            vertex1 = Vertex1[0];
            vertex2 = Vertex2[0];
            distance = Distances[0];
            Positions[vertex1, vertex2] = -1;
            --Size;
            Vertex1[0] = Vertex1[Size];
            Vertex2[0] = Vertex2[Size];
            Distances[0] = Distances[Size];
            Positions[Vertex1[0], Vertex2[0]] = 0;
            Vertex1[Size] = -1;
            Vertex2[Size] = -1;
            Distances[Size] = double.MaxValue;

            SiftDown(0);

            //Console.WriteLine("After Extracting " + vertex.ToString() + " with distance " + distance.ToString());
            //print();
        }

        internal void ChangePriority(int vertex1, int vertex2, double newDistance)
        {
            int i = Positions[vertex1, vertex2];
            double oldDistance = Distances[i];
            Distances[i] = newDistance;
            if (newDistance < oldDistance)
                SiftUp(i);
            else
                SiftDown(i);
        }

        private void SiftUp(int i)
        {
            int parent = (i - 1) / 2;
            int tmpVertex;
            double tmpDistance;
            while (i > 0 && Distances[parent] > Distances[i])
            {
                tmpVertex = Vertex1[i];
                Vertex1[i] = Vertex1[parent];
                Vertex1[parent] = tmpVertex;

                tmpVertex = Vertex2[i];
                Vertex2[i] = Vertex2[parent];
                Vertex2[parent] = tmpVertex;

                tmpDistance = Distances[i];
                Distances[i] = Distances[parent];
                Distances[parent] = tmpDistance;

                Positions[Vertex1[i], Vertex2[i]] = i;
                Positions[Vertex1[parent], Vertex2[parent]] = parent;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        private void SiftDown(int i)
        {
            int tmpVertex;
            double tmpDistance;
            int minIndex = i;
            int left = (i * 2) + 1;
            int right = (i * 2) + 2;
            if (left < Size && Distances[left] < Distances[minIndex])
                minIndex = left;
            if (right < Size && Distances[right] < Distances[minIndex])
                minIndex = right;
            if (i != minIndex)
            {
                tmpVertex = Vertex1[i];
                Vertex1[i] = Vertex1[minIndex];
                Vertex1[minIndex] = tmpVertex;

                tmpVertex = Vertex2[i];
                Vertex2[i] = Vertex2[minIndex];
                Vertex2[minIndex] = tmpVertex;

                tmpDistance = Distances[i];
                Distances[i] = Distances[minIndex];
                Distances[minIndex] = tmpDistance;

                Positions[Vertex1[i], Vertex2[i]] = i;
                Positions[Vertex1[minIndex], Vertex2[minIndex]] = minIndex;

                SiftDown(minIndex);
            }
        }

        private void print()
        {
            Console.WriteLine("Size: " + Size.ToString());
            Console.Write("Vertex 1\t");
            foreach (int v in Vertex1)
                Console.Write(v.ToString() + '\t');
            Console.WriteLine();
            Console.Write("Vertex 2\t");
            foreach (int v in Vertex2)
                Console.Write(v.ToString() + '\t');
            Console.WriteLine();
            Console.Write("Distances\t");
            foreach (int d in Distances)
                Console.Write(d.ToString() + '\t');
            Console.WriteLine();
            Console.Write("Positions\t");
            foreach (int p in Positions)
                Console.Write(p.ToString() + '\t');
            Console.WriteLine();
        }
    }

    class DisjointSet
    {
        int[] parent;
        int[] rank;

        internal DisjointSet(int capacity)
        {
            parent = new int[capacity];
            rank = new int[capacity];
            for (int i = 0; i < capacity; i++)
                parent[i] = i;
        }

        internal int Find(int i)
        {
            while (i != parent[i])
                i = parent[i];

            return i;
        }

        internal void Union(int i, int j)
        {
            int i_id = Find(i);
            int j_id = Find(j);

            if (i_id == j_id)
                return;

            if(rank[i_id] > rank[j_id])
            {
                parent[j_id] = i_id;
            }
            else
            {
                parent[i_id] = j_id;
                if (rank[i_id] == rank[j_id])
                    rank[j_id]++;
            }
        }
    }

    class Node
    {
        internal int vertex;
        internal int x;
        internal int y;

        internal Node(int v, int a, int b)
        {
            vertex = v;
            x = a;
            y = b;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int vertices = int.Parse(Console.ReadLine());
            Node[] graph = new Node[vertices];
            PriorityQueue heap = new PriorityQueue(vertices);
            DisjointSet set = new DisjointSet(vertices);

            int x1, x2, y1, y2;
            int v1, v2, c = vertices;
            double distance = 0.0;

            for (int v = 0; v < vertices; v++)
            {
                var tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                x1 = tokens[0];
                y1 = tokens[1];
                graph[v] = new Node(v, x1, y1);

                for (int e = 0; e < v; e++)
                {
                    x2 = graph[e].x;
                    y2 = graph[e].y;
                    heap.Insert(e, v, Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
                }
            }

            int clusters = int.Parse(Console.ReadLine());

            while(c>=clusters)
            {
                heap.ExtractMin(out v1, out v2, out distance);
                if (set.Find(v1) != set.Find(v2))
                {
                    set.Union(v1, v2);
                    c--;
                }
            }
            
            Console.WriteLine(Math.Round(distance, 10).ToString());

            //Console.ReadLine();
        }
    }
}
