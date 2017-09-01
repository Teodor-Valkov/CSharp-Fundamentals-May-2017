namespace _01.TakeTwo
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2)
                .ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}