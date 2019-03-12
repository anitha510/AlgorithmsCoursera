/*
Input Format. The first line of the input contains two integers 𝑛 and 𝑚 — the number of tables in the
database and the number of merge queries to perform, respectively.
The second line of the input contains 𝑛 integers 𝑟𝑖 — the number of rows in the 𝑖-th table.
Then follow 𝑚 lines describing merge queries. Each of them contains two integers 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖 and
𝑠𝑜𝑢𝑟𝑐𝑒𝑖 — the numbers of the tables to merge.
Constraints. 1 ≤ 𝑛,𝑚 ≤ 100 000; 0 ≤ 𝑟𝑖 ≤ 10 000; 1 ≤ 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖, 𝑠𝑜𝑢𝑟𝑐𝑒𝑖 ≤ 𝑛.
Output Format. For each query print a line containing a single integer — the maximum of the sizes of all
tables (in terms of the number of rows) after the corresponding operation.
Memory Limit. 512Mb.
7
Sample 1.
Input:
5 5
1 1 1 1 1
3 5
2 4
1 4
5 4
5 3
Output:
2
2
3
5
5
Explanation:
In this sample, all the tables initially have exactly 1 row of data. Consider the merging operations:
1. All the data from the table 5 is copied to table number 3. Table 5 now contains only a symbolic
link to table 3, while table 3 has 2 rows. 2 becomes the new maximum size.
2. 2 and 4 are merged in the same way as 3 and 5.
3. We are trying to merge 1 and 4, but 4 has a symbolic link pointing to 2, so we actually copy
all the data from the table number 2 to the table number 1, clear the table number 2 and put a
symbolic link to the table number 1 in it. Table 1 now has 3 rows of data, and 3 becomes the new
maximum size.
4. Traversing the path of symbolic links from 4 we have 4 → 2 → 1, and the path from 5 is 5 → 3.
So we are actually merging tables 3 and 1. We copy all the rows from the table number 1 into
the table number 3, and now the table number 3 has 5 rows of data, which is the new maximum.
5. All tables now directly or indirectly point to table 3, so all other merges won’t change anything.
Sample 2.
Input:
6 4
10 0 5 0 3 3
6 6
6 5
5 4
4 3
Output:
10
10
10
11
Explanation:
In this example tables have different sizes. Let us consider the operations:
1. Merging the table number 6 with itself doesn’t change anything, and the maximum size is 10
(table number 1).
8
2. After merging the table number 5 into the table number 6, the table number 5 is cleared and has
size 0, while the table number 6 has size 6. Still, the maximum size is 10.
3. By merging the table number 4 into the table number 5, we actually merge the table number 4
into the table number 6 (table 5 now contains just a symbolic link to table 6), so the table number
4 is cleared and has size 0, while the table number 6 has size 6. Still, the maximum size is 10.
4. By merging the table number 3 into the table number 4, we actually merge the table number 3
into the table number 6 (table 4 now contains just a symbolic link to table 6), so the table number
3 is cleared and has size 0, while the table number 6 has size 11, which is the new maximum size. 
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingTables
{
    class Program
    {
        static int[] parent;
        static int[] rank;
        static long[] rows;

        static int Find(int i)
        {
            if (i != parent[i])
            {
                parent[i] = Find(parent[i]);
            }
            return parent[i];
        }

        static long Union(int i, int j)
        {
            int i_id = Find(i);
            int j_id = Find(j);

            if(i_id==j_id)
                return rows[i_id];
            
            if(rank[i_id] > rank[j_id])
            {
                parent[j_id] = i_id;
                rows[i_id] += rows[j_id];
                return rows[i_id];
            }
            else
            {
                parent[i_id] = j_id;
                if(rank[i_id] == rank[j_id])
                {
                    rank[j_id] = rank[j_id] + 1;
                }
                rows[j_id] += rows[i_id];
                return rows[j_id];
            }

        }
        
        static void Main(string[] args)
        {
            var tokes = Console.ReadLine().Split(' ');
            int tables_count = int.Parse(tokes[0]);
            int merge_count = int.Parse(tokes[1]);
            rows = Console.ReadLine().Split(' ').Select(r => long.Parse(r)).ToArray();
            rank = new int[tables_count];
            parent = rank.Select((rnk, idx) => idx).ToArray();
            int i, j;
            List<long> results = new List<long>();
            long max = rows.Max();
            long merged_rows = 0;

            for(int m=0;m<merge_count;m++)
            {
                tokes = Console.ReadLine().Split(' ');
                i = int.Parse(tokes[0]) - 1;
                j = int.Parse(tokes[1]) - 1;
                merged_rows = Union(i, j);
                max = (merged_rows > max) ? merged_rows : max;
                results.Add(max);
            }

            foreach(long r in results)
            {
                Console.WriteLine(r.ToString());
            }

            //Console.ReadLine();
        }
    }
}
