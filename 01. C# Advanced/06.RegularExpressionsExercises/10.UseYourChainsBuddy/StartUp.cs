namespace _10.UseYourChainsBuddy
{
    using System;
    using System.Text.RegularExpressions;

    internal class UseYourChainsBuddy
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            // First pattern gets all the <p> tags in diffrent matches using the exclusion in the matches of "/"
            // Second pattern gets all the <p> tags in different matches using the lazy quantifier "?"

            //string pattern = @"<p>(.[^\/]+)<\/p>";
            string pattern = @"<p>(.+?)<\/p>";
            Regex regex = new Regex(pattern);

            string symbolsToSpace = @"[^a-z0-9]+";
            string encrypted = string.Empty;

            MatchCollection matches = regex.Matches(input);
            //for (int i = 0; i < matches.Count; i++)
            //{
            //    string text = matches[i].Groups[1].Value;
            //    encrypted += Regex.Replace(text, symbolsToSpace, " ");
            //}

            foreach (Match match in matches)
            {
                string text = match.Groups[1].Value;
                encrypted += Regex.Replace(text, symbolsToSpace, " ");
            }

            string result = string.Empty;

            foreach (char symbol in encrypted)
            {
                if (symbol >= 'a' && symbol <= 'm')
                {
                    result += (char)(symbol + 13);
                }
                else if (symbol >= 'n' && symbol <= 'z')
                {
                    result += (char)(symbol - 13);
                }
                else if (char.IsDigit(symbol) || char.IsWhiteSpace(symbol))
                {
                    result += symbol;
                }
            }

            Console.WriteLine(result);
        }
    }
}