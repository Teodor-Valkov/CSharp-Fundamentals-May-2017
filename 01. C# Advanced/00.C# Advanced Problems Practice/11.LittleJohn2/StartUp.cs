namespace _11.LittleJohn2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class LittleJohn
    {
        private static void Main()
        {
            List<string> input = new List<string> { Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };

            string[] arrows = { ">>>----->>", ">>----->", ">----->" };

            Dictionary<string, int> arrowCounter = new Dictionary<string, int> { { arrows[0], 0 }, { arrows[1], 0 }, { arrows[2], 0 } };

            foreach (string line in input)
            {
                string currentLine = line;

                foreach (string arrow in arrows)
                {
                    while (ReplaceFirst(ref currentLine, arrow, "Some Text"))
                    {
                        arrowCounter[arrow]++;
                    }
                }
            }

            int number = arrowCounter[arrows[0]] + arrowCounter[arrows[1]] * 10 + arrowCounter[arrows[2]] * 100;

            string binary = Convert.ToString(number, 2);
            binary = binary + string.Join("", binary.Reverse());

            Console.WriteLine(Convert.ToInt32(binary, 2));
        }

        private static bool ReplaceFirst(ref string text, string search, string replace)
        {
            int index = text.IndexOf(search);

            if (index < 0)
            {
                return false;
            }

            text = $"{text.Substring(0, index)}{replace}{text.Substring(index + search.Length)}";

            return true;
        }
    }
}