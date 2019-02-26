/*
Compose the largest number out of a set of integers.
Input Format. The first line of the input contains an integer 𝑛. The second line contains integers
𝑎1, 𝑎2, . . . , 𝑎𝑛.
Constraints. 1 ≤ 𝑛 ≤ 100; 1 ≤ 𝑎𝑖 ≤ 1000 for all 1 ≤ 𝑖 ≤ 𝑛.
Output Format. Output the largest number that can be composed out of 𝑎1, 𝑎2, . . . , 𝑎𝑛.
Sample 1.
Input:
2
21 2
Output:
221
Note that in this case the above algorithm also returns an incorrect answer 212.
11
Sample 2.
Input:
5
9 4 6 1 9
Output:
99641
In this case, the
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSalary
{
    class Program
    {
        static void RunTests(int n)
        {
            int x, y, a, b;
            List<int> input = new List<int>();
            Random rnd = new Random();
            for(int i=1;i<=n;i++)
            {
                input.Add(rnd.Next(1, 1001));
            }
            List<int> ordered = input.OrderByDescending
                    (r =>
                        (r < 10) ? (r * 1000) + (r * 100) + (r * 10) + r:
                        (r < 100) ? (r * 100) + r:
                        (r < 1000) ? (r * 10) + (r / 100):
                        r
                    ).ToList();
            for(int i=0;i<n-1;i++)
                for(int j=i+1;j<n;j++)
            {
                x = ordered[i];
                y = ordered[j];

                a = (y<10)? x*10 + y:
                    (y<100)? x*100 + y:
                    (y<1000)? x*1000 + y:
                    x*10000 + y;
                
                b = (x<10)? y*10 + x:
                    (x<100)? y*100 + x:
                    (x<1000)? y*1000 + x:
                    y*10000 + x;
                if(b>a)
                    Console.WriteLine(x + ' ' + y);
            }
        }

        static void Main(string[] args)
        {
            /*
            for(int i=0;i<int.MaxValue;i++)
                RunTests(100);
            */
            int n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).OrderByDescending
                    (r =>
                        (r < 10) ? (r * 1000) + (r * 100) + (r * 10) + r:
                        (r < 100) ? (r * 100) + r:
                        (r < 1000) ? (r * 10) + (r / 100):
                        r
                    );
            foreach (long x in a)
            {
                Console.Write(x.ToString());
            }
          
            //Console.ReadLine();
        }
    }
}
