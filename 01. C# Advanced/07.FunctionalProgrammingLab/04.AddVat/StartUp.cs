namespace _04.AddVat
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(num => num * 1.2)
                .ToList()
                .ForEach(item => Console.WriteLine($"{item:F2}"));
        }
    }
}