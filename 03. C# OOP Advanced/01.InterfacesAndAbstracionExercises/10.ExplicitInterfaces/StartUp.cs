namespace _10.ExplicitInterfaces
{
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            IList<Citizen> society = new List<Citizen>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string country = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                Citizen citizen = new Citizen(name, country, age);
                society.Add(citizen);
            }

            foreach (Citizen citizen in society)
            {
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                //Console.WriteLine((citizen as IPerson).GetName());
                //Console.WriteLine((citizen as IResident).GetName());
            }
        }
    }
}