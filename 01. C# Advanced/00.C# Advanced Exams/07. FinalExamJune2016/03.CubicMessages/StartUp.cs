namespace _03.CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            List<string> result = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "over!")
            {
                int number = int.Parse(Console.ReadLine());

                string pattern = $@"^(\d+)([a-zA-Z]{{{number}}})([^a-zA-Z]*)$";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string indexesAsString = match.Groups[1].Value;
                    string message = match.Groups[2].Value;

                    foreach (char symbol in match.Groups[3].Value)
                    {
                        if (char.IsDigit(symbol))
                        {
                            indexesAsString += symbol;
                        }
                    }

                    StringBuilder sb = new StringBuilder();

                    foreach (char indexAsString in indexesAsString)
                    {
                        int index = int.Parse(indexAsString.ToString());

                        if (index >= message.Length)
                        {
                            sb.Append(" ");
                        }
                        else
                        {
                            sb.Append(message[index]);
                        }
                    }

                    result.Add($"{message} == {sb}");
                }
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}