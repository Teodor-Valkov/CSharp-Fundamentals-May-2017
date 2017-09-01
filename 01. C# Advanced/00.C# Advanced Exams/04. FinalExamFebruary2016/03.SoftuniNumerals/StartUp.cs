namespace _03.SoftuniNumerals
{
    using System;
    using System.Numerics;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            int baseNumber = 5;
            string base5NumberAsString = string.Empty;

            string pattern = "(aa|aba|bcc|cc|cdc)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "aa": base5NumberAsString += 0; break;
                    case "aba": base5NumberAsString += 1; break;
                    case "bcc": base5NumberAsString += 2; break;
                    case "cc": base5NumberAsString += 3; break;
                    case "cdc": base5NumberAsString += 4; break;
                }
            }

            BigInteger base10Number = ToDecimalBase(base5NumberAsString, baseNumber);

            Console.WriteLine(base10Number);
        }

        private static BigInteger ToDecimalBase(string numberAsBaseFiveString, int baseNumber)
        {
            BigInteger number = 0;

            for (int i = 0; i < numberAsBaseFiveString.Length; i++)
            {
                BigInteger nextDigit = numberAsBaseFiveString[numberAsBaseFiveString.Length - 1 - i] - '0';
                number += nextDigit * BigInteger.Pow(baseNumber, i);
            }

            return number;
        }
    }
}