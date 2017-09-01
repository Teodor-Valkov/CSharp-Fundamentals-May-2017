namespace _06.CountSubstringOccurrences
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();

            int counter = 0;
            int index = text.IndexOf(word);

            while (index != -1)
            {
                counter++;
                index = text.IndexOf(word, index + 1);
            }

            Console.WriteLine(counter);
        }
    }
}