/*
 * The goal of this code problem is to implement an algorithm for the fractional knapsack problem.
 * Input Format. The first line of the input contains the number 𝑛 of items and the capacity 𝑊 of a knapsack.
 * The next 𝑛 lines define the values and weights of the items. The 𝑖-th line contains integers 𝑣𝑖 and 𝑤𝑖—the
 * value and the weight of 𝑖-th item, respectively.
 * Constraints. 1 ≤ 𝑛 ≤ 1000, 0 ≤ 𝑊 ≤ 2,000,000; 0 ≤ 𝑣𝑖 ≤ 2,000,000, 0 < 𝑤𝑖 ≤ 2,000,000 
 * for all 1 ≤ 𝑖 ≤ 𝑛. All the numbers are integers.
 * Output Format. Output the maximal value of fractions of items that fit into the knapsack. The absolute
 * value of the difference between the answer of your program and the optimal value should be at most
 * 10^−3. To ensure this, output your answer with at least four digits after the decimal point (otherwise
 * your answer, while being computed correctly, can turn out to be wrong because of rounding issues).
 * Sample 1.
 * Input:
 * 3 50
 * 60 20
 * 100 50
 * 120 30
 * Output:
 * 180.0000
 * To achieve the value 180, we take the first item and the third item into the bag.
 * Sample 2.
 * Input:
 * 1 10
 * 500 30
 * Output:
 * 166.6667
 * Here, we just take one third of the only available item.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ');
            int n = int.Parse(tokens[0]);
            int capacity = int.Parse(tokens[1]);

            int v=0, w=0, i=0, j=0, total_weight=0;
            double p=0, total_value=0;
            var items = new List<Tuple<int, int, double>>();

            // Get all the input vi and wi
            for(i=0; i<n; i++)
            {
                tokens = Console.ReadLine().Split(' ');
                v = int.Parse(tokens[0]);
                w = int.Parse(tokens[1]);
                p = (double)v/w;
                
                // Insert in sorted manner
                for(j=0;j<items.Count;j++)
                {
                    if(p>items[j].Item3)
                        break;
                }
                items.Insert(j, new Tuple<int, int, double>(v,w,p));
            }

            foreach(var t in items)
            {
                // If the item can be filled then take it as whole
                if(capacity - total_weight > t.Item2)
                {
                    total_weight += t.Item2;
                    total_value += t.Item1;
                }
                // else take the portion of it
                else
                {
                    total_value += t.Item3 * (capacity-total_weight);
                    break;
                }
                
            }
            
            Console.WriteLine(Math.Round(total_value,4));
            //Console.ReadLine();
        }
    }
}
