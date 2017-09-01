namespace _06.MinerTask
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, long> resourceAndQuantity = new Dictionary<string, long>();

            string resource = string.Empty;
            while ((resource = Console.ReadLine()).ToLower() != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resourceAndQuantity.ContainsKey(resource))
                {
                    resourceAndQuantity[resource] = 0;
                }

                resourceAndQuantity[resource] += quantity;
            }

            foreach (KeyValuePair<string, long> pair in resourceAndQuantity)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}