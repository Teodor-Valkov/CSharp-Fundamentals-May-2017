namespace _04.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
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

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                students.Add(student);
            }

            students
             .OrderBy(student => student.LastName)
             .ThenByDescending(student => student.FirstName)
             .ToList().ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName}"));
        }
    }
}