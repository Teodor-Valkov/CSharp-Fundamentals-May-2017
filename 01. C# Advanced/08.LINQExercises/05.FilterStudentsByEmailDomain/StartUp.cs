namespace _05.FilterStudentsByEmailDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
                string email = inputArgs[2];

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                students.Add(student);
            }

            students
             .Where(student => student.Email.EndsWith("@gmail.com"))
             .ToList()
             .ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName}"));
        }
    }
}