using System.Text.RegularExpressions;

namespace _11.LittleJohn
{
    using System;
    using System.Linq;

    internal class LittleJohn
    {
        private static void Main()
        {
            int count = 4;

            int small = 0;
            int medium = 0;
            int large = 0;

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                string pattern = "(>{1,3})-----(>{1,2})";
                Regex regex = new Regex(pattern);

                MatchCollection matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    int tail = match.Groups[1].Value.Length;
                    int tip = match.Groups[2].Value.Length;

                    if (tail == 1 && tip == 1)
                    {
                        small++;
                    }

                    if (tail == 2 && tip == 2 || tail == 2 && tip == 1 || tail == 3 && tip == 1)
                    {
                        medium++;
                    }

                    if (tail == 3 && tip == 2)
                    {
                        large++;
                    }
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