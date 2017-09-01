namespace _06.SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    internal class SentenceExtractor
    {
        private static void Main()
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();

            // Without method for extracting valid sentences - pattern for validation
            // $@"([A-Za-z0-9\s]+\b{word}\b\s*.*?[.!?])"

            // With method for extracting valid sentences
            MatchCollection matches = ExtractValidSentences(input);

            foreach (Match match in matches)
            {
                string sentence = match.Value;
                Regex regex = new Regex($@"\b{word}\b");

                if (regex.IsMatch(sentence))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }

        private static MatchCollection ExtractValidSentences(string input)
        {
            string pattern = @"([^.!?]+[.!?])";
            Regex regex = new Regex(pattern);

            return regex.Matches(input);
        }
    }
}