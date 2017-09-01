namespace _05.AppliedArithmetics3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class Functions
    {
        public static List<int> ApplyFunc(List<int> collection, Func<int, int> func)
        {
            return collection.Select(func).ToList();
        }
    }

    internal class StartUp
    {
        private static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Action<List<int>> print = nums => Console.WriteLine($"{string.Join(" ", nums)}");
            //void Print(List<int> nums) => Console.WriteLine($"{string.Join(" ", nums)}");

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                switch (input.ToLower())
                {
                    case "add":
                        numbers = Functions.ApplyFunc(numbers, num => num + 1);
                        break;

                    case "subtract":
                        numbers = Functions.ApplyFunc(numbers, num => num - 1);
                        break;

                    case "multiply":
                        numbers = Functions.ApplyFunc(numbers, num => num * 2);
                        break;

                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}