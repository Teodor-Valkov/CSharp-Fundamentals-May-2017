namespace _04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    int index = stack.Pop();

                    string expression = input.Substring(index, i - index + 1);

                    Console.WriteLine(expression);
                }
            }
        }
    }
}