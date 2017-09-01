namespace _08.ExtractQuotations2
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = @"(?:'([^']+)'|""([^""]+)"")";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                if (match.Groups[1].Success)
                {
                    Console.WriteLine(match.Groups[1].Value);
                }
                else if (match.Groups[2].Success)
                {
                    Console.WriteLine(match.Groups[2].Value);
                }
            }
        }
    }
}