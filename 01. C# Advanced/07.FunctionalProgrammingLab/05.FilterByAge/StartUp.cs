namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < number; i++)
            {
                string[] person = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string name = person[0];
                int age = int.Parse(person[1]);

                people[name] = age;
            }

            string ageConditionAsString = Console.ReadLine();
            int ageConditionAsNumber = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> funcCondition = GetCondition(ageConditionAsString, ageConditionAsNumber);
            Action<KeyValuePair<string, int>> printAction = GetDataForPrinting(format);

            foreach (KeyValuePair<string, int> person in people)
            {
                if (funcCondition(person.Value))
                {
                    printAction(person);
                }
            }
        }

        private static Func<int, bool> GetCondition(string condition, int age)
        {
            if (condition == "older")
            {
                return n => n >= age;
            }

            return n => n < age;
        }

        private static Action<KeyValuePair<string, int>> GetDataForPrinting(string format)
        {
            switch (format)
            {
                case "name age":
                    return n => Console.WriteLine($"{n.Key} - {n.Value}");

                case "name":
                    return n => Console.WriteLine($"{n.Key}");

                case "age":
                    return n => Console.WriteLine($"{n.Value}");

                default:
                    return null;
            }
        }
    }
}