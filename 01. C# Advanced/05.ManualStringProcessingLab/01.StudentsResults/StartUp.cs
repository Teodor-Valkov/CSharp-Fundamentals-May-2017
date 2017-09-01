namespace _01.StudentsResults
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<string> result = new List<string> { $"{"Name",-10}|{"CAdv",7}|{"COOP",7}|{"AdvOOP",7}|{"Average",7}|" };

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(new[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                double firstGrade = double.Parse(inputArgs[1]);
                double secondGrade = double.Parse(inputArgs[2]);
                double thirdGrade = double.Parse(inputArgs[3]);

                double average = (firstGrade + secondGrade + thirdGrade) / 3;

                result.Add($"{name,-10}|{firstGrade,7:F2}|{secondGrade,7:F2}|{thirdGrade,7:F2}|{average,7:F4}|");
            }

            foreach (string line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}