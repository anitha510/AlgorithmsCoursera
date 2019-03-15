/*
In this problem your goal is to implement the Rabin–Karp’s algorithm for searching the given pattern
in the given text.
Input Format. There are two strings in the input: the pattern 𝑃 and the text 𝑇.
Constraints. 1 ≤ |𝑃| ≤ |𝑇| ≤ 5 · 105. The total length of all occurrences of 𝑃 in 𝑇 doesn’t exceed 108. The
pattern and the text contain only latin letters.
Output Format. Print all the positions of the occurrences of 𝑃 in 𝑇 in the ascending order. Use 0-based
indexing of positions in the the text 𝑇.
Time Limits. C: 1 sec, C++: 1 sec, Java: 5 sec, Python: 5 sec. C#: 1.5 sec, Haskell: 2 sec, JavaScript:
3 sec, Ruby: 3 sec, Scala: 3 sec.
Memory Limit. 512Mb.
Sample 1.
Input:
aba
abacaba
Output:
0 4
Explanation:
The pattern 𝑎𝑏𝑎 can be found in positions 0 (abacaba) and 4 (abacaba) of the text 𝑎𝑏𝑎𝑐𝑎𝑏𝑎.
Sample 2.
Input:
Test
testTesttesT
Output:
4
Explanation:
Pattern and text are case-sensitive in this problem. Pattern 𝑇𝑒𝑠𝑡 can only be found in position 4 in
the text 𝑡𝑒𝑠𝑡𝑇 𝑒𝑠𝑡𝑡𝑒𝑠𝑇 .
Sample 3.
Input:
aaaaa
baaaaaaa
Output:
1 2 3
Explanation:
Note that the occurrences of the pattern in the text can be overlapping, and that’s ok, you still need
to output all of them. 
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchPattern
{
    class Program
    {
        const int MaxStringLength = 15;
        const int prime = 1000000007;
        const int x = 263; //random number between 1 and prime-1

        static long PolyHash(string s)
        {
            long result = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                result = ((result * x) + (int)s[i]) % prime;
            }

            return result;
        }

        static long[] PreComputeHashes(string text, int patternLength)
        {
            string s = text.Substring(text.Length-patternLength);
            long[] hash = new long[text.Length - patternLength + 1];
            hash[text.Length - patternLength] = PolyHash(s);
            int y = 1;
            for (int i = 1; i <= patternLength; i++)
                y = (y * x) % prime;
            for(int i = text.Length - patternLength - 1; i>=0;i--)
            {
                hash[i] = (x * hash[i+1] + (int)text[i] - y * (int)text[i + patternLength]) % prime;
            }
            return hash;
        }

        static List<int> RabinKarp(string text, string pattern)
        {
            List<int> result = new List<int>();
            long pHash = PolyHash(pattern);
            long[] hash = PreComputeHashes(text, pattern.Length);
            for(int i=0;i<=text.Length-pattern.Length;i++)
            {
                if (pHash != hash[i])
                    continue;
                if (pattern == text.Substring(i, pattern.Length))
                    result.Add(i);
            }
            return result;
        }

        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            foreach(int p in RabinKarp(text, pattern))
            {
                Console.Write(p.ToString() + ' ');
            }
            Console.ReadLine();
        }
    }
}
