namespace _03.NaturalMessagingService
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            List<string> words = new List<string>();

            StringBuilder sb = new StringBuilder();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "---nms send---")
            {
                sb.Append(input);
            }

            StringBuilder word = new StringBuilder();

            char previousLetter = '*';

            foreach (char currentLetter in sb.ToString())
            {
                if (char.ToLower(currentLetter) >= char.ToLower(previousLetter))
                {
                    word.Append(currentLetter);
                }

                if (char.ToLower(currentLetter) < char.ToLower(previousLetter))
                {
                    words.Add(word.ToString());

                    word.Clear();
                    word.Append(currentLetter);
                }

                previousLetter = currentLetter;
            }

            words.Add(word.ToString());

            string separator = Console.ReadLine();

            Console.WriteLine($"{string.Join(separator, words)}");
        }
    }
}