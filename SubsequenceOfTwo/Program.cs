/*
Compute the length of a longest common subsequence of three sequences.
Problem Description
Task. Given two sequences 𝐴 = (𝑎1, 𝑎2, . . . , 𝑎𝑛) and 𝐵 = (𝑏1, 𝑏2, . . . , 𝑏𝑚), 
find the length of their longest common subsequence, 
i.e., the largest non-negative integer 𝑝 such that there exist indices 
1 ≤ 𝑖1 < 𝑖2 < · · · < 𝑖𝑝 ≤ 𝑛 and 1 ≤ 𝑗1 < 𝑗2 < · · · < 𝑗𝑝 ≤ 𝑚, such that 𝑎𝑖1 = 𝑏𝑗1 , . . . , 𝑎𝑖𝑝 = 𝑏𝑗𝑝 .
Input Format. First line: 𝑛. Second line: 𝑎1, 𝑎2, . . . , 𝑎𝑛. Third line: 𝑚. Fourth line: 𝑏1, 𝑏2, . . . , 𝑏𝑚.
Constraints. 1 ≤ 𝑛,𝑚 ≤ 100; −10^9 < 𝑎𝑖, 𝑏𝑖 < 10^9.
Output Format. Output 𝑝.
Sample 1.
Input:
3
2 7 5
2
2 5
Output:
2
A common subsequence of length 2 is (2, 5).
Sample 2.
Input:
1
7
4
1 2 3 4
Output:
0
The two sequences do not share elements.
Sample 3.
Input:
4
2 7 8 3
4
5 2 8 7
Output:
2
One common subsequence is (2, 7). Another one is (2, 8).
*/
using System;
using System.Linq;

namespace SubsequenceOfTwo
{
    class Program
    {
        private static int[,] dist;
        private static int[,] seq;
        private static int[] first;
        private static int[] second;

        private static int MaxMatch(int rows, int columns)
        {
            int maxSeq;

            for (int row = 0; row < rows; row++)
            {
                seq[row, 0] = 0;
            }

            for (int col = 0; col < columns; col++)
            {
                seq[0, col] = 0;
            }

            for (int row = 1; row < rows; row++)
                for (int col = 1; col < columns; col++)
                {
                    seq[row, col] = 0;
                    maxSeq = (seq[row, col - 1] > seq[row - 1, col]) ? seq[row, col - 1] : seq[row - 1, col];
                    
                    if (first[col - 1] == second[row - 1])
                    {
                        seq[row, col] = (maxSeq > seq[row - 1, col - 1] + 1) ? maxSeq : seq[row - 1, col - 1] + 1;                       
                    }
                    else
                    {
                        seq[row, col] = (maxSeq > seq[row - 1, col - 1]) ? maxSeq : seq[row - 1, col - 1];
                    }
                }
            return seq[rows - 1, columns - 1];
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            first = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();

            int m = int.Parse(Console.ReadLine());
            second = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();

            int columns = first.Length + 1;
            int rows = second.Length + 1;
            dist = new int[rows, columns];
            seq = new int[rows, columns];

            Console.WriteLine(MaxMatch(rows, columns).ToString());
            
            /*
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                    Console.Write(dist[row, col].ToString() + ' ');
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                    Console.Write(seq[row, col].ToString() + ' ');
                Console.WriteLine();
            }
            Console.ReadLine();
            */
        }
    }
}
