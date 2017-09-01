namespace _03.ArrayTest
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            long[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "stop")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string action = inputArgs[0];
                long[] values = new long[2];

                if (inputArgs.Contains("add") || inputArgs.Contains("subtract") || inputArgs.Contains("multiply"))
                {
                    values[0] = long.Parse(inputArgs[1]);
                    values[1] = long.Parse(inputArgs[2]);

                    PerformAction(numbers, action, values);
                }
                else
                {
                    PerformAction(numbers, action, values);
                }

                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void PerformAction(long[] numbers, string action, long[] values)
        {
            long position = values[0] - 1;
            long value = values[1];

            switch (action)
            {
                case "multiply":
                    numbers[position] *= value;
                    break;

                case "add":
                    numbers[position] += value;
                    break;

                case "subtract":
                    numbers[position] -= value;
                    break;

                case "lshift":
                    ArrayShiftLeft(numbers);
                    break;

                case "rshift":
                    ArrayShiftRight(numbers);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] numbers)
        {
            long shiftedNumber = numbers[numbers.Length - 1];

            for (int i = numbers.Length - 1; i >= 1; i--)
            {
                numbers[i] = numbers[i - 1];
            }

            numbers[0] = shiftedNumber;
        }

        private static void ArrayShiftLeft(long[] numbers)
        {
            long shiftedNumber = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = numbers[i + 1];
            }

            numbers[numbers.Length - 1] = shiftedNumber;
        }
    }
}