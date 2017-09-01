namespace _03.StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    internal class StartUp
    {
        private static void Main()
        {
            List<Student> students = new List<Student>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = inputArgs[0];
                string lastName = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                students.Add(student);
            }

            students
             .Where(student => student.Age >= 18 && student.Age <= 24)
             .ToList()
             .ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}"));
        }
    }
}