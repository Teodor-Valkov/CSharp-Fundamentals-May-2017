namespace _03.SoftuniNumerals2
{
    using System;
    using System.Numerics;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            int baseNumber = 5;

            string base5NumberAsString = ConvertStringToBase5(input);

            BigInteger base10Number = ConvertBase5toBase10(base5NumberAsString, baseNumber);

            Console.WriteLine(base10Number);
        }

        private static string ConvertStringToBase5(string input)
        {
            string[] codes = { "aa", "aba", "bcc", "cc", "cdc" };

            string numberAsString = string.Empty;

            while (input.Length > 0)
            {
                for (int i = 0; i < codes.Length; i++)
                {
                    string code = codes[i];

                    if (input.StartsWith(code))
                    {
                        numberAsString += i;
                        input = input.Substring(code.Length);
                        break;
                    }
                }
            }

            return numberAsString;
        }

        private static BigInteger ConvertBase5toBase10(string base5string, int baseNumber)
        {
            BigInteger number = 0;

            for (int i = 0; i < base5string.Length; i++)
            {
                BigInteger nextDigit = base5string[base5string.Length - 1 - i] - '0';
                number += nextDigit * BigInteger.Pow(baseNumber, i);
            }

            return number;
        }
    }
}