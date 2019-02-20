/*
 * The goal in this problem is to find the minimum number of coins needed to change the input value
 * (an integer) into coins with denominations 1, 5, and 10.
 * Input Format. The input consists of a single integer 𝑚.
 * Constraints. 1 ≤ 𝑚 ≤ 1000.
 * Output Format. Output the minimum number of coins with denominations 1, 5, 10 that changes 𝑚.
 * Sample 1.
 * Input:
 * 2
 * Output:
 * 2
 * 2 = 1 + 1.
 * Sample 2.
 * Input:
 * 28
 * Output:
 * 6
 * 28 = 10 + 10 + 5 + 1 + 1 + 1 
 */

using System;

namespace MoneyChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = int.Parse(Console.ReadLine());
            int dime = money / 10;
            money -= dime * 10;
            int nickel = money / 5;
            money -= nickel * 5;
            int penny = money;

            Console.WriteLine(dime + nickel + penny);
            //Console.ReadLine();
        }
    }
}
