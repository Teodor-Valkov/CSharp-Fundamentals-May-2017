namespace _05.AppliedArithmetics2
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            // First way for declaring Func
            Func<int[], int[]> add = nums => nums.Select(num => num + 1).ToArray();
            Func<int[], int[]> subtract = nums => nums.Select(num => num - 1).ToArray();

            // Second way for declaring Func
            int[] Multiply(int[] nums) => nums.Select(num => num * 2).ToArray();

            Action<int[]> print = nums => Console.WriteLine($"{string.Join(" ", nums)}");
            //void Print(int[] nums) => Console.WriteLine($"{string.Join(" ", nums)}");

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                switch (input.ToLower())
                {
                    case "add":
                        numbers = add(numbers);
                        break;

                    case "multiply":
                        numbers = Multiply(numbers);
                        break;

                    case "subtract":
                        numbers = subtract(numbers);
                        break;

                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}