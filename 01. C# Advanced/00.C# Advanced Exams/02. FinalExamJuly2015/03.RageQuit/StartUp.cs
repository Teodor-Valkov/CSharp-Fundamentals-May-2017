namespace _03.RageQuit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine().ToUpper();

            StringBuilder sb = new StringBuilder();
            int uniqueSymbolsCount = 0;

            string pattern = @"(\D+)(\d+)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                string word = match.Groups[1].Value;
                int number = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < number; i++)
                {
                    sb.Append(word);
                }
            }

            uniqueSymbolsCount = sb.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
            Console.WriteLine($"{sb}");
        }
    }
}