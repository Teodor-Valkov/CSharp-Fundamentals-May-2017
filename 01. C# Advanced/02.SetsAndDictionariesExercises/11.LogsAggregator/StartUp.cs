namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, long>> userAddressesDuration = new SortedDictionary<string, SortedDictionary<string, long>>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string address = inputArgs[0];
                string user = inputArgs[1];
                long duration = long.Parse(inputArgs[2]);

                if (!userAddressesDuration.ContainsKey(user))
                {
                    userAddressesDuration.Add(user, new SortedDictionary<string, long>());
                }

                if (!userAddressesDuration[user].ContainsKey(address))
                {
                    userAddressesDuration[user][address] = 0;
                }

                userAddressesDuration[user][address] += duration;
            }

            foreach (KeyValuePair<string, SortedDictionary<string, long>> pair in userAddressesDuration)
            {
                string user = pair.Key;
                long userDuration = pair.Value.Values.Sum();
                string[] userAddresses = pair.Value.Keys.ToArray();

                Console.WriteLine($"{user}: {userDuration} [{string.Join(", ", userAddresses)}]");
            }
        }
    }
}