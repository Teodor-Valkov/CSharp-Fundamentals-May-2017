namespace _06.BirthdayCelebration
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
            List<IBirthable> society = new List<IBirthable>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = inputArgs[0];
                string name;
                int age;
                string id;
                string birthday;

                switch (type)
                {
                    case "Citizen":
                        name = inputArgs[1];
                        age = int.Parse(inputArgs[2]);
                        id = inputArgs[3];
                        birthday = inputArgs[4];

                        Citizen citizen = new Citizen(name, age, id, birthday);
                        society.Add(citizen);
                        break;

                    case "Pet":
                        name = inputArgs[1];
                        birthday = inputArgs[2];

                        Pet pet = new Pet(name, birthday);
                        society.Add(pet);
                        break;
                }
            }

            string year = Console.ReadLine();
            foreach (IBirthable subject in society.Where(s => s.Birthday.EndsWith(year)))
            {
                Console.WriteLine(subject.Birthday);
            }
        }
    }
}