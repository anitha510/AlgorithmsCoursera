using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckBrackets
{
    class Program
    {
        private static int IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();
            Stack<int> index = new Stack<int>();
            char top;

            for(int i=0;i<input.Length;i++)
            {
                if(input[i] == '[' || input[i] == '{' || input[i] == '(')
                {
                    stack.Push(input[i]);
                    index.Push(i);
                }
                else if (input[i] == ']' || input[i] == '}' || input[i] == ')')
                {
                    if (stack.Count == 0)
                        return i+1;
                    top = stack.Pop();
                    index.Pop();
                    switch(top)
                    {
                        case '[':
                            if (input[i] != ']')
                                return i + 1;
                            break;
                        case '{':
                            if (input[i] != '}')
                                return i + 1;
                            break;
                        case '(':
                            if (input[i] != ')')
                                return i + 1;
                            break;
                    }
                }
            }

            if(index.Count != 0)
            {
                return index.Pop() + 1;
            }

            return 0; // Success
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = IsBalanced(input);

            if (result == 0)
                Console.WriteLine("Success");
            else
                Console.WriteLine(result.ToString());

            //Console.ReadLine();
        }
    }
}
