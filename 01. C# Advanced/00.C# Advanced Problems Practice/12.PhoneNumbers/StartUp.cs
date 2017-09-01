namespace _12.PhoneNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = @"([A-Z][A-Za-z]*)(?:[^A-Za-z\d\+]*)(\+?[\d][\d\(\)\/\.\-\s]*[\d])";
            Regex regex = new Regex(pattern);

            StringBuilder sb = new StringBuilder();
            List<string> result = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                sb.Append(input);
            }

            MatchCollection matches = regex.Matches(sb.ToString());

            foreach (Match match in matches)
            {
                string name = match.Groups[1].Value;
                string phone = GetOnlyDigits(match.Groups[2].Value);

                result.Add($"<li><b>{name}:</b> {phone}</li>");
            }

            Console.WriteLine(result.Any()
                ? $"<ol>{string.Join("", result)}</ol>"
                : "<p>No matches!</p>");
        }

        private static string GetOnlyDigits(string phone)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char symbol in phone)
            {
                if (char.IsDigit(symbol) || symbol == '+')
                {
                    sb.Append(symbol);
                }
            }

            return sb.ToString();
        }
    }
}