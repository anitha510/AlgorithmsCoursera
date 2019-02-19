using System;

namespace FibonacciLastDigit
{
    class Program
    {
        static int fibonacciLastDigit(int n)
        {
            if (n <= 0)
                return 0;
            if (n <= 2)
                return 1;

            int first = 1;
            int second = 1;
            int sum = 0;

            for (int i = 3; i <= n; i++)
            {
                sum = (first + second) % 10;
                first = second;
                second = sum;
            }
            return second;
        }
        static void Main(string[] args)
        {
            int f = int.Parse(Console.ReadLine());
            Console.WriteLine(fibonacciLastDigit(f));
            //Console.ReadLine();
        }
    }
}
