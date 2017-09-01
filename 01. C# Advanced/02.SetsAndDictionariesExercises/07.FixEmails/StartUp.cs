namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, string> nameAndEmail = new Dictionary<string, string>();

            string name = string.Empty;
            while ((name = Console.ReadLine()).ToLower() != "stop")
            {
                string email = Console.ReadLine();

                string emailDomain = new string(email.Skip(email.Length - 2).ToArray());

                if (emailDomain == "us" || emailDomain == "uk")
                {
                    continue;
                }

                nameAndEmail[name] = email;
            }

            foreach (KeyValuePair<string, string> pair in nameAndEmail)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}