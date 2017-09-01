namespace _02.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    internal class MatchPhoneNumber
    {
        private static void Main()
        {
            string pattern = @"^\+359(\s|\-)2\1\d{3}\1\d{4}$";
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