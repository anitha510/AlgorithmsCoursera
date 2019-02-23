/*
Given two sequences 𝑎1, 𝑎2, . . . , 𝑎𝑛 (𝑎𝑖 is the profit per click of the 𝑖-th ad) and 𝑏1, 𝑏2, . . . , 𝑏𝑛 (𝑏𝑖 is
the average number of clicks per day of the 𝑖-th slot), we need to partition them into 𝑛 pairs (𝑎𝑖, 𝑏𝑗)
such that the sum of their products is maximized.
Input Format. The first line contains an integer 𝑛, the second one contains a sequence of integers
𝑎1, 𝑎2, . . . , 𝑎𝑛, the third one contains a sequence of integers 𝑏1, 𝑏2, . . . , 𝑏𝑛.
Constraints. 1 ≤ 𝑛 ≤ 103; −105 ≤ 𝑎𝑖, 𝑏𝑖 ≤ 105 for all 1 ≤ 𝑖 ≤ 𝑛.
Output Format. Output the maximum value of
𝑛
Σ︀ 𝑎𝑖𝑐𝑖
𝑖=1
where 𝑐1, 𝑐2, . . . , 𝑐𝑛 is a permutation of 𝑏1, 𝑏2, . . . , 𝑏𝑛.
Sample 1.
Input:
1
23
39
Output:
897
897 = 23 · 39.
Sample 2.
Input:
3
1 3 -5
-2 4 1
Output:
23
23 = 3 · 4 + 1 · 1 + (−5) · (−2). 
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxAdRevenue
{
    class Program
    {
        static void Main(string[] args)
        {
            long ans = 0;
            int n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split(' ').Select(r => long.Parse(r)).OrderBy(r => r);
            var b = Console.ReadLine().Split(' ').Select(r => long.Parse(r)).OrderBy(r => r);

            for (int i = 0; i < n; i++)
            {
                ans += a.ElementAt(i) * b.ElementAt(i);
            }
            
            Console.WriteLine(ans);
            //Console.ReadLine();
        }
    }
}
