namespace _03.TextTransformer
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder result = new StringBuilder();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "burp")
            {
                sb.Append(input);
            }

            string text = Regex.Replace(sb.ToString(), "\\s+", " ");

            string pattern = "([$%&'])([^$%&']+)\\1";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                int count = 0;
                string decrypted = string.Empty;

                string symbol = match.Groups[1].Value;
                string encrypted = match.Groups[2].Value;

                switch (symbol)
                {
                    case "$": count = 1; break;
                    case "%": count = 2; break;
                    case "&": count = 3; break;
                    case "'": count = 4; break;
                }

                for (int i = 0; i < encrypted.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        decrypted += Convert.ToChar(encrypted[i] + count);
                    }
                    else
                    {
                        decrypted += Convert.ToChar(encrypted[i] - count);
                    }
                }

                result.Append(decrypted + " ");
            }

            Console.WriteLine(result);
        }
    }
}