namespace _10.UnicodeCharacters
{
    using System;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            string convertedInput = ConvertToUnicode(input);

            Console.WriteLine(convertedInput);
        }

        private static string ConvertToUnicode(string input)
        {
            StringBuilder utf = new StringBuilder();

            foreach (char symbol in input)
            {
                utf.Append($"\\u{(int)symbol:X4}");
            }

            return utf.ToString().ToLower();
        }
    }
}