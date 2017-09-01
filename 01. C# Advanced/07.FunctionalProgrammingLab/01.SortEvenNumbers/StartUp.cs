namespace _01.SortEvenNumbers
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(num => num % 2 == 0)
                .OrderBy(num => num)));
        }
    }
}