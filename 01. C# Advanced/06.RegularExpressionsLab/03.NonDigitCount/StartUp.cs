namespace _03.NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = @"[^\d]";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}