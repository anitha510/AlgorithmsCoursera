/*
The goal in this problem is to count the number of inversions of a given sequence.
Input Format. The first line contains an integer 𝑛, the next one contains a sequence of integers
𝑎0, 𝑎1, . . . , 𝑎𝑛−1.
Constraints. 1 ≤ 𝑛 ≤ 10^5, 1 ≤ 𝑎𝑖 ≤ 10^9 for all 0 ≤ 𝑖 < 𝑛.
Output Format. Output the number of inversions in the sequence.
Sample 1.
Input:
5
2 3 9 2 9
Output:
2
The two inversions here are (1, 3) (𝑎1 = 3 > 2 = 𝑎3) and (2, 3) (𝑎2 = 9 > 2 = 𝑎3).
*/
using System;
using System.Linq;

namespace Inversions
{
    class Program
    {
        private static int getNumberOfInversions(int[] a, int left, int right)
        {
            int numberOfInversions = 0;
            if (right <= left)
            {
                return numberOfInversions;
            }
            int ave = (left + right) / 2;
            numberOfInversions += getNumberOfInversions(a, left, ave);
            numberOfInversions += getNumberOfInversions(a, ave+1, right);

            int[] sort = new int[right - left + 1];
            int first = left, second = ave+1, i=0;

            while(first <= ave && second <= right)
            {
                if(a[first] <= a[second])
                {
                    sort[i++] = a[first++];
                }
                else
                {
                    sort[i++] = a[second++];
                    numberOfInversions += (ave-first+1);
                }
            }
            
            while (first <= ave)
            {
                sort[i++] = a[first++];
            }
            while(second <= right)
            {
                sort[i++] = a[second++];
            }

            for (int j = 0; j < i; j++)
            {
                a[left + j] = sort[j];
            }

            return numberOfInversions;
        }

        private static int getNumberOfInversionsNaive(int[] a, int left, int right)
        {
            int numberOfInversions = 0;
            for (int i = 0; i < a.Length - 1; i++)
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        numberOfInversions++;
                    }
                }
            return numberOfInversions;
        }

        private static bool RunTests()
        {
            Random rnd = new Random();
            int n = rnd.Next(1, 100001);
            int[] a = new int[n];
            for(int i=0;i<n;i++)
            {
                a[i] = rnd.Next(1, 1000000001);
            }

            int naive = getNumberOfInversionsNaive(a, 0, n - 1);
            int merge = getNumberOfInversions(a, 0, n - 1);
            if (merge != naive)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(a[i].ToString() + ' ');
                }
                Console.WriteLine("Naive: " + naive.ToString() + " Merge: " + merge.ToString());
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            
            Console.WriteLine(getNumberOfInversions(a, 0, n - 1).ToString());

            /*
            foreach (int i in a)
                Console.Write(i.ToString() + ' ');
            
            for(int i=0;i<int.MaxValue;i++)
            {
                if (RunTests() == false)
                    break;
            }
            
            Console.WriteLine("Done.");
            Console.ReadLine();
            */
        }
    }
}
