namespace _11.Palindromes
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            SortedSet<string> palindromes = new SortedSet<string>();

            foreach (string word in words)
            {
                bool isPalinrome = FindIfWordIsPalindrome(word);

                if (isPalinrome)
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ", palindromes)}]");
        }

        private static bool FindIfWordIsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] == word[word.Length - i - 1])
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}