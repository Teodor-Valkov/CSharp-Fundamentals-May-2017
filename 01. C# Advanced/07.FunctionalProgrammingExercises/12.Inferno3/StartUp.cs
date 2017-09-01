namespace _12.Inferno3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<int, int, int> sumLeft = (x, y) => x + y;
            //int SumLeft(int x, int y) => x + y;

            Func<int, int, int> sumRight = (x, y) => x + y;
            //int SumRight(int x, int y) => x + y;

            Func<int, int, int, int> sumLeftRight = (x, y, z) => x + y + z;
            //int SumLeftRight(int x, int y, int z) => x + y + z;

            List<string> commands = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "forge")
            {
                string[] inputArgs = input.Split(';');

                string firstPart = inputArgs[0];
                string secondPart = string.Concat(inputArgs[1], ";", inputArgs[2]);

                if (firstPart == "Exclude")
                {
                    commands.Add(secondPart);
                }
                else
                {
                    if (commands.Contains(secondPart))
                    {
                        commands.Remove(secondPart);
                    }
                }
            }

            int[] filteredNumbers = new int[numbers.Count];

            foreach (string command in commands)
            {
                string[] commandArgs = command.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string operation = commandArgs[0];
                int count = int.Parse(commandArgs[1]);
                int index = 0;

                for (int j = 0; j < numbers.Count; j++)
                {
                    int currentNumber = numbers[j];

                    int previousNumber = j == 0
                        ? 0
                        : numbers[j - 1];

                    int nextNumber = j == numbers.Count - 1
                        ? 0
                        : numbers[j + 1];

                    switch (operation)
                    {
                        case "Sum Left":
                            if (sumLeft(currentNumber, previousNumber) == count)
                            {
                                filteredNumbers[index] = 1;
                            }
                            break;

                        case "Sum Right":
                            if (sumRight(currentNumber, nextNumber) == count)
                            {
                                filteredNumbers[index] = 1;
                            }
                            break;

                        case "Sum Left Right":
                            if (sumLeftRight(currentNumber, previousNumber, nextNumber) == count)
                            {
                                filteredNumbers[index] = 1;
                            }
                            break;
                    }

                    index++;
                }
            }

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                int currentNum = i;
                if (filteredNumbers[currentNum] == 1)
                {
                    numbers.RemoveAt(currentNum);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}