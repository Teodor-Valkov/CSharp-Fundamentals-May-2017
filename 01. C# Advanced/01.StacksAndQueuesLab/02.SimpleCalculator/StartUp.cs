namespace _02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(inputArgs);

            int sum = 0;
            while (stack.Count > 0)
            {
                string operand = string.Empty;

                if (stack.Count == 1)
                {
                    operand = "+";
                }

                int number = int.Parse(stack.Pop());

                if (stack.Count > 1)
                {
                    operand = stack.Pop();
                }

                switch (operand)
                {
                    case "+": sum += number; break;
                    case "-": sum -= number; break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}