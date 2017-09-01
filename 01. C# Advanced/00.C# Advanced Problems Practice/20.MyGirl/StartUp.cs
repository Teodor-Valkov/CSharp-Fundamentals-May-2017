namespace _20.MyGirl
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static char[] specialSymbols = { '*', '+', '?', '[', ']', '{', '}', ',', '.', '^', '$', '<', '>', '\\', '/', '(', ')', '"' };

        private static void Main()
        {
            string key = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            string line = string.Empty;
            while ((line = Console.ReadLine()).ToLower() != "end")
            {
                sb.Append(line);
            }

            string input = sb.ToString();

            string pattern = ExtractKeyPattern(key, specialSymbols);
            Console.WriteLine(pattern);

            StringBuilder address = ExtractAddress(pattern, input);

            Console.WriteLine(address);
        }

        private static string ExtractKeyPattern(string key, char[] specialSymbols)
        {
            StringBuilder keyPattern = new StringBuilder();

            if (specialSymbols.Contains(key[0]))
            {
                keyPattern.Append($"\\{key[0]}");
            }
            else
            {
                keyPattern.Append(key[0]);
            }

            for (int i = 1; i < key.Length - 1; i++)
            {
                char symbol = key[i];

                if (char.IsUpper(symbol))
                {
                    keyPattern.Append("[A-Z]*");
                }
                else if (char.IsLower(symbol))
                {
                    keyPattern.Append("[a-z]*");
                }
                else if (char.IsDigit(symbol))
                {
                    keyPattern.Append("\\d*");
                }
                else if (specialSymbols.Contains(symbol))
                {
                    keyPattern.Append($"\\{symbol}");
                }
                else
                {
                    keyPattern.Append(symbol);
                }
            }

            if (specialSymbols.Contains(key[key.Length - 1]))
            {
                keyPattern.Append($"\\{key[key.Length - 1]}");
            }
            else
            {
                keyPattern.Append(key[key.Length - 1]);
            }

            var keyPatternStr = keyPattern.ToString();
            var pattern = $"{keyPatternStr}(.{{2,6}}){keyPatternStr}";
            return pattern;
        }

        private static StringBuilder ExtractAddress(string pattern, string text)
        {
            Regex addressPiece = new Regex(pattern);
            MatchCollection matches = addressPiece.Matches(text);

            StringBuilder address = new StringBuilder();

            foreach (Match match in matches)
            {
                address.Append(match.Groups[1].Value);
            }

            return address;
        }
    }
}