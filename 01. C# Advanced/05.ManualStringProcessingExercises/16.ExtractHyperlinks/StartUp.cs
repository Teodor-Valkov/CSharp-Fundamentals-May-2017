namespace _16.ExtractHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
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
                    if (!string.IsNullOrEmpty(match.Groups[i].Value))
                    {
                        Console.WriteLine(match.Groups[i]);
                    }
                }
            }
        }
    }
}