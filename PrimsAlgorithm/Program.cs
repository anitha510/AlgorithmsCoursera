/*
Given n points on a plane, connect them with segments of minimum total length such that there is a
path between any two points. Recall that the length of a segment with endpoints (x1; y1) and (x2; y2)
is equal to SQRT((x1 - x2)^2 + (y1 - y2)^2)
Input Format. The first line contains the number n of points. Each of the following n lines defines a point
(xi; yi).
Constraints. 1 <= n <= 200; -1000 <= xi, yi <= 1000 are integers. All points are pairwise different, no three
points lie on the same line.
Output Format. Output the minimum total length of segments. The absolute value of the difference
between the answer of your program and the optimal value should be at most 10^-6. To ensure this,
output your answer with at least seven digits after the decimal point (otherwise your answer, while
being computed correctly, can turn out to be wrong because of rounding issues).
Memory Limit. 512Mb.
Sample 1.
Input:
4
0 0
0 1
1 0
1 1
Output:
3.000000000
Sample 2.
Input:
5
0 0
0 2
1 1
3 0
3 2
Output:
7.064495102
The total length here is equal to 2 * SQRT(2) + SQRT(5) + 2.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimsAlgorithm
{
    // Minimum heap implementation
    internal class PriorityQueue
    {
        internal int[] Vertices;
        internal double[] Distances;
        internal int[] Positions;
        int MaxSize;
        internal int Size;

        internal PriorityQueue(int capacity)
        {
            MaxSize = capacity;
            Size = 0;
            Vertices = new int[MaxSize];
            Distances = new double[MaxSize];
            Positions = new int[MaxSize];
            for (int p = 0; p < MaxSize; p++)
            {
                Positions[p] = -1;
                Distances[p] = double.MaxValue;
                Vertices[p] = -1;
            }
        }

        internal void Insert(int vertex, double distance)
        {
            Vertices[Size] = vertex;
            Distances[Size] = distance;
            Positions[vertex] = Size;
            SiftUp(Size++);

            //Console.WriteLine("After inserting " + vertex.ToString());
            //print();
        }

        internal void ExtractMin(out int vertex, out double distance)
        {
            vertex = Vertices[0];
            distance = Distances[0];
            Positions[vertex] = -1;
            --Size;
            Vertices[0] = Vertices[Size];
            Distances[0] = Distances[Size];
            Positions[Vertices[0]] = 0;
            Vertices[Size] = -1;
            Distances[Size] = double.MaxValue;

            SiftDown(0);

            //Console.WriteLine("After Extracting " + vertex.ToString() + " with distance " + distance.ToString());
            //print();
        }

        internal void ChangePriority(int vertex, double newDistance)
        {
            int i = Positions[vertex];
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
            foreach (int v in Vertices)
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

            for (int v = 0; v < vertices; v++)
            {
                var tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                graph[v] = new Node(v, tokens[0], tokens[1]);
                heap.Insert(v, double.MaxValue);
            }

            // Take the first vertex as the source
            heap.ChangePriority(0, 0.0);

            int currentVertex, neighbor, x1, x2, y1, y2;
            double currentDistance, newDistance, result = 0.0;
            //Prim's Algorithm
            while(heap.Size > 0)
            {
                heap.ExtractMin(out currentVertex, out currentDistance);
                result += currentDistance;
                x1 = graph[currentVertex].x;
                y1 = graph[currentVertex].y;

                //Change all the distance in the Priority Queue if its distance is less than the new 
                for (int i=0;i<heap.Size;i++)
                {
                    neighbor = heap.Vertices[i];
                    x2 = graph[neighbor].x;
                    y2 = graph[neighbor].y;

                    newDistance = Math.Sqrt(Math.Pow(x1-x2, 2) + Math.Pow(y1-y2, 2));
                    if (newDistance < heap.Distances[i])
                        heap.ChangePriority(neighbor, newDistance);
                }
            }

            Console.WriteLine(Math.Round(result, 10).ToString());
            //Console.ReadLine();
        }
    }
}
