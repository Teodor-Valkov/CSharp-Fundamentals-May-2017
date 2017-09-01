namespace _02.VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = "[AEIOUYaeiouy]";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}