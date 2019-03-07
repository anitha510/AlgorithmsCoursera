/*
You and two of your friends have just returned back home after visiting various countries. Now you would
like to evenly split all the souvenirs that all three of you bought.
Problem Description
Input Format. The first line contains an integer 𝑛. The second line contains integers 𝑣1, 𝑣2, . . . , 𝑣𝑛 separated
by spaces.
Constraints. 1 ≤ 𝑛 ≤ 20, 1 ≤ 𝑣𝑖 ≤ 30 for all 𝑖.
Output Format. Output 1, if it possible to partition 𝑣1, 𝑣2, . . . , 𝑣𝑛 into three subsets with equal sums, and
0 otherwise.
Sample 1.
Input:
4
3 3 3 3
Output:
0
Sample 2.
Input:
1
40
Output:
0
Sample 3.
Input:
11
17 59 34 57 17 23 67 1 18 2 59
Output:
1
34 + 67 + 17 = 23 + 59 + 1 + 17 + 18 = 59 + 2 + 57.
Sample 4.
Input:
13
1 2 3 4 5 5 7 7 8 10 12 19 25
Output:
1
1 + 3 + 7 + 25 = 2 + 4 + 5 + 7 + 8 + 10 = 5 + 12 + 19 
*/
using System;
using System.Linq;

namespace PartitioningSouvenirs
{
    class Program
    {
        private static bool Knapsack(int capacity, int[] weights, ref int[] remaining)
        {
            int[,] value = new int[capacity + 1, weights.Length + 1];
            int val = 0, weight = 0;

            for (int j = 0; j <= weights.Length; j++)
            {
                value[0, j] = 0;
            }
            for (int i = 0; i <= capacity; i++)
            {
                value[i, 0] = 0;
            }

            for (int i = 1; i <= weights.Length; i++)
            {
                for (int w = 1; w <= capacity; w++)
                {
                    value[w, i] = value[w, i - 1];
                    weight = weights[i - 1];
                    if (weight <= w)
                    {
                        val = value[w - weight, i - 1] + weight;
                        if (value[w, i] < val)
                        {
                            value[w, i] = val;
                        }
                    }
                }
            }
            if(value[capacity, weights.Length] == capacity)
            {
                weight = capacity;
                for(int i=weights.Length;i>0;i--)
                {
                    if(value[weight, i] == value[weight, i-1])
                    {
                        remaining[i - 1] = weights[i-1]; //not used, so add to the remaining array
                    }
                    else
                    {
                        weight -= weights[i - 1];
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void FastAlgorithm()
        {
            int n = int.Parse(Console.ReadLine());
            int[] weights = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).OrderByDescending(d => d).ToArray();
            int capacity = weights.Sum();
            int[] remaining1 = new int[weights.Length];
            int[] remaining2 = new int[weights.Length];

            if (capacity % 3 == 0)
            {
                if (Knapsack(capacity / 3, weights, ref remaining1))
                {
                    /*
                    foreach (int r in remaining1)
                    {
                        Console.Write(r.ToString() + ' ');
                    }
                    Console.WriteLine();
                    */
                    if (Knapsack(capacity / 3, remaining1, ref remaining2))
                    {
                        /*
                        foreach (int r in remaining2)
                        {
                            Console.Write(r.ToString() + ' ');
                        }
                        Console.WriteLine();
                        */
                        if (remaining2.Sum() == capacity / 3)
                        {
                            Console.WriteLine("1");
                            //Console.ReadLine();
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("0");
        }

        static void Main(string[] args)
        {
            FastAlgorithm();
            //Console.ReadLine();
        }
    }
}
