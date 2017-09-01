namespace _01.CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            List<string> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> tempNumbers = new List<string>();

            int start = 0;
            int count = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] inputArgs = input.Split(' ');
                string command = inputArgs[0];

                switch (command)
                {
                    case "reverse":
                        count = int.Parse(inputArgs[4]);
                        start = int.Parse(inputArgs[2]);

                        if (start < 0 || count < 0 || start >= numbers.Count || (start + count) > numbers.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        tempNumbers = numbers.Skip(start).Take(count).Reverse().ToList();

                        numbers.RemoveRange(start, count);
                        numbers.InsertRange(start, tempNumbers);
                        break;

                    case "sort":
                        start = int.Parse(inputArgs[2]);
                        count = int.Parse(inputArgs[4]);

                        if (start < 0 || count < 0 || start >= numbers.Count || (start + count) > numbers.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        tempNumbers = numbers.Skip(start).Take(count).OrderBy(x => x).ToList();

                        numbers.RemoveRange(start, count);
                        numbers.InsertRange(start, tempNumbers);
                        break;

                    case "rollLeft":
                        count = int.Parse(inputArgs[1]);

                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        for (int i = 0; i < count % numbers.Count; i++)
                        {
                            string element = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(element);
                        }
                        break;

                    case "rollRight":
                        count = int.Parse(inputArgs[1]);

                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        for (int i = 0; i < count % numbers.Count; i++)
                        {
                            string element = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, element);
                        }
                        break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}