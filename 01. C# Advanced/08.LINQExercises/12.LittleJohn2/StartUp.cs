namespace _12.LittleJohn2
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            int count = 4;

            int small = 0;
            int medium = 0;
            int large = 0;

            string pattern = "(?:(>----->)|(>>----->)|(>>>----->>))";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    small += match.Groups[1].Captures.Count;

                    medium += match.Groups[2].Captures.Count;

                    large += match.Groups[3].Captures.Count;
                }
            }

            string numberAsString = small.ToString() + medium + large;
            long numberAsDecimal = long.Parse(numberAsString);

            string numberAsBinary = Convert.ToString(numberAsDecimal, 2);
            numberAsBinary += string.Join("", numberAsBinary.Reverse());

            long resultAsDecimal = Convert.ToInt64(numberAsBinary, 2);

            Console.WriteLine(resultAsDecimal);
        }
    }
}