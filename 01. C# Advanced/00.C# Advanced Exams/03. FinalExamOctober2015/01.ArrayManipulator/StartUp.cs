﻿namespace _01.ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            List<long> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string action = inputArgs[0];
                string type = string.Empty;

                long tempNumMax = long.MinValue;
                long tempNumMin = long.MaxValue;
                int count = 0;
                int index = 0;

                List<long> tempList = new List<long>();
                List<long> tempListCount = new List<long>();

                switch (action)
                {
                    case "exchange":
                        index = int.Parse(inputArgs[1]);
                        if (index >= numbers.Count || index < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        tempList = numbers.Take(index + 1).ToList();
                        numbers.RemoveRange(0, index + 1);
                        numbers.AddRange(tempList);
                        break;

                    case "max":
                        type = inputArgs[1];
                        switch (type)
                        {
                            case "even":
                                //foreach (long num in numbers)
                                //{
                                //    if (num % 2 == 0)
                                //    {
                                //        if (num > tempNumMax)
                                //        {
                                //            tempNumMax = num;
                                //        }
                                //    }
                                //}

                                tempNumMax = numbers.Where(num => num % 2 == 0).Max();

                                Console.WriteLine(tempNumMax == long.MinValue
                                    ? "No matches"
                                    : $"{numbers.LastIndexOf(tempNumMax)}");
                                break;

                            case "odd":
                                //foreach (long num in numbers)
                                //{
                                //    if (num % 2 == 1)
                                //    {
                                //        if (num > tempNumMax)
                                //        {
                                //            tempNumMax = num;
                                //        }
                                //    }
                                //}

                                tempNumMax = numbers.Where(num => num % 2 == 1).Max();

                                Console.WriteLine(tempNumMax == long.MinValue
                                    ? "No matches"
                                    : $"{numbers.LastIndexOf(tempNumMax)}");
                                break;
                        }
                        break;

                    case "min":
                        type = inputArgs[1];
                        switch (type)
                        {
                            case "even":
                                //foreach (long num in numbers)
                                //{
                                //    if (num % 2 == 0)
                                //    {
                                //        if (num < tempNumMin)
                                //        {
                                //            tempNumMin = num;
                                //        }
                                //    }
                                //}

                                tempNumMin = numbers.Where(num => num % 2 == 0).Min();

                                Console.WriteLine(tempNumMin == long.MaxValue
                                    ? "No matches"
                                    : $"{numbers.LastIndexOf(tempNumMin)}");
                                break;

                            case "odd":
                                //foreach (long num in numbers)
                                //{
                                //    if (num % 2 == 1)
                                //    {
                                //        if (num < tempNumMin)
                                //        {
                                //            tempNumMin = num;
                                //        }
                                //    }
                                //}

                                tempNumMin = numbers.Where(num => num % 2 == 1).Min();

                                Console.WriteLine(tempNumMin == long.MaxValue
                                    ? "No matches"
                                    : $"{numbers.LastIndexOf(tempNumMin)}");
                                break;
                        }
                        break;

                    case "first":
                        count = int.Parse(inputArgs[1]);
                        type = inputArgs[2];

                        if (count > numbers.Count || count < 0)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        switch (type)
                        {
                            case "even":
                                foreach (long num in numbers)
                                {
                                    if (num % 2 == 0)
                                    {
                                        tempListCount.Add(num);
                                        if (tempListCount.Count == count)
                                        {
                                            Console.WriteLine($"[{string.Join(", ", tempListCount)}]");
                                            break;
                                        }
                                    }
                                }

                                if (tempListCount.Count < count)
                                {
                                    Console.WriteLine($"[{string.Join(", ", tempListCount)}]");
                                }
                                break;

                            case "odd":
                                foreach (long num in numbers)
                                {
                                    if (num % 2 == 1)
                                    {
                                        tempListCount.Add(num);
                                        if (tempListCount.Count == count)
                                        {
                                            Console.WriteLine($"[{string.Join(", ", tempListCount)}]");
                                            break;
                                        }
                                    }
                                }

                                if (tempListCount.Count < count)
                                {
                                    Console.WriteLine($"[{string.Join(", ", tempListCount)}]");
                                }
                                break;
                        }
                        break;

                    case "last":
                        count = int.Parse(inputArgs[1]);
                        type = inputArgs[2];

                        if (count > numbers.Count || count < 0)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        switch (type)
                        {
                            case "even":
                                for (int i = numbers.Count - 1; i >= 0; i--)
                                {
                                    if (numbers[i] % 2 == 0)
                                    {
                                        tempListCount.Add(numbers[i]);
                                        if (tempListCount.Count == count)
                                        {
                                            tempListCount.Reverse();
                                            Console.WriteLine($"[{string.Join(", ", tempListCount)}]");
                                            break;
                                        }
                                    }
                                }

                                if (tempListCount.Count < count)
                                {
                                    tempListCount.Reverse();
                                    Console.WriteLine($"[{string.Join(", ", tempListCount)}]");
                                }
                                break;

                            case "odd":
                                for (int i = numbers.Count - 1; i >= 0; i--)
                                {
                                    if (numbers[i] % 2 == 1)
                                    {
                                        tempListCount.Add(numbers[i]);
                                        if (tempListCount.Count == count)
                                        {
                                            tempListCount.Reverse();
                                            Console.WriteLine($"[{string.Join(", ", tempListCount)}]");
                                            break;
                                        }
                                    }
                                }

                                if (tempListCount.Count < count)
                                {
                                    tempListCount.Reverse();
                                    Console.WriteLine($"[{string.Join(", ", tempListCount)}]");
                                }
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}