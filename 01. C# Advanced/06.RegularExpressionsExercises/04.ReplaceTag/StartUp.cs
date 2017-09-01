namespace _04.ReplaceTag
{
    using System;
    using System.Text.RegularExpressions;

    internal class ReplaceTag
    {
        private static void Main()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                Regex regex = new Regex(pattern);

                //string replace = @"[URL href=$1]$2[/URL]";
                //string replaced = regex.Replace(input, replace);

                string replaced = regex.Replace(input, rgx => $@"[URL href={rgx.Groups[1]}]{rgx.Groups[2]}[/URL]");
                Console.WriteLine(replaced);
            }
        }
    }
}