namespace _05.ExtractTags
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            //string pattern = "(<[^>]+>)";
            string pattern = "(<.+?>)";
            Regex regex = new Regex(pattern);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine($"{match.Value}");
                }
            }
        }
    }
}