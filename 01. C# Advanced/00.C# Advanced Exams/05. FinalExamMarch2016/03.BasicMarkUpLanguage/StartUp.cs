namespace _03.BasicMarkUpLanguage
{
    using System;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string pattern = "<\\s*(inverse|reverse)\\s*content\\s*=\\s*\"([^\"]+)\"\\s*\\/>";
            string repeatPattern = "<\\s*repeat\\s*value\\s*=\\s*\"([0-9]+)\"\\s*content\\s*=\\s*\"([^\"]+)\"\\s*\\/>";

            Regex regex = new Regex(pattern);
            Regex repeatRegex = new Regex(repeatPattern);

            int counter = 1;
            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "<stop/>")
            {
                Match match = regex.Match(input);
                Match repeatMatch = repeatRegex.Match(input);

                if (match.Success)
                {
                    if (match.Groups[1].Value == "reverse")
                    {
                        string content = ReverseContent(match.Groups[2].Value);
                        Console.WriteLine($"{counter++}. {content}");
                    }
                    else if (match.Groups[1].Value == "inverse")
                    {
                        string content = InverseContent(match.Groups[2].Value);
                        Console.WriteLine($"{counter++}. {content}");
                    }
                }
                else if (repeatMatch.Success)
                {
                    int repetitions = int.Parse(repeatMatch.Groups[1].Value);
                    string content = repeatMatch.Groups[2].Value;

                    if (string.IsNullOrEmpty(content))
                    {
                        continue;
                    }

                    for (int i = 0; i < repetitions; i++)
                    {
                        Console.WriteLine($"{counter++}. {content}");
                    }
                }
            }
        }

        private static string ReverseContent(string content)
        {
            char[] reversedContent = content.ToCharArray();
            Array.Reverse(reversedContent);

            return new string(reversedContent);
        }

        private static string InverseContent(string content)
        {
            string inversedContent = string.Empty;

            foreach (char symbol in content)
            {
                if (char.IsLower(symbol))
                {
                    inversedContent += symbol.ToString().ToUpper();
                }
                else if (char.IsUpper(symbol))
                {
                    inversedContent += symbol.ToString().ToLower();
                }
                else
                {
                    inversedContent += symbol;
                }
            }

            return inversedContent;
        }
    }
}