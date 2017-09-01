namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            foreach (char symbol in input)
            {
                if (!dict.ContainsKey(symbol))
                {
                    dict[symbol] = 0;
                }

                dict[symbol]++;
            }

            dict
             .ToList()
             .ForEach(pair =>
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s"));
        }
    }
}