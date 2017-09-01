namespace _14.LettersChangeNumbers2
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            decimal totalSum = 0;

            string pattern = @"(?:\s*)([A-Za-z])(\d+)([A-Za-z])(?:\s*)";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                decimal number = decimal.Parse(match.Groups[2].ToString());

                char firstLetter = Convert.ToChar(match.Groups[1].ToString());

                if (firstLetter >= 'A' && firstLetter <= 'Z')
                {
                    number /= firstLetter - 'A' + 1;
                }

                if (firstLetter >= 'a' && firstLetter <= 'z')
                {
                    number *= firstLetter - 'a' + 1;
                }

                char lastLetter = Convert.ToChar(match.Groups[3].ToString());

                if (lastLetter >= 'A' && lastLetter <= 'Z')
                {
                    number -= lastLetter - 'A' + 1;
                }

                if (lastLetter >= 'a' && lastLetter <= 'z')
                {
                    number += lastLetter - 'a' + 1;
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}