namespace _12.Inferno2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        public static void Main()
        {
            List<int> gems = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Dictionary<string, Dictionary<int, Predicate<int>>> filters = new Dictionary<string, Dictionary<int, Predicate<int>>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "forge")
            {
                string[] inputArgs = input.Split(';');
                string action = inputArgs[0];
                string filterType = inputArgs[1];
                int filterNumber = int.Parse(inputArgs[2]);

                if (action == "Exclude")
                {
                    Predicate<int> filterPredicate = GetPredicate(gems, filterType, filterNumber);

                    if (!filters.ContainsKey(filterType))
                    {
                        filters[filterType] = new Dictionary<int, Predicate<int>>();
                    }

                    filters[filterType][filterNumber] = filterPredicate;
                }
                else
                {
                    filters[filterType].Remove(filterNumber);
                }
            }

            gems = Filter(gems, filters);
            Console.WriteLine(string.Join(" ", gems));
        }

        private static List<int> Filter(List<int> gems, Dictionary<string, Dictionary<int, Predicate<int>>> filters)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                bool isFiltered = false;

                foreach (KeyValuePair<string, Dictionary<int, Predicate<int>>> filter in filters)
                {
                    foreach (KeyValuePair<int, Predicate<int>> predicate in filter.Value)
                    {
                        if (predicate.Value(i))
                        {
                            isFiltered = true;
                            break;
                        }
                    }
                }

                if (!isFiltered)
                {
                    result.Add(gems[i]);
                }
            }

            return result;
        }

        private static Predicate<int> GetPredicate(List<int> gems, string filterType, int filterParam)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return i => (i <= 0 ? 0 : gems[i - 1]) + gems[i] == filterParam;

                case "Sum Right":
                    return i => gems[i] + (i >= gems.Count - 1 ? 0 : gems[i + 1]) == filterParam;

                case "Sum Left Right":
                    return i => (i <= 0 ? 0 : gems[i - 1]) + gems[i] + (i >= gems.Count - 1 ? 0 : gems[i + 1]) == filterParam;
            }

            return null;
        }
    }
}