namespace _03.ParseTags
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            string openingTag = "<upcase>";
            string closingTag = "</upcase>";

            int startIndex = input.IndexOf(openingTag);
            while (startIndex != -1)
            {
                int endIndex = input.IndexOf(closingTag);

                if (endIndex == -1)
                {
                    break;
                }

                string textToUpcase = input.Substring(startIndex, endIndex - startIndex + closingTag.Length);
                string textForReplace = textToUpcase.Replace(openingTag, string.Empty).Replace(closingTag, string.Empty).ToUpper();

                input = input.Replace(textToUpcase, textForReplace);

                startIndex = input.IndexOf(openingTag);
            }

            Console.WriteLine(input);
        }
    }
}