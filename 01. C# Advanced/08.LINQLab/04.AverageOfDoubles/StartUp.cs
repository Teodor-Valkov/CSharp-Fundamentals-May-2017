namespace _04.AverageOfDoubles
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            double average = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Average();

            Console.WriteLine($"{average:F2}");
        }
    }
}