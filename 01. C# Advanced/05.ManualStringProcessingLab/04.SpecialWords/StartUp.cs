namespace _04.SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] input = Console.ReadLine().Split(new[] { ' ', '-', '?', '!', ',', '[', ']', '(', ')', '<', '>' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordsAndCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordsAndCount[word] = input.Count(w => w == word);
            }

            foreach (KeyValuePair<string, int> pair in wordsAndCount)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}