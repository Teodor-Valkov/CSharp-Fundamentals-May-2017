namespace _12.Inferno
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        public static void Main()
        {
            List<int> gems = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            HashSet<string> excludes = new HashSet<string>();
            HashSet<string> reverses = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "forge")
            {
                string[] inputArgs = input.Split(';');
                string action = inputArgs[0];
                string filterType = inputArgs[1];
                int filterNumber = int.Parse(inputArgs[2]);

                string command = filterType + ";" + filterNumber;

                switch (action)
                {
                    case "Exclude":
                        excludes.Add(command);
                        break;

                    case "Reverse":
                        reverses.Add(command);
                        break;
                }
            }

            string[] commands = excludes.Except(reverses).ToArray();

            gems = Filter(gems, commands);
            Console.WriteLine(string.Join(" ", gems));
        }

        private static List<int> Filter(List<int> gems, string[] commands)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                bool needsToBeFiltered = false;

                foreach (string command in commands)
                {
                    string[] commandArgs = command.Split(';');
                    string filterType = commandArgs[0];
                    int filterNumber = int.Parse(commandArgs[1]);

                    switch (filterType)
                    {
                        case "Sum Left":
                            needsToBeFiltered = LeftPredicate(gems, filterNumber, i);
                            break;

                        case "Sum Right":
                            needsToBeFiltered = RightPredicate(gems, filterNumber, i);
                            break;

                        case "Sum Left Right":
                            needsToBeFiltered = LeftRightPredicate(gems, filterNumber, i);
                            break;
                    }

                    if (needsToBeFiltered)
                    {
                        break;
                    }
                }

                if (!needsToBeFiltered)
                {
                    result.Add(gems[i]);
                }
            }

            return result;
        }

        private static bool LeftPredicate(List<int> gems, int filterNumber, int i)
        {
            return (i <= 0 ? 0 : gems[i - 1]) + gems[i] == filterNumber;
        }

        private static bool LeftRightPredicate(List<int> gems, int filterNumber, int i)
        {
            return (i <= 0 ? 0 : gems[i - 1]) + gems[i] + (i >= gems.Count - 1 ? 0 : gems[i + 1]) == filterNumber;
        }

        private static bool RightPredicate(List<int> gems, int filterNumber, int i)
        {
            return gems[i] + (i >= gems.Count - 1 ? 0 : gems[i + 1]) == filterNumber;
        }
    }
}