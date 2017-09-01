namespace _01.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    internal class MatchFullNames
    {
        private static void Main()
        {
            //string pattern = @"\b[A-Z][a-z]+\s[A-Z][a-z]+\b";
            string pattern = @"^[A-Z][a-z]+\s[A-Z][a-z]+$";
            Regex regex = new Regex(pattern);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}