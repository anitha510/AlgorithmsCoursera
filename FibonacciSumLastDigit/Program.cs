/*
 * Given an integer 𝑛, find the last digit of the sum 𝐹0 + 𝐹1 + · · · + 𝐹𝑛.
 * Input Format. The input consists of a single integer 𝑛.
 * Constraints. 0 ≤ 𝑛 ≤ 10^18.
 * Output Format. Output the last digit of 𝐹0 + 𝐹1 + · · · + 𝐹𝑛. 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciSumLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());

            switch(n)
            {
                case 0:
                    Console.WriteLine(0);
                    break;
                case 1:
                    Console.WriteLine(1);
                    break;
                case 2:
                    Console.WriteLine(2);
                    break;
                default:
                    int first = 1, second = 1, f = 0;
                    List<int> series = new List<int>();
                    series.Add(0);
                    series.Add(first);
                    series.Add(second);

                    for(ulong i = 3; !(first == 0 && second == 1) && i<=n; i++)
                    {
                        f = (first + second) % 10;
                        series.Add(f);
                        first = second;
                        second = f;
                    }
                    ulong c = (ulong)(series.Count) - 1;
                    int s = series.Sum() % 10;
                    if(n == c)
                    {
                        Console.WriteLine(s);
                    }
                    else
                    {
                        c -= 1;
                        s = (series.Take((int)c).Sum()) % 10;
                        ulong d = n/c;
                        int r = (int)(n%c);
                        s = (int)((ulong)s * d) % 10;
                        s = (s + series.Take(r+1).Sum()) % 10;
                        Console.WriteLine(s);
                    }
                    break;
            }
            //Console.ReadLine();
        }
    }
}
