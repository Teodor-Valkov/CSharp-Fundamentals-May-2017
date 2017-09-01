namespace _13.SrubskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, double>> venueSingersMoney = new Dictionary<string, Dictionary<string, double>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string pattern = "(.+)\\s@(.+)\\s(\\d+)\\s(\\d+)";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);
                if (!match.Success)
                {
                    continue;
                }

                string singer = match.Groups[1].Value;
                string venue = match.Groups[2].Value;
                double ticketPrice = int.Parse(match.Groups[3].Value);
                double ticketCount = int.Parse(match.Groups[4].Value);

                if (!venueSingersMoney.ContainsKey(venue))
                {
                    venueSingersMoney[venue] = new Dictionary<string, double>();
                }

                if (!venueSingersMoney[venue].ContainsKey(singer))
                {
                    venueSingersMoney[venue][singer] = 0;
                }

                venueSingersMoney[venue][singer] += ticketPrice * ticketCount;
            }

            foreach (KeyValuePair<string, Dictionary<string, double>> pair in venueSingersMoney)
            {
                Console.WriteLine(pair.Key);

                foreach (KeyValuePair<string, double> innePair in pair.Value.OrderByDescending(innerPair => innerPair.Value))
                {
                    Console.WriteLine($"#  {innePair.Key} -> {innePair.Value}");
                }
            }
        }
    }
}