namespace _06.FindAndSumIntegers
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            long validNumber;

            long[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => long.TryParse(n, out validNumber))
                .Select(long.Parse)
                .ToArray();

            Console.WriteLine(numbers.Any()
                ? $"{numbers.Sum()}"
                : "No match");
        }
    }
}