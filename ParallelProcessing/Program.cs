/*
You have a program which is parallelized and uses 𝑛 independent threads to process the given list
of 𝑚 jobs. Threads take jobs in the order they are given in the input. If there is a free thread,
it immediately takes the next job from the list. If a thread has started processing a job, it doesn’t
interrupt or stop until it finishes processing the job. If several threads try to take jobs from the list
simultaneously, the thread with smaller index takes the job. For each job you know exactly how long
will it take any thread to process this job, and this time is the same for all the threads. You need to
determine for each job which thread will process it and when will it start processing.
Input Format. The first line of the input contains integers 𝑛 and 𝑚.
The second line contains 𝑚 integers 𝑡𝑖 — the times in seconds it takes any thread to process 𝑖-th job.
The times are given in the same order as they are in the list from which threads take jobs.
Threads are indexed starting from 0.
Constraints. 1 ≤ 𝑛 ≤ 10^5; 1 ≤ 𝑚 ≤ 10^5; 0 ≤ 𝑡𝑖 ≤ 10^9.
Output Format. Output exactly 𝑚 lines. 𝑖-th line (0-based index is used) should contain two spaceseparated
integers — the 0-based index of the thread which will process the 𝑖-th job and the time in
seconds when it will start processing that job.
Memory Limit. 512Mb.
Sample 1.
Input:
2 5
1 2 3 4 5
Output:
0 0
1 0
0 1
1 2
0 4
Explanation:
1. The two threads try to simultaneously take jobs from the list, so thread with index 0 actually
takes the first job and starts working on it at the moment 0.
2. The thread with index 1 takes the second job and starts working on it also at the moment 0.
3. After 1 second, thread 0 is done with the first job and takes the third job from the list, and starts
processing it immediately at time 1.
4. One second later, thread 1 is done with the second job and takes the fourth job from the list, and
starts processing it immediately at time 2.
5
5. Finally, after 2 more seconds, thread 0 is done with the third job and takes the fifth job from the
list, and starts processing it immediately at time 4.
Sample 2.
Input:
4 20
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
Output:
0 0
1 0
2 0
3 0
0 1
1 1
2 1
3 1
0 2
1 2
2 2
3 2
0 3
1 3
2 3
3 3
0 4
1 4
2 4
3 4
Explanation:
Jobs are taken by 4 threads in packs of 4, processed in 1 second, and then the next pack comes. This
happens 5 times starting at moments 0, 1, 2, 3 and 4. After that all the 5×4 = 20 jobs are processed.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParallelProcessing
{
    struct Thread
    {
        internal int index;
        internal long nextFreeTime;
    }

    class Program
    {
        static void SwiftDown(int i, Thread[] a)
        {
            Thread tmp;
            int minIndex = i;
            int left = (i * 2) + 1;
            int right = (i * 2) + 2;
            if (left < a.Length && a[left].nextFreeTime <= a[minIndex].nextFreeTime)
            {
                minIndex = (a[left].nextFreeTime == a[minIndex].nextFreeTime && a[minIndex].index < a[left].index) ? minIndex: left;
            }
            if (right < a.Length && a[right].nextFreeTime <= a[minIndex].nextFreeTime)
            {
                minIndex = (a[right].nextFreeTime == a[minIndex].nextFreeTime && a[minIndex].index < a[right].index) ? minIndex : right;
            }
            if (i != minIndex)
            {
                tmp = a[i];
                a[i] = a[minIndex];
                a[minIndex] = tmp;
                
                SwiftDown(minIndex, a);
            }
        }

        static void Main(string[] args)
        {
            //System.IO.StreamReader input = new System.IO.StreamReader(@"C:\Users\Anitha Thanam\OneDrive\Learning\Algorithms\2DataStructures\Week2_PriorityQueue_Heap\job_queue\tests\08");
            //System.IO.StreamReader output = new System.IO.StreamReader(@"C:\Users\Anitha Thanam\OneDrive\Learning\Algorithms\2DataStructures\Week2_PriorityQueue_Heap\job_queue\tests\08.a");

            //int n = int.Parse(input.ReadLine().Split(' ').First());
            //long[] jobs = input.ReadLine().Split(' ').Select(r => long.Parse(r)).ToArray();

            int n = int.Parse(Console.ReadLine().Split(' ').First());
            long[] jobs = Console.ReadLine().Split(' ').Select(r => long.Parse(r)).ToArray();
            Thread[] threads = new Thread[n];

            for(int i=0;i<n;i++)
            {
                threads[i].index = i;
                threads[i].nextFreeTime = 0;
            }

            foreach(long job in jobs)
            {
                //var line = output.ReadLine().Split(' ').Select(r => long.Parse(r)).ToArray();
                //if(line[0] != threads[0].index || line[1] != threads[0].nextFreeTime)
                //    Console.WriteLine("Actual:" + threads[0].index.ToString() + ' ' + threads[0].nextFreeTime.ToString() + " Expected:" + line[0].ToString() + ' ' + line[1].ToString());

                Console.WriteLine(threads[0].index.ToString() + ' ' + threads[0].nextFreeTime.ToString());
                threads[0].nextFreeTime += job;
                SwiftDown(0, threads);
            }

            //Console.ReadLine();
        }
    }
}
