namespace _02.SumNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .GetCountAndSum()));
        }
    }

    public static class ExtensionMethods
    {
        public static string GetCountAndSum(this List<int> list)
        {
            int count = list.Count;
            int sum = list.Sum();

            return $"{count}{Environment.NewLine}{sum}";
        }
    }
}