namespace _08.ExtractHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class ExtractHyperlinks
    {
        private static void Main()
        {
            StringBuilder sb = new StringBuilder();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                sb.Append(input);
            }

            string text = sb.ToString();

            string pattern = @"<a\s+(?:[^>]+)?href\s*=\s*(?:'([^']+)'|""([^""]+)""|([^\s>]+))[^>]*>";
            //string pattern = @"<a[^>]+href\s*=\s*(?:'([^']+)'|""([^""]+)""|([^\s>]+))[^>]*>";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (match.Groups[i].Length > 0)
                    {
                        Console.WriteLine(match.Groups[i].Value);
                    }
                }
            }
        }
    }
}