/*
To force the given implementation of the quick sort algorithm to efficiently process sequences with
few unique elements, your goal is replace a 2-way partition with a 3-way partition. That is, your new
partition procedure should partition the array into three parts: < 𝑥 part, = 𝑥 part, and > 𝑥 part.
Input Format. The first line of the input contains an integer 𝑛. The next line contains a sequence of 𝑛
integers 𝑎0, 𝑎1, . . . , 𝑎𝑛−1.
Constraints. 1 ≤ 𝑛 ≤ 10^5; 1 ≤ 𝑎𝑖 ≤ 10^9 for all 0 ≤ 𝑖 < 𝑛.
Output Format. Output this sequence sorted in non-decreasing order.
Sample 1.
Input:
5
2 3 9 2 2
Output:
2 2 2 3 9 
 */
using System;
using System.Linq;

namespace QuickSortWith3Partitions
{
    class Program
    {
        private static int[] partition3(long[] a, int l, int r)
        {
            long t;
            long x = a[l];
            int p1 = l, p2 = l, m1, m2;
            for (int i = l + 1; i <= r; i++)
            {
                if (a[i] < x)
                {
                    p2++;
                    t = a[i];
                    a[i] = a[p2];
                    a[p2] = t;
                }
                else if (a[i] == x)
                {
                    p1++;
                    p2++;
                    a[i] = a[p2];
                    a[p2] = a[p1];
                    a[p1] = x;
                }
            }
            m2 = p2;
            while(p1>=l)
            {
                t = a[p1];
                a[p1] = a[p2];
                a[p2] = t;
                p1--;
                p2--;
            }
            m1 = p2 + 1;
            return new int[] { m1, m2 };
        }

        private static int partition2(long[] a, int l, int r)
        {
            long t;
            long x = a[l];
            int j = l;
            for (int i = l + 1; i <= r; i++)
            {
                if (a[i] <= x)
                {
                    j++;
                    t = a[i];
                    a[i] = a[j];
                    a[j] = t;
                }
            }
            t = a[l];
            a[l] = a[j];
            a[j] = t;
            return j;
        }

        private static void randomizedQuickSort(long[] a, int l, int r)
        {
            if (l >= r)
            {
                return;
            }
            Random random = new Random();
            int k = random.Next(l, r + 1);
            long t = a[l];
            a[l] = a[k];
            a[k] = t;

            int[] m = partition3(a, l, r);
            randomizedQuickSort(a, l, m[0] - 1);
            randomizedQuickSort(a, m[1] + 1, r);
        }
        
        static bool RunTests()
        {
            bool pass = true;
            Random rnd = new Random();
            int n = rnd.Next(1, 100001);
            long[] input = new long[100000];
            long[] input_copy = new long[100000];
            for(int i=0;i<n;i++)
            {
                input[i] = rnd.Next(1, 1000000001);
            }
            input.CopyTo(input_copy, 0);
            randomizedQuickSort(input, 0, n - 1);
            for(int i=1;i<n;i++)
            {
                if(input[i-1]>input[i])
                {
                    Console.WriteLine("Input:");
                    for(int x=0;x<n;x++)
                    {
                        Console.Write(input_copy[x] + ' ');
                    }
                    Console.WriteLine("Sort:");
                    for(int y=0;y<n;y++)
                    {
                        Console.Write(input[y] + ' ');
                    }
                    pass = false;
                    Console.ReadLine();
                    
                    break;
                }
            }
            return pass;
        }

        static void Main(string[] args)
        {
            /*
            for(int i=0;i<int.MaxValue;i++)
                RunTests();
            */
            int n = int.Parse(Console.ReadLine());
            long[] a = Console.ReadLine().Split(' ').Select(r => long.Parse(r)).ToArray();

            randomizedQuickSort(a, 0, n - 1);

            foreach(long i in a)
            {
                Console.Write(i.ToString() + ' ');
            }
            
            //Console.ReadLine();
        }
    }
}
