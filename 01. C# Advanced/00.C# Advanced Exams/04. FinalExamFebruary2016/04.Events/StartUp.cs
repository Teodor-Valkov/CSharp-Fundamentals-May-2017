namespace _04.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static DateTime eventTime;

        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string pattern = @"^#([A-Za-z]+):\s*@([A-Za-z]+)\s*(\d+:\d+)$";
            Regex regex = new Regex(pattern);

            var events = new Dictionary<string, Dictionary<string, List<DateTime>>>();

            for (int i = 0; i < number; i++)
            {
                Match match = regex.Match(Console.ReadLine());
                if (!match.Success)
                {
                    continue;
                }

                string location = match.Groups[2].Value;
                string name = match.Groups[1].Value;
                string dateTime = match.Groups[3].Value;

                if (IsValidDateTime(dateTime))
                {
                    if (!events.ContainsKey(location))
                    {
                        events[location] = new Dictionary<string, List<DateTime>>();
                    }

                    if (!events[location].ContainsKey(name))
                    {
                        events[location][name] = new List<DateTime>();
                    }

                    events[location][name].Add(eventTime);
                }
            }

            string[] locations = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(location => location).ToArray();

            foreach (string location in locations)
            {
                if (!events.ContainsKey(location))
                {
                    continue;
                }

                int counter = 1;

                Console.WriteLine($"{location}:");
                foreach (KeyValuePair<string, List<DateTime>> pair in events[location].OrderBy(pair => pair.Key))
                {
                    List<string> times = pair.Value.OrderBy(time => time).Select(time => $"{time.Hour:00}:{time.Minute:00}").ToList();

                    Console.WriteLine($"{counter++}. {pair.Key} -> {string.Join(", ", times)}");
                }
            }
        }

        private static bool IsValidDateTime(string dateTime)
        {
            return DateTime.TryParse(dateTime, out eventTime);
        }
    }
}