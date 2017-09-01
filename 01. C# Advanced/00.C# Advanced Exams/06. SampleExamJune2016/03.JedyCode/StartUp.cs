namespace _03.JedyCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            StringBuilder inputStringBuilder = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                inputStringBuilder.Append(Console.ReadLine());
            }

            string patternName = Console.ReadLine();
            string patternMessage = Console.ReadLine();

            int[] indexes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<string> names = new List<string>();
            List<string> messages = new List<string>();

            Regex regexNames = new Regex($"{patternName}([a-zA-Z]{{{patternName.Length}}})(?![a-zA-Z])");
            MatchCollection matchesNames = regexNames.Matches(inputStringBuilder.ToString());

            foreach (Match match in matchesNames)
            {
                names.Add(match.Groups[1].Value);
            }

            Regex regexMessages = new Regex($"{patternMessage}([a-zA-Z0-9]{{{patternMessage.Length}}})(?![a-zA-Z0-9])");
            MatchCollection matchedMessages = regexMessages.Matches(inputStringBuilder.ToString());
            foreach (Match match in matchedMessages)
            {
                messages.Add(match.Groups[1].Value);
            }

            int currentNameIndex = 0;
            List<string> result = new List<string>();

            foreach (int index in indexes)
            {
                if (index - 1 < messages.Count)
                {
                    result.Add($"{names[currentNameIndex]} - {messages[index - 1]}");
                }

                currentNameIndex++;

                if (currentNameIndex >= names.Count)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}