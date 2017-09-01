namespace _05.MinEvenNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .ToList();

            Console.WriteLine(numbers.Any()
                ? $"{numbers.Min():F2}"
                : "No match");
        }
    }
}