namespace _03.ShmoogleCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            StringBuilder text = new StringBuilder();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "//end_of_code")
            {
                text.Append(input);
            }

            List<string> doubles = new List<string>();
            List<string> ints = new List<string>();

            string pattern = "(double|int)\\s([a-z][a-zA-Z]*)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text.ToString());
            foreach (Match match in matches)
            {
                string type = match.Groups[1].Value;
                string name = match.Groups[2].Value;

                if (type == "double")
                {
                    doubles.Add(name);
                }
                else if (type == "int")
                {
                    ints.Add(name);
                }
            }

            Console.WriteLine(doubles.Count > 0
                ? $"Doubles: {string.Join(", ", doubles.OrderBy(item => item))}"
                : "Doubles: None");

            Console.WriteLine(ints.Count > 0
                ? $"Ints: {string.Join(", ", ints.OrderBy(item => item))}"
                : "Ints: None");
        }
    }
}