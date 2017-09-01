namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> hashSet = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                hashSet.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", hashSet));
        }
    }
}