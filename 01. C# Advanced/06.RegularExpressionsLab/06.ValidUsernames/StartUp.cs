namespace _06.ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            //string pattern = @"(?<!.)\b[\w-]{3,16}\b(?!.)";
            string pattern = @"^[\w-]{3,16}$";
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