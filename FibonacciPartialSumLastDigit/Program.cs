/*
 * Given two non-negative integers 𝑚 and 𝑛, where 𝑚 ≤ 𝑛, find the last digit of the sum 𝐹𝑚 + 𝐹𝑚+1 + · · · + 𝐹𝑛.
 * Input Format. The input consists of two non-negative integers 𝑚 and 𝑛 separated by a space.
 * Constraints. 0 ≤ 𝑚 ≤ 𝑛 ≤ 1018.
 * Output Format. Output the last digit of 𝐹𝑚 + 𝐹𝑚+1 + · · · + 𝐹𝑛.
 * Sample.
 * Input:
 * 3 7
 * Output:
 * 1
 * 𝐹3 + 𝐹4 + 𝐹5 + 𝐹6 + 𝐹7 = 2 + 3 + 5 + 8 + 13 = 31
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciPartialSumLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ');
            ulong m = ulong.Parse(tokens[0]);
            ulong n = ulong.Parse(tokens[1]);
            m = (m==0)? 0:m - 1;
 
            int first = 1, second = 1, f = 0, sc = 0, sn = 0, sm = 0, rn = 0, rm = 0, pn = 0, pm = 0, ans = 0;
            ulong i, c = 0, dn = 0, dm = 0;
            List<int> series = new List<int>();
            series.Add(0);
            series.Add(first);
            series.Add(second);

            for (i = 3; !(first == 0 && second == 1) && i <= n; i++)
            {
                f = (first + second) % 10;
                series.Add(f);
                first = second;
                second = f;
            }
            if(first == 0 && second == 1)
            {
                    series.RemoveAt(series.Count - 1);
            }

            c = (ulong)(series.Count) - 1;
            sc = series.Sum() % 10;

            dn = n / c;
            rn = (int)(n % c);
            pn = (int)((ulong)sc * dn) % 10;
            sn = (pn + series.Take(rn + 1).Sum()) % 10;

            dm = m / c;
            rm = (int)(m % c);
            pm = (int)((ulong)sc * dm) % 10;
            sm = (pm + series.Take(rm + 1).Sum()) % 10;
            ans = sn - sm;
            Console.WriteLine((ans < 0)? 10 + ans: ans);
        
            //Console.ReadLine();
        }
    }
}
