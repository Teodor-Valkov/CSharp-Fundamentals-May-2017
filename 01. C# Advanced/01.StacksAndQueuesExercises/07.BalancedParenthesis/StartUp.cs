namespace _07.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            bool areEqual = true;

            foreach (char symbol in input)
            {
                char[] endingSymbols = { ')', '}', ']' };

                if (stack.Count == 0 && endingSymbols.Contains(symbol))
                {
                    areEqual = false;
                }

                if (!areEqual)
                {
                    break;
                }

                switch (symbol)
                {
                    case '(':
                        stack.Push(symbol);
                        break;

                    case '{':
                        stack.Push(symbol);
                        break;

                    case '[':
                        stack.Push(symbol);
                        break;

                    case ')':
                        if (stack.Pop() != '(')
                        {
                            areEqual = false;
                        }
                        break;

                    case '}':
                        if (stack.Pop() != '{')
                        {
                            areEqual = false;
                        }
                        break;

                    case ']':
                        if (stack.Pop() != '[')
                        {
                            areEqual = false;
                        }
                        break;
                }
            }

            Console.WriteLine(areEqual ? "YES" : "NO");
        }
    }
}