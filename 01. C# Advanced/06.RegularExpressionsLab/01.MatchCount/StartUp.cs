namespace _01.MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = Console.ReadLine();
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            Console.WriteLine($"{matches.Count}");
        }
    }
}