/*
The edit distance between two strings is the minimum number of operations (insertions, deletions, and
substitutions of symbols) to transform one string into another. It is a measure of similarity of two strings.
Edit distance has applications, for example, in computational biology, natural language processing, and spell
checking. Your goal in this problem is to compute the edit distance between two strings.
Problem Description
Task. The goal of this problem is to implement the algorithm for computing the edit distance between two
strings.
Input Format. Each of the two lines of the input contains a string consisting of lower case latin letters.
Constraints. The length of both strings is at least 1 and at most 100.
Output Format. Output the edit distance between the given two strings.
Sample 1.
Input:
ab
ab
Output:
0
Sample 2.
Input:
short
ports
Output:
3
An alignment of total cost 3:
s h o r t −
− p o r t s
Sample 3.
Input:
editing
distance
Output:
5
An alignment of total cost 5:
e d i − t i n g −
− d i s t a n c e
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            int columns = first.Length + 1;
            int rows = second.Length + 1;
            int[,] dist = new int[rows, columns];

            int insert, delete, match, mismatch, min;
            
            for (int row = 0; row < rows; row++)
            {
                dist[row, 0] = row;
            }

            for (int col = 0; col < columns; col++)
            {
                dist[0, col] = col;
            }

            for(int row = 1; row < rows; row++)
                for(int col = 1; col < columns; col++)
                {
                    insert = dist[row, col - 1] + 1;
                    delete = dist[row - 1, col] + 1;
                    min = (insert < delete) ? insert : delete;

                    if(first[col-1] == second[row-1])
                    {
                        match = dist[row - 1, col - 1];
                        dist[row, col] = (min < match)? min: match;
                    }
                    else
                    {
                        mismatch = dist[row - 1, col - 1] + 1;
                        dist[row, col] = (min < mismatch) ? min : mismatch;
                    }
                }

            Console.WriteLine(dist[rows-1,columns-1].ToString());
            //Console.ReadLine();
        }
    }
}
