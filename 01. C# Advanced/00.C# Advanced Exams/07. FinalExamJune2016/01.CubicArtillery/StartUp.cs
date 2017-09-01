namespace _01.CubicArtillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            int leftCapacity = maxCapacity;

            Queue<string> bunkers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "bunker revision")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string arg in inputArgs)
                {
                    int weapon;
                    bool isDigit = int.TryParse(arg, out weapon);

                    if (!isDigit)
                    {
                        bunkers.Enqueue(arg);
                    }
                    else
                    {
                        bool isWeaponInBunker = false;

                        while (bunkers.Count > 1)
                        {
                            if (leftCapacity >= weapon)
                            {
                                weapons.Enqueue(weapon);
                                leftCapacity -= weapon;
                                isWeaponInBunker = true;
                                break;
                            }

                            Console.WriteLine(weapons.Any()
                                ? $"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}"
                                : $"{bunkers.Dequeue()} -> Empty");

                            weapons.Clear();
                            leftCapacity = maxCapacity;
                        }

                        if (!isWeaponInBunker)
                        {
                            if (weapon <= maxCapacity)
                            {
                                while (leftCapacity < weapon)
                                {
                                    leftCapacity += weapons.Dequeue();
                                }

                                weapons.Enqueue(weapon);
                                leftCapacity -= weapon;
                            }
                        }
                    }
                }
            }
        }
    }
}