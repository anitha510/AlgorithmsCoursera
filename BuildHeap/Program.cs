/*
The first step of the HeapSort algorithm is to create a heap from the array you want to sort. By the
way, did you know that algorithms based on Heaps are widely used for external sort, when you need
to sort huge files that don’t fit into memory of a computer?
Your task is to implement this first step and convert a given array of integers into a heap. You will
do that by applying a certain number of swaps to the array. Swap is an operation which exchanges
elements 𝑎𝑖 and 𝑎𝑗 of the array 𝑎 for some 𝑖 and 𝑗. You will need to convert the array into a heap
using only 𝑂(𝑛) swaps, as was described in the lectures. Note that you will need to use a min-heap
instead of a max-heap in this problem.
Input Format. The first line of the input contains single integer 𝑛. The next line contains 𝑛 space-separated
integers 𝑎𝑖.
Constraints. 1 ≤ 𝑛 ≤ 100000; 0 ≤ 𝑖, 𝑗 ≤ 𝑛 − 1; 0 ≤ 𝑎0, 𝑎1, . . . , 𝑎𝑛−1 ≤ 10^9. All 𝑎𝑖 are distinct.
Output Format. The first line of the output should contain single integer 𝑚 — the total number of swaps.
𝑚 must satisfy conditions 0 ≤ 𝑚 ≤ 4𝑛. The next 𝑚 lines should contain the swap operations used
to convert the array 𝑎 into a heap. Each swap is described by a pair of integers 𝑖, 𝑗 — the 0-based
indices of the elements to be swapped. After applying all the swaps in the specified order the array
must become a heap, that is, for each 𝑖 where 0 ≤ 𝑖 ≤ 𝑛 − 1 the following conditions must be true:
1. If 2𝑖 + 1 ≤ 𝑛 − 1, then 𝑎𝑖 < 𝑎2𝑖+1.
2. If 2𝑖 + 2 ≤ 𝑛 − 1, then 𝑎𝑖 < 𝑎2𝑖+2.
Note that all the elements of the input array are distinct. Note that any sequence of swaps that has
length at most 4𝑛 and after which your initial array becomes a correct heap will be graded as correct.
Memory Limit. 512Mb.
Sample 1.
Input:
5
5 4 3 2 1
Output:
3
1 4
0 1
1 3
Explanation:
After swapping elements 4 in position 1 and 1 in position 4 the array becomes 5 1 3 2 4.
3
After swapping elements 5 in position 0 and 1 in position 1 the array becomes 1 5 3 2 4.
After swapping elements 5 in position 1 and 2 in position 3 the array becomes 1 2 3 5 4, which is
already a heap, because 𝑎0 = 1 < 2 = 𝑎1, 𝑎0 = 1 < 3 = 𝑎2, 𝑎1 = 2 < 5 = 𝑎3, 𝑎1 = 2 < 4 = 𝑎4.
Sample 2.
Input:
5
1 2 3 4 5
Output:
0
Explanation:
The input array is already a heap, because it is sorted in increasing order.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildHeap
{
    class Program
    {
        static List<KeyValuePair<int, int>> swaps = new List<KeyValuePair<int, int>>();
        static int swaps_count = 0;
        static int[] a;

        static void SwiftDown(int i)
        {
            int tmp;
            int minIndex = i;
            int left = (i * 2) + 1;
            int right = (i * 2) + 2;
            if (left < a.Length && a[left] < a[minIndex])
                minIndex = left;
            if (right < a.Length && a[right] < a[minIndex])
                minIndex = right;
            if(i != minIndex)
            {
                tmp = a[i];
                a[i] = a[minIndex];
                a[minIndex] = tmp;

                swaps_count++;
                swaps.Add(new KeyValuePair<int, int>(i, minIndex));
                SwiftDown(minIndex);
            }
        }
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            a = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            for (int i = n/2; i >= 0; i--)
                SwiftDown(i);
            Console.WriteLine(swaps_count.ToString());
            foreach(var s in swaps)
            {
                Console.Write(s.Key.ToString() + ' ' + s.Value.ToString());
                Console.WriteLine();
            }
            /*
            foreach(int x in a)
            {
                Console.Write(x.ToString() + ' ');
            }
            Console.ReadLine();
            */
        }
    }
}
