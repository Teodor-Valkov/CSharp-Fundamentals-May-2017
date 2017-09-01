namespace _03.CubicMessages2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            List<string> result = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "over!")
            {
                int number = int.Parse(Console.ReadLine());

                List<char> firstGroupDigits = new List<char>();
                List<char> secondGroupDigits = new List<char>();

                string message = GetDigitGroupsAndMessage(input, number, firstGroupDigits, secondGroupDigits);

                bool isMessageValid = CheckIfGroupsAndMessageAreValid(firstGroupDigits, secondGroupDigits, message);

                if (isMessageValid)
                {
                    StringBuilder sb = new StringBuilder();
                    List<int> verificationIndexes = new List<int>();

                    foreach (char symbol in firstGroupDigits)
                    {
                        if (char.IsDigit(symbol))
                        {
                            verificationIndexes.Add(int.Parse(symbol.ToString()));
                        }
                    }

                    foreach (char symbol in secondGroupDigits)
                    {
                        if (char.IsDigit(symbol))
                        {
                            verificationIndexes.Add(int.Parse(symbol.ToString()));
                        }
                    }

                    foreach (int index in verificationIndexes)
                    {
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

        private static string GetDigitGroupsAndMessage(string input, int number, List<char> firstGroupDigits, List<char> secondGroupDigits)
        {
            StringBuilder message = new StringBuilder();

            foreach (char symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    firstGroupDigits.Add(symbol);
                }
                else
                {
                    break;
                }
            }

            for (int i = firstGroupDigits.Count; i < firstGroupDigits.Count + number; i++)
            {
                message.Append(input[i]);
            }

            for (int i = firstGroupDigits.Count + number; i < input.Length; i++)
            {
                secondGroupDigits.Add(input[i]);
            }

            return message.ToString();
        }

        private static bool CheckIfGroupsAndMessageAreValid(List<char> firstGroupDigits, List<char> secondGroupDigits, string message)
        {
            foreach (char symbol in firstGroupDigits)
            {
                if (char.IsDigit(symbol))
                {
                    continue;
                }

                return false;
            }

            foreach (char symbol in message)
            {
                if (char.IsLetter(symbol))
                {
                    continue;
                }

                return false;
            }

            foreach (char symbol in secondGroupDigits)
            {
                if (!char.IsLetter(symbol))
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}