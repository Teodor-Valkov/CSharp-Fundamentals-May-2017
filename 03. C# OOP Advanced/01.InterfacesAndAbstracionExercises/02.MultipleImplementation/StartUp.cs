namespace _02.MultipleImplementation
{
    using Contracts;
    using Models;
    using System;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
            PropertyInfo[] identifiableProperties = identifiableInterface.GetProperties();
            Console.WriteLine(identifiableProperties.Length);
            Console.WriteLine(identifiableProperties[0].PropertyType.Name);

            Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
            PropertyInfo[] birthdayProperties = birthableInterface.GetProperties();
            Console.WriteLine(birthdayProperties.Length);
            Console.WriteLine(birthdayProperties[0].PropertyType.Name);

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
        }
    }
}