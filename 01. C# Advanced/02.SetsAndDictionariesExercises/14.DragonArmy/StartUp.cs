﻿namespace _14.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Dragon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, List<Dragon>> typeAndDragons = new Dictionary<string, List<Dragon>>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Dragon dragon = SetDragonStats(inputArgs);

                AddDragonToDictionary(typeAndDragons, dragon);
            }

            PrintResult(typeAndDragons);
        }

        private static Dragon SetDragonStats(string[] inputArgs)
        {
            string type = inputArgs[0];
            string name = inputArgs[1];
            int damage = 45;
            int health = 250;
            int armor = 10;

            if (inputArgs[2] != "null")
            {
                damage = int.Parse(inputArgs[2]);
            }
            if (inputArgs[3] != "null")
            {
                health = int.Parse(inputArgs[3]);
            }
            if (inputArgs[4] != "null")
            {
                armor = int.Parse(inputArgs[4]);
            }

            Dragon dragon = new Dragon
            {
                Type = type,
                Name = name,
                Damage = damage,
                Health = health,
                Armor = armor
            };

            return dragon;
        }

        private static void AddDragonToDictionary(Dictionary<string, List<Dragon>> typeAndDragons, Dragon dragon)
        {
            string type = dragon.Type;
            string name = dragon.Name;

            if (!typeAndDragons.ContainsKey(type))
            {
                typeAndDragons[type] = new List<Dragon>();
            }

            if (typeAndDragons[type].Any(dr => dr.Name == name))
            {
                typeAndDragons[type].RemoveAll(dr => dr.Name == name);
            }

            typeAndDragons[type].Add(dragon);
        }

        private static void PrintResult(Dictionary<string, List<Dragon>> typeAndDragons)
        {
            foreach (KeyValuePair<string, List<Dragon>> pair in typeAndDragons)
            {
                string type = pair.Key;
                double averageDamage = typeAndDragons[type].Average(all => all.Damage);
                double averageHealth = typeAndDragons[type].Average(all => all.Health);
                double averageArmor = typeAndDragons[type].Average(all => all.Armor);

                Console.WriteLine($"{type}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (Dragon dragon in pair.Value.OrderBy(dr => dr.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }
}