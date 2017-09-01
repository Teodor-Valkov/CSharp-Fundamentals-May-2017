namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "search")
            {
                string[] inputArgs = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string phone = inputArgs[1];

                phonebook[name] = phone;
            }

            string currentName = string.Empty;
            while ((currentName = Console.ReadLine()).ToLower() != "stop")
            {
                Console.WriteLine(phonebook.ContainsKey(currentName)
                    ? $"{currentName} -> {phonebook[currentName]}"
                    : $"Contact {currentName} does not exist.");
            }
        }
    }
}