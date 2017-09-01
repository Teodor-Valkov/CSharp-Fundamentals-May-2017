namespace _09.TextFilter
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string[] forbiddenWords = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (string forbiddenWord in forbiddenWords)
            {
                if (text.Contains(forbiddenWord))
                {
                    text = text.Replace(forbiddenWord, new string('*', forbiddenWord.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}