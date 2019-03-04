/*
You are given a set of bars of gold and your goal is to take as much gold as possible into
your bag. There is just one copy of each bar and for each bar you can either take it or not
(hence you cannot take a fraction of a bar).
Problem Description
Task. Given 𝑛 gold bars, find the maximum weight of gold that fits into a bag of capacity 𝑊.
Input Format. The first line of the input contains the capacity 𝑊 of a knapsack and the number 𝑛 of bars
of gold. The next line contains 𝑛 integers 𝑤0,𝑤1, . . . ,𝑤𝑛−1 defining the weights of the bars of gold.
Constraints. 1 ≤ 𝑊 ≤ 10^4; 1 ≤ 𝑛 ≤ 300; 0 ≤ 𝑤0, . . . ,𝑤𝑛−1 ≤ 10^5.
Output Format. Output the maximum weight of gold that fits into a knapsack of capacity 𝑊.
Sample 1.
Input:
10 3
1 4 8
Output:
9
Here, the sum of the weights of the first and the last bar is equal to 9.
*/
using System;
using System.Linq;

namespace MaxGold
{
    class Program
    {
        private static int Knapsack(int capacity, int[] weights)
        {
            int[,] value = new int[capacity+1, weights.Length+1];
            int val = 0, weight = 0;

            for (int j = 0; j <= weights.Length; j++)
            {
                value[0, j] = 0;
            }
            for (int i=0;i<=capacity;i++)
            {
                value[i, 0] = 0;
            }

            for(int i=1;i<=weights.Length;i++)
            {
                for(int w=1;w<=capacity;w++)
                {
                    value[w, i] = value[w, i - 1];
                    weight = weights[i - 1];
                    if (weight <= w)
                    {
                        val = value[w - weight, i - 1] + weight;
                        if(value[w, i] < val)
                        {
                            value[w, i] = val;
                        }
                    }
                }
            }
            return value[capacity, weights.Length];
        }

        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ');
            int capacity = int.Parse(tokens[0]);
            int n = int.Parse(tokens[1]);
            int[] weights = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();

            Console.WriteLine(Knapsack(capacity, weights).ToString());
            //Console.ReadLine();
        }
    }
}
