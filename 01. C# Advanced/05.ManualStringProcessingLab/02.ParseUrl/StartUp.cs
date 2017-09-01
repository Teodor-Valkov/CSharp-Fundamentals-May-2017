namespace _02.ParseUrl
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            string[] inputArgs = input.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if (inputArgs.Length != 2 || inputArgs[1].IndexOf("/") == -1)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                int serverEndIndex = inputArgs[1].IndexOf("/");

                string protocol = inputArgs[0];
                string server = inputArgs[1].Substring(0, serverEndIndex);
                string resources = inputArgs[1].Substring(serverEndIndex + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}