namespace _05.BorderControl
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
            List<IIdentifiable> society = new List<IIdentifiable>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name;
                string model;
                int age;
                string id;

                switch (inputArgs.Length)
                {
                    case 3:
                        name = inputArgs[0];
                        age = int.Parse(inputArgs[1]);
                        id = inputArgs[2];

                        Citizen citizen = new Citizen(name, age, id);
                        society.Add(citizen);
                        break;

                    case 2:
                        model = inputArgs[0];
                        id = inputArgs[1];

                        Robot robot = new Robot(model, id);
                        society.Add(robot);
                        break;
                }
            }

            string fakeId = Console.ReadLine();
            foreach (IIdentifiable subject in society.Where(s => s.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(subject.Id);
            }
        }
    }
}