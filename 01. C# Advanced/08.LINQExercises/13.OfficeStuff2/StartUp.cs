namespace _13.OfficeStuff2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            SortedDictionary<string, Dictionary<string, int>> companies = new SortedDictionary<string, Dictionary<string, int>>();

            string pattern = @"(\w+)\s\-\s(\d+)\s\-\s(\w+)";
            Regex regex = new Regex(pattern);

            string input = string.Empty;
            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine();
                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string companyName = match.Groups[1].Value;
                int quantity = int.Parse(match.Groups[2].Value);
                string productName = match.Groups[3].Value;

                if (!companies.ContainsKey(companyName))
                {
                    companies[companyName] = new Dictionary<string, int>();
                }

                if (!companies[companyName].ContainsKey(productName))
                {
                    companies[companyName][productName] = 0;
                }

                companies[companyName][productName] += quantity;
            }

            companies
             .ToList()
             .ForEach(company =>
               Console.WriteLine($"{company.Key}: {string.Join(", ", company.Value.Select(product => $"{product.Key}-{product.Value}"))}"));
        }
    }
}