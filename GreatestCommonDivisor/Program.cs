/*
 * Given two integers 𝑎 and 𝑏, find their greatest common divisor.
 * Input Format. The two integers 𝑎, 𝑏 are given in the same line separated by space.
 * Constraints. 1 ≤ 𝑎, 𝑏 ≤ 2 * 10^9
 * Output Format. Output GCD(𝑎, 𝑏).
 * Sample.
 * Input:
 * 18 35
 * Output:
 * 1
 * 18 and 35 do not have common non-trivial divisors. 
 */

using System;

namespace GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            ulong a = ulong.Parse(tokens[0]);
            ulong b = ulong.Parse(tokens[1]);
            ulong c, t;
            if (a < b)
            {
                t = a;
                a = b;
                b = t;
            }
            c = b;
            while (c != 0)
            {
                c = a % b;
                a = b;
                b = c;
            } 
            Console.WriteLine(a);
            //Console.ReadLine();
        }
    }
}
