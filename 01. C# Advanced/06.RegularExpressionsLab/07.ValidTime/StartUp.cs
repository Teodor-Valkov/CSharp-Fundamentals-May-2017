namespace _07.ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = @"^(?:(0[0-9])|(1[0-1])):[0-5][0-9]:[0-5][0-9]\s[AP]M$";
            Regex regex = new Regex(pattern);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                Match match = regex.Match(input);

                Console.WriteLine(match.Success ? "valid" : "invalid");
            }
        }
    }
}