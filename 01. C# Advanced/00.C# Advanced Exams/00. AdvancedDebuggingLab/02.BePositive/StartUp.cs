namespace _02.BePositive
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<double> numbers = new List<double>();

                foreach (string symbol in input)
                {
                    if (!symbol.Equals(string.Empty))
                    {
                        numbers.Add(double.Parse(symbol));
                    }
                }

                bool found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    double currentNum = numbers[j];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(currentNum);

                        found = true;
                    }
                    else
                    {
                        if (j == numbers.Count - 1)
                        {
                            break;
                        }

                        currentNum += numbers[j + 1];

                        if (currentNum >= 0)
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            Console.Write(currentNum);

                            j++;
                            found = true;
                        }
                        else
                        {
                            j++;
                        }
                    }
                }

                if (!found)
                {
                    Console.Write("(empty)");
                }

                Console.WriteLine();
            }
        }
    }
}