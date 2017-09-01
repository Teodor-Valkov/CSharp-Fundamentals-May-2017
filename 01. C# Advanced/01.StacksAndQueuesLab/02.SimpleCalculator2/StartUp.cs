namespace _02.SimpleCalculator2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(inputArgs.Reverse());

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string operand = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                switch (operand)
                {
                    case "+":
                        stack.Push((firstNumber + secondNumber).ToString());
                        break;

                    case "-":
                        stack.Push((firstNumber - secondNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}