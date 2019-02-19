/*
 * Given two integers 𝑎 and 𝑏, find their least common multiple.
 * Input Format. The two integers 𝑎 and 𝑏 are given in the same line separated by space.
 * Constraints. 1 ≤ 𝑎, 𝑏 ≤ 2 * 10^9
 * Output Format. Output the least common multiple of 𝑎 and 𝑏.
 * Sample.
 * Input:
 * 6 8
 * Output:
 * 24
 * Among all the positive integers that are divisible by both 6 and 8 (e.g., 48, 480, 24), 24 is the smallest one. 
 */

using System;
using System.Collections.Generic;

namespace LeastCommonMultiple
{
    class Program
    {
        static ulong gcd(ulong a, ulong b)
        {
            ulong c;
            c = b;
            while (c != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }
            return a;
        }
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ');
            ulong a = ulong.Parse(tokens[0]);
            ulong b = ulong.Parse(tokens[1]);
            ulong t = 0, g = 0, p = 1;
            if (a < b)
            {
                t = a;
                a = b;
                b = t;
            }

            if (a == 0 || b == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while(g != 1)
                {
                    g = gcd(a, b);
                    a /= g;
                    b /= g;
                    p *= g;
                }
                p *= a * b;
                Console.WriteLine(p);
            }
            //Console.ReadLine();
        }
    }
}
