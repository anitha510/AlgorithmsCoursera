/*
The goal in this code problem is to implement the binary search algorithm.
Input Format. The first line of the input contains an integer 𝑛 and a sequence 𝑎0 < 𝑎1 < . . . < 𝑎𝑛−1
of 𝑛 pairwise distinct positive integers in increasing order. The next line contains an integer 𝑘 and 𝑘
positive integers 𝑏0, 𝑏1, . . . , 𝑏𝑘−1.
Constraints. 1 ≤ 𝑛, 𝑘 ≤ 10^4; 1 ≤ 𝑎𝑖 ≤ 10^9 for all 0 ≤ 𝑖 < 𝑛; 1 ≤ 𝑏𝑗 ≤ 10^9 for all 0 ≤ 𝑗 < 𝑘;
Output Format. For all 𝑖 from 0 to 𝑘 − 1, output an index 0 ≤ 𝑗 ≤ 𝑛 − 1 such that 𝑎𝑗 = 𝑏𝑖 or −1 if there
is no such index.
Sample 1.
Input:
5 1 5 8 12 13
5 8 1 23 1 11
Output:
2 0 -1 0 -1
In this sample, we are given an increasing sequence 𝑎0 = 1, 𝑎1 = 5, 𝑎2 = 8, 𝑎3 = 12, 𝑎4 = 13 of length
five and five keys to search: 8, 1, 23, 1, 11. We see that 𝑎2 = 8 and 𝑎0 = 1, but the keys 23 and 11 do
not appear in the sequence 𝑎. For this reason, we output a sequence 2, 0,−1, 0,−1.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static int BinarySearch(List<long> a, int low, int high, long key)
        {
            if(high < low)
                return -1;

            int mid = low + (high-low)/2;

            if(key == a[mid])
                return mid;
            else if(key < a[mid])
                return BinarySearch(a, low, mid-1, key);
            else
                return BinarySearch(a, mid+1, high, key);
        }

        static void Main(string[] args)
        {
            List<long> a = Console.ReadLine().Split(' ').Select(r => long.Parse(r)).ToList();
            List<long> b = Console.ReadLine().Split(' ').Select(r => long.Parse(r)).ToList();
            List<int> c = new List<int>();
            int f = -1;

            a.RemoveAt(0);
            b.RemoveAt(0);
            
            for (int x = 0; x < b.Count; x++, f=-1)
            {
                c.Add(BinarySearch(a, 0, a.Count-1, b[x]));
            }

            foreach(int j in c)
            {
                Console.Write(j.ToString() + ' ');
            }
            //Console.ReadLine();
        }
    }
}
