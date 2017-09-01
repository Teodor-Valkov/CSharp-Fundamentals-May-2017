namespace _05.AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            // First way for declaring Func
            Func<int, int> increaseNumbers = num => ++num;
            Func<int, int> decreaseNumbers = num => --num;

            // Second way for declaring Func
            int MultiplyNumbers(int num) => num * 2;

            Action<List<int>> print = nums => Console.WriteLine($"{string.Join(" ", nums)}");
            //void Print(List<int> nums) => Console.WriteLine($"{string.Join(" ", nums)}");

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                switch (input.ToLower())
                {
                    case "add":
                        numbers = numbers.Select(increaseNumbers).ToList();
                        break;

                    case "subtract":
                        numbers = numbers.Select(decreaseNumbers).ToList();
                        break;

                    case "multiply":
                        numbers = numbers.Select(MultiplyNumbers).ToList();
                        break;

                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}