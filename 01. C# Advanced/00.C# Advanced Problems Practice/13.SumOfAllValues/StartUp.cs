namespace _13.SumOfAllValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string keyInput = Console.ReadLine();
            string textInput = Console.ReadLine();

            string keyPattern = @"^([A-Za-z_]+)[\d].*[\d]([A-Za-z_]+)$";
            Regex keyRegex = new Regex(keyPattern);

            List<double> numbers = new List<double>();

            Match keyMatch = keyRegex.Match(keyInput);

            if (!keyMatch.Success)
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }

            string startKey = keyMatch.Groups[1].Value;
            string endKey = keyMatch.Groups[2].Value;

            string textPattern = $@"{startKey}(.+?){endKey}";
            Regex textRegex = new Regex(textPattern);

            double number = 0;
            bool isNumberValid = false;

            MatchCollection textMathes = textRegex.Matches(textInput);
            foreach (Match match in textMathes)
            {
                isNumberValid = double.TryParse(match.Groups[1].Value, out number);
                if (isNumberValid)
                {
                    numbers.Add(number);
                }
            }

            Console.WriteLine(numbers.Any()
                ? $"<p>The total value is: <em>{numbers.Sum()}</em></p>"
                : "<p>The total value is: <em>nothing</em></p>");
        }
    }
}