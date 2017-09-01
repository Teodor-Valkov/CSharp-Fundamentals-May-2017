namespace _11.PartyReservation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            List<string> names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Dictionary<string, Func<string, string, bool>> predicates = new Dictionary<string, Func<string, string, bool>>
            {
                { "Starts with", (name, substring) => name.StartsWith(substring) },
                { "Ends with", (name, substring) => name.EndsWith(substring) },
                { "Contains", (name, substring) => name.Contains(substring) },
                { "Length", (name, length) => name.Length.ToString().Equals(length) },
            };

            Dictionary<string, string[]> activeFilters = new Dictionary<string, string[]>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "print")
            {
                string[] inputArgs = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string action = inputArgs[0];
                string filter = inputArgs[1];
                string filterCondition = inputArgs[2];

                string filterName = filter + filterCondition;

                switch (action)
                {
                    case "Add filter":
                        if (!activeFilters.ContainsKey(filterName))
                        {
                            activeFilters[filterName] = new[] { filter, filterCondition };
                        }
                        break;

                    case "Remove filter":
                        if (activeFilters.ContainsKey(filterName))
                        {
                            activeFilters.Remove(filterName);
                        }
                        break;
                }
            }

            List<string> filteredNames = new List<string>();

            foreach (string name in names)
            {
                bool hasToAddName = true;

                foreach (string[] value in activeFilters.Values)
                {
                    if (predicates[value[0]](name, value[1]))
                    {
                        hasToAddName = false;
                        break;
                    }
                }

                if (hasToAddName)
                {
                    filteredNames.Add(name);
                }
            }

            Console.WriteLine(string.Join(" ", filteredNames));
        }
    }
}