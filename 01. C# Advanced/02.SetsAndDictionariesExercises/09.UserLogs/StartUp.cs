namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> userAddressesCount = new SortedDictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string user = inputArgs[2].Substring(5);
                string address = new string(inputArgs[0].Skip(3).Take(inputArgs[0].Length).ToArray());

                if (!userAddressesCount.ContainsKey(user))
                {
                    userAddressesCount[user] = new Dictionary<string, int>();
                }

                if (!userAddressesCount[user].ContainsKey(address))
                {
                    userAddressesCount[user][address] = 0;
                }

                userAddressesCount[user][address]++;
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> pair in userAddressesCount)
            {
                Console.WriteLine($"{pair.Key}: ");

                int counter = 1;
                foreach (KeyValuePair<string, int> innerPair in pair.Value)
                {
                    Console.Write(counter == pair.Value.Count
                        ? $"{innerPair.Key} => {innerPair.Value}.\n"
                        : $"{innerPair.Key} => {innerPair.Value}, ");

                    counter++;
                }
            }
        }
    }
}