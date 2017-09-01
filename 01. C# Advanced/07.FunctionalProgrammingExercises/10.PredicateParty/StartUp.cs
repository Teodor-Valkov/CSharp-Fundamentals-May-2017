namespace _10.PredicateParty
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
                { "StartsWith", (name, substring) => name.StartsWith(substring) },
                { "EndsWith", (name, substring) => name.EndsWith(substring) },
                { "Length", (name, length) => name.Length.ToString().Equals(length) }
            };

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "party!")
            {
                if (names.Count == 0)
                {
                    break;
                }

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string action = inputArgs[0];
                string condition = inputArgs[1];
                string conditionOperator = inputArgs[2];

                List<string> filteredNames = new List<string>();

                foreach (string name in names)
                {
                    if (predicates[condition](name, conditionOperator))
                    {
                        switch (action)
                        {
                            case "Double":
                                filteredNames.Add(name);
                                filteredNames.Add(name);
                                break;

                            case "Remove":
                                break;
                        }
                    }
                    else
                    {
                        filteredNames.Add(name);
                    }
                }

                names = filteredNames.ToList();
            }

            Console.WriteLine(names.Any()
                ? $"{string.Join(", ", names)} are going to the party!"
                : "Nobody is going to the party!");
        }
    }
}