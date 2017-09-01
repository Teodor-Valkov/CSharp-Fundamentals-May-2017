namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Stack<int> numbers = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();

            for (int i = 0; i < num; i++)
            {
                int[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int command = inputArgs[0];

                switch (command)
                {
                    case 1:
                        int numberToPush = inputArgs[1];
                        numbers.Push(numberToPush);

                        if (maxNumbers.Count == 0 || numberToPush >= maxNumbers.Peek())
                        {
                            maxNumbers.Push(numberToPush);
                        }
                        break;

                    case 2:
                        int numberToPop = numbers.Peek();
                        int currentMaxNumber = maxNumbers.Peek();

                        numbers.Pop();
                        if (numberToPop == currentMaxNumber)
                        {
                            maxNumbers.Pop();
                        }
                        break;

                    case 3:
                        Console.WriteLine(maxNumbers.Peek());
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}