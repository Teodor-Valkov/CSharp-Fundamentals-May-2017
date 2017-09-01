namespace _02.ArraySlider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    internal class StartUp
    {
        private static void Main()
        {
            List<BigInteger> numbers = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToList();

            int index = 0;

            string input = String.Empty;
            while ((input = Console.ReadLine()).ToLower() != "stop")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int offset = int.Parse(inputArgs[0]);
                string symbol = inputArgs[1];
                int number = int.Parse(inputArgs[2]);

                index = index + offset % numbers.Count;

                if (index >= numbers.Count)
                {
                    index -= numbers.Count;
                }

                if (index < 0)
                {
                    index += numbers.Count;
                }

                switch (symbol)
                {
                    case "*":
                        numbers[index] *= number;
                        break;

                    case "/":
                        numbers[index] /= number;
                        break;

                    case "+":
                        numbers[index] += number;
                        break;

                    case "-":
                        numbers[index] -= number;
                        break;

                    case "&":
                        numbers[index] &= number;
                        break;

                    case "|":
                        numbers[index] |= number;
                        break;

                    case "^":
                        numbers[index] ^= number;
                        break;
                }

                if (numbers[index] < 0)
                {
                    numbers[index] = 0;
                }
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}