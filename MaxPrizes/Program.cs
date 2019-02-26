/*
The goal of this problem is to represent a given positive integer 𝑛 as a sum of as many pairwise
distinct positive integers as possible. That is, to find the maximum 𝑘 such that 𝑛 can be written as
𝑎1 + 𝑎2 + · · · + 𝑎𝑘 where 𝑎1, . . . , 𝑎𝑘 are positive integers and 𝑎𝑖 ̸= 𝑎𝑗 for all 1 ≤ 𝑖 < 𝑗 ≤ 𝑘.
Input Format. The input consists of a single integer 𝑛.
Constraints. 1 ≤ 𝑛 ≤ 10^9.
Output Format. In the first line, output the maximum number 𝑘 such that 𝑛 can be represented as a sum
of 𝑘 pairwise distinct positive integers. In the second line, output 𝑘 pairwise distinct positive integers
that sum up to 𝑛 (if there are many such representations, output any of them).
Sample 1.
Input:
6
Output:
3
1 2 3
Sample 2.
Input:
8
Output:
3
1 2 5
Sample 3.
Input:
2
Output:
1
2 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxPrizes
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            List<long> a = new List<long>();
            long sum = 0;

            for (long i = 1; i <= n - sum; i++)
            {
                sum += i;
                a.Add(i);
            }

            if (sum != n)
            {
                a[a.Count - 1] = a.Last() + n - sum;
            }

            Console.WriteLine(a.Count);
            foreach (long x in a)
            {
                Console.Write(x);
                Console.Write(' ');
            }
            //Console.ReadLine();
        }
    }
}
