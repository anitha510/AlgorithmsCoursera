/*
A natural greedy strategy for the change problem does not work correctly for any set of
denominations. For example, if the available denominations are 1, 3, and 4, the greedy algorithm will change
6 cents using three coins (4 + 1 + 1) while it can be changed using just two coins (3 + 3). Your goal now is
to apply dynamic programming for solving the Money Change Problem for denominations 1, 3, and 4.
Problem Description
Input Format. Integer money.
Output Format. The minimum number of coins with denominations 1, 3, 4 that changes money.
Constraints. 1 ≤ money ≤ 1000.
Sample 1.
Input:
2
Output:
2
2 = 1 + 1.
Sample 2.
Input:
34
Output:
9
34 = 3 + 3 + 4 + 4 + 4 + 4 + 4 + 4 + 4.
 */
using System;

namespace MoneyChangeDP
{
    class Program
    {
        static int ChangeCoins(int money, int[] coins)
        {
            int[] minNumCoins = new int[money + 1];
            int numCoins = 0;
            minNumCoins[0] = 0;
            for(int m=1;m<=money;m++)
            {
                minNumCoins[m] = int.MaxValue;
                foreach(int coin in coins)
                {
                    if(m>=coin)
                    {
                        numCoins = minNumCoins[m - coin] + 1;
                        if (numCoins < minNumCoins[m])
                        {
                            minNumCoins[m] = numCoins;
                        }
                    }
                }

                //Console.WriteLine(m.ToString() + ": " + minNumCoins[m].ToString());
            }
            return minNumCoins[money];
        }

        static void Main(string[] args)
        {
            int[] coins = new int[3] { 1, 3, 4 };
            int money = int.Parse(Console.ReadLine());
            Console.WriteLine(ChangeCoins(money, coins).ToString());
            
            //Console.ReadLine();
        }
    }
}
