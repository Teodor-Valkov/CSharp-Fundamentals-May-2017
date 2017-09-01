namespace _04.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            SortedDictionary<string, double[]> school = new SortedDictionary<string, double[]>();

            for (int i = 0; i < number; i++)
            {
                string student = Console.ReadLine();
                double[] grades = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                school[student] = grades;
            }

            foreach (KeyValuePair<string, double[]> pair in school)
            {
                Console.WriteLine($"{pair.Key} is graduated with {pair.Value.Average()}");
            }
        }
    }
}