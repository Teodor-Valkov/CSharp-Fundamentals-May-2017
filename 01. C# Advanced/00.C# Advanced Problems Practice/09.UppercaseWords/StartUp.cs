namespace _09.UppercaseWords
{
    using System;
    using System.Security;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = "(?<![a-zA-Z])([A-Z]+)(?![A-Za-z])";
            Regex regex = new Regex(pattern);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                MatchCollection matches = regex.Matches(input);
                int offset = 0;

                foreach (Match match in matches)
                {
                    string word = match.Value;
                    string reversedWord = ReverseWord(word);
                    //string reversedWord = new string(word.Reverse().ToArray());

                    if (word == reversedWord)
                    {
                        reversedWord = DoubleWordLetters(reversedWord);
                    }

                    int index = match.Index;
                    input = input.Remove(index + offset, word.Length);
                    input = input.Insert(index + offset, reversedWord);
                    offset += reversedWord.Length - word.Length;
                }

                Console.WriteLine(SecurityElement.Escape(input));
            }
        }

        private static string ReverseWord(string word)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = word.Length - 1; i >= 0; i--)
            {
                sb.Append(word[i]);
            }

            return sb.ToString();
        }

        private static string DoubleWordLetters(string word)
        {
            StringBuilder doubledWord = new StringBuilder();

            foreach (char letter in word)
            {
                doubledWord.Append(string.Concat(letter, letter));
            }

            return doubledWord.ToString();
        }
    }
}