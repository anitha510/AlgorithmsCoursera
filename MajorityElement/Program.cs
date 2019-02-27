/*
The goal in this code problem is to check whether an input sequence contains a majority element.
Input Format. The first line contains an integer 𝑛, the next one contains a sequence of 𝑛 non-negative
integers 𝑎0, 𝑎1, . . . , 𝑎𝑛−1.
Constraints. 1 ≤ 𝑛 ≤ 10^5; 0 ≤ 𝑎𝑖 ≤ 10^9 for all 0 ≤ 𝑖 < 𝑛.
Output Format. Output 1 if the sequence contains an element that appears strictly more than 𝑛/2 times,
and 0 otherwise.
Sample 1.
Input:
5
2 3 9 2 2
Output:
1
2 is the majority element.
Sample 2.
Input:
4
1 2 3 4
Output:
0
There is no majority element in this sequence.
4
Sample 3.
Input:
4
1 2 3 1
Output:
0
This sequence also does not have a majority element (note that the element 1 appears twice and hence
is not a majority element). 
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split(' ').Select(r => long.Parse(r));
            Dictionary<long, int> maj = new Dictionary<long, int>();

            foreach(long i in a)
            {
                if (maj.ContainsKey(i))
                    maj[i]++;
                else
                    maj.Add(i, 1);
            }

            if (maj.Where(m => m.Value > (n / 2)).Count() == 1)
                Console.WriteLine('1');
            else
                Console.WriteLine('0');
            //Console.ReadLine();
        }
    }
}
