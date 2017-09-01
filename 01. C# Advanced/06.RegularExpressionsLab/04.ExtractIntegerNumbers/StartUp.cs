namespace _04.ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = @"[\d]+";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine($"{match.Value}");
            }
        }
    }
}