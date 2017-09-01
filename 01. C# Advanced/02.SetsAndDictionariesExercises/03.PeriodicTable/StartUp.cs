namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            SortedSet<string> sortedSet = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string arg in inputArgs)
                {
                    sortedSet.Add(arg);
                }
            }

            Console.WriteLine(string.Join(" ", sortedSet));
        }
    }
}