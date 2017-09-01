namespace _02.SoftuniParty
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            SortedSet<string> guests = new SortedSet<string>();

            while (input.ToLower() != "party")
            {
                guests.Add(input);
                input = Console.ReadLine();
            }

            while (input.ToLower() != "end")
            {
                input = Console.ReadLine();
                guests.Remove(input);
            }

            Console.WriteLine(guests.Count);
            Console.WriteLine(string.Join("\n", guests));
        }
    }
}