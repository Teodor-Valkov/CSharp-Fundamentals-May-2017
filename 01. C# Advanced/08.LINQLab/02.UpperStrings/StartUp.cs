namespace _02.UpperStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            List<string> words = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.ToUpper())
                .ToList();

            Console.WriteLine(string.Join(" ", words));
        }
    }
}