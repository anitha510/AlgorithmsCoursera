/*
 * Given an integer 𝑛, find the 𝑛th Fibonacci number 𝐹𝑛.
 * Input Format. The input consists of a single integer 𝑛.
 * Constraints. 0 ≤ 𝑛 ≤ 45.
 * Output Format. Output 𝐹𝑛.
 * Sample.
 *   Input:
 *   10
 *   Output:
 *   55
 *   𝐹10 = 55
 */
using System;

namespace Fibonacci
{
    class Program
    {
        static int fibonacci(int n)
        {
            if (n <= 0)
                return 0;

            int first = 1;
            int second = 1;
            int sum = 0;

            for(int i=3; i<=n; i++)
            {
                sum = first + second;
                first = second;
                second = sum;
            }
            return second;
        }
        static void Main(string[] args)
        {
            int f = int.Parse(Console.ReadLine());
            Console.WriteLine(fibonacci(f));
            //Console.ReadLine();
        }
    }
}
