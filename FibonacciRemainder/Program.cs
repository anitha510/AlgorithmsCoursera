/*
 * Given two integers 𝑛 and 𝑚, output 𝐹𝑛 mod 𝑚 (that is, the remainder of 𝐹𝑛 when divided by 𝑚).
 * Input Format. The input consists of two integers 𝑛 and 𝑚 given on the same line (separated by a space).
 * Constraints. 1 ≤ 𝑛 ≤ 10^18, 2 ≤ 𝑚 ≤ 10^3.
 * Output Format. Output 𝐹𝑛 mod 𝑚.
 * Sample.
 * Input:
 * 239 1000
 * Output:
 * 161
 * 𝐹239 mod 1000 = 39 679 027 332 006 820 581 608 740 953 902 289 877 834 488 152 161 (mod 1000) = 161
 * Hint
 * 𝑖        0 1 2 3 4 5 6 7  8  9  10 11 12  13  14  15
 * 𝐹𝑖       0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610
 * 𝐹𝑖 mod 2 0 1 1 0 1 1 0 1  1  0  1  1  0   1   1   0
 * 𝐹𝑖 mod 3 0 1 1 2 0 2 2 1  0  1  1  2  0   2   2   1
 * Both these sequences are periodic! 
 * For 𝑚 = 2, the period is 011 and has length 3, while for 𝑚 = 3 the period is 01120221 and has length 8. 
 * Therefore, to compute, say, 𝐹2015 mod 3 we just need to find the remainder of 2015 when divided by 8. 
 * Since 2015 = 251 · 8 + 7, we conclude that 𝐹2015 mod 3 = 𝐹7 mod 3 = 1.
 * This is true in general: for any integer 𝑚 ≥ 2, the sequence 𝐹𝑛 mod 𝑚 is periodic. 
 * The period always starts with 01 and is known as Pisano period.
 */
using System;
using System.Collections.Generic;

namespace FibonacciRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ');
            ulong n = ulong.Parse(tokens[0]);
            ulong m = ulong.Parse(tokens[1]);
            ulong first = 1, second = 1, f = 0;
            List<ulong> series = new List<ulong>();
            series.Add(0);
            series.Add(first);
            series.Add(second);

            for(ulong i = 3; !(first == 0 && second == 1) && i<=n; i++)
            {
                f = (first + second) % m;
                series.Add(f);
                first = second;
                second = f;
            }
            ulong c = (ulong)(series.Count);
            int p = (int)((n < c)? n : n % (c - 2));
            Console.WriteLine(series[p]);
            //Console.ReadLine();
        }
    }
}
