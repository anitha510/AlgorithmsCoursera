/*
You are given a primitive calculator that can perform the following three operations with
the current number 𝑥: multiply 𝑥 by 2, multiply 𝑥 by 3, or add 1 to 𝑥. Your goal is given a
positive integer 𝑛, find the minimum number of operations needed to obtain the number 𝑛
starting from the number 1.
Problem Description
Task. Given an integer 𝑛, compute the minimum number of operations needed to obtain the number 𝑛
starting from the number 1.
Input Format. The input consists of a single integer 1 ≤ 𝑛 ≤ 10^6.
Output Format. In the first line, output the minimum number 𝑘 of operations needed to get 𝑛 from 1.
In the second line output a sequence of intermediate numbers. That is, the second line should contain
positive integers 𝑎0, 𝑎2, . . . , 𝑎𝑘−1 such that 𝑎0 = 1, 𝑎𝑘−1 = 𝑛 and for all 0 ≤ 𝑖 < 𝑘 − 1, 𝑎𝑖+1 is equal to
either 𝑎𝑖 + 1, 2𝑎𝑖, or 3𝑎𝑖. If there are many such sequences, output any one of them.
Sample 1.
Input:
1
Output:
0
1
Sample 2.
Input:
5
Output:
3
1 2 4 5
Here, we first multiply 1 by 2 two times and then add 1. Another possibility is to first multiply by 3
and then add 1 two times. Hence “1 3 4 5” is also a valid output in this case.
Sample 3.
Input:
96234
Output:
14
1 3 9 10 11 22 66 198 594 1782 5346 16038 16039 32078 96234
Again, another valid output in this case is “1 3 9 10 11 33 99 297 891 2673 8019 16038 16039 48117
96234”.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimitiveCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] minNum = new int[n + 1];
            int[][] sequence = new int[n + 1][];
            int num1 = 0, num2 = 0, num3 = 0, previous = 0, seq = 0;
            minNum[0] = 0;
            for (int m = 1; m <= n; m++)
            {
                num1 = minNum[m - 1] + 1;

                if (m % 2 == 0)
                    num2 = minNum[m / 2] + 1;
                else
                    num2 = m + 1;

                if (m % 3 == 0)
                    num3 = minNum[m / 3] + 1;
                else
                    num3 = m + 1;
                
                if(num1 <= num2 && num1 <= num3) //Adding 1 is the min
                {
                    minNum[m] = num1;
                    previous = m-1;
                }
                else if(num2 <= num1 && num2 <= num3) //multiplying 2 is min
                {
                    minNum[m] = num2;
                    previous = m/2;
                }
                else //multiplying 3 is min
                {
                    minNum[m] = num3;
                    previous = m / 3;
                }

                sequence[m] = new int[minNum[m]+1];

                for (seq = 1; seq < minNum[m]; seq++)
                {
                    sequence[m][seq] = sequence[previous][seq];
                }
                sequence[m][seq] = m;
            }
            /*
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i.ToString() + '\t');
            }
            Console.WriteLine();
            for (int j = 1; j <= n; j++)
            {
                Console.Write(minNum[j].ToString() + '\t');
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int row = 1; row <= n; row++)
            { 
                for (int col = 1; col <= n; col++)
                {
                    Console.Write(sequence[row, col].ToString() + '\t');
                }
                Console.WriteLine();
            }
            */
            Console.WriteLine((minNum[n]-1).ToString());
            for (int s = 1; s <= minNum[n]; s++)
                Console.Write(sequence[n][s].ToString() + ' ');
            //Console.ReadLine();
        }
    }
}
