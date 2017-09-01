namespace _01.JedyMeditation
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padawans = new Queue<string>();
            Queue<string> players = new Queue<string>();

            bool hasYoda = false;

            for (int i = 0; i < number; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string arg in inputArgs)
                {
                    string currentJedy = arg.ToLower();

                    if (currentJedy.StartsWith("m"))
                    {
                        masters.Enqueue(currentJedy);
                    }
                    else if (currentJedy.StartsWith("k"))
                    {
                        knights.Enqueue(currentJedy);
                    }
                    else if (currentJedy.StartsWith("p"))
                    {
                        padawans.Enqueue(currentJedy);
                    }
                    else if (currentJedy.StartsWith("t"))
                    {
                        players.Enqueue(currentJedy);
                    }
                    else if (currentJedy.StartsWith("s"))
                    {
                        players.Enqueue(currentJedy);
                    }
                    else if (currentJedy.StartsWith("y"))
                    {
                        hasYoda = true;
                    }
                }
            }

            Console.WriteLine(hasYoda
                ? $"{string.Join(" ", masters)} {string.Join(" ", knights)} {string.Join(" ", players)} {string.Join(" ", padawans)}"
                : $"{string.Join(" ", players)} {string.Join(" ", masters)} {string.Join(" ", knights)} {string.Join(" ", padawans)}");
        }
    }
}