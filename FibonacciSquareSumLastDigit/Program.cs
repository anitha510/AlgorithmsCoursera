/*
 * Compute the last digit of 𝐹0^2 + 𝐹1^2 + · · · + 𝐹𝑛^2
 * Input Format. Integer 𝑛.
 * Constraints. 0 ≤ 𝑛 ≤ 10^18.
 * Output Format. The last digit of 𝐹0^2 + 𝐹1^2 + · · · + 𝐹𝑛^2
 * Sample.
 * Input:
 * 7
 * Output:
 * 3
 * 𝐹0^2 + 𝐹1^2 + · · · + 𝐹7^2 = 0 + 1 + 1 + 4 + 9 + 25 + 64 + 169 = 273
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciSquareSumLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());

            int first = 1, second = 1, f = 0, r = 0, p = 0, s = 0;
            ulong i, c = 0, d = 0;
            List<int> series = new List<int>();
            List<int> sqseries = new List<int>();
            series.Add(0);
            series.Add(first);
            series.Add(second);

            sqseries.Add(0);
            sqseries.Add(first);
            sqseries.Add(second);

            for (i = 3; !(first == 0 && second == 1) && i <= n; i++)
            {
                f = (first + second) % 10;
                series.Add(f);
                sqseries.Add((f * f) % 10);
                first = second;
                second = f;
            }
            if (first == 0 && second == 1)
            {
                series.RemoveAt(series.Count - 1);
                sqseries.RemoveAt(sqseries.Count - 1);
            }

            c = (ulong)(sqseries.Count) - 1;
            s = sqseries.Sum() % 10;
            d = n / c;
            r = (int)(n % c);
            s = (int)((ulong)s * d) % 10;
            s = (s + sqseries.Take(r + 1).Sum()) % 10;

            Console.WriteLine(s);
            
            //Console.ReadLine();
        }
    }
}
