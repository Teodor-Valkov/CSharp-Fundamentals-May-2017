namespace _15.TheNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            string pattern = "(\\d+)";
            Regex regex = new Regex(pattern);

            List<string> result = new List<string>();

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                int number = int.Parse(match.Value);
                string hex = number.ToString("X").PadLeft(4, '0').ToUpper();

                result.Add($"0x{hex}");
            }

            Console.WriteLine(string.Join("-", result));
        }
    }
}