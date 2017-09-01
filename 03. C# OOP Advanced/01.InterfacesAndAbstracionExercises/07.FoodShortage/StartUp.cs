namespace _07.FoodShortage
{
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> society = new Dictionary<string, IBuyer>();

            for (int i = 0; i < number; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name;
                int age;
                string id;
                string birthday;
                string group;

                switch (inputArgs.Length)
                {
                    case 4:
                        name = inputArgs[0];
                        age = int.Parse(inputArgs[1]);
                        id = inputArgs[2];
                        birthday = inputArgs[3];

                        if (!society.ContainsKey(name))
                        {
                            Citizen citizen = new Citizen(name, age, id, birthday);
                            society[name] = citizen;
                        }
                        break;

                    case 3:
                        name = inputArgs[0];
                        age = int.Parse(inputArgs[1]);
                        group = inputArgs[2];

                        if (!society.ContainsKey(name))
                        {
                            Rebel rebel = new Rebel(name, age, group);
                            society[name] = rebel;
                        }
                        break;
                }
            }

            string nameToCheck = string.Empty;
            while ((nameToCheck = Console.ReadLine()) != "End")
            {
                if (society.ContainsKey(nameToCheck))
                {
                    society[nameToCheck].BuyFood();
                }
            }

            Console.WriteLine(society.Sum(s => s.Value.Food));
        }
    }
}