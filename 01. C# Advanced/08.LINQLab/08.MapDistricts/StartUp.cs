namespace _08.MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            long number = long.Parse(Console.ReadLine());

            Dictionary<string, List<long>> cities = new Dictionary<string, List<long>>();

            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string inputArg in inputArgs)
            {
                string[] args = inputArg.Split(':');
                string city = args[0];
                long districtPopulation = int.Parse(args[1]);

                if (!cities.ContainsKey(city))
                {
                    cities[city] = new List<long>();
                }

                cities[city].Add(districtPopulation);
            }

            cities
             .Where(city => city.Value.Sum() > number)
             .OrderByDescending(city => city.Value.Sum())
             .ToList()
             .ForEach(city => Console.WriteLine($"{city.Key}: {string.Join(" ", city.Value.OrderByDescending(population => population).Take(5))}"));
        }
    }
}