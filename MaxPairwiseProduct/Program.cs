/*
 * Maximum Pairwise Product Problem
 *  Find the maximum product of two distinct numbers in a sequence of non-negative integers.
 *  Input: A sequence of non-negative integers.
 *  Output: The maximum value that can be obtained by multiplying two different elements from the sequence.
 *      Sample.
 *      Input:
 *          3
 *          1 2 3
 *      Output:
 *          6
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxPairwiseProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ulong> n = new List<ulong>();
            var total = Console.ReadLine();
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            foreach (var t in tokens)
            {
                n.Add(ulong.Parse(t));
            }
            ulong first = n.Max();
            n.Remove(first);
            ulong second = n.Max();
            ulong product = first * second;
            Console.WriteLine(product);
            //Console.ReadLine();
        }
    }
}
