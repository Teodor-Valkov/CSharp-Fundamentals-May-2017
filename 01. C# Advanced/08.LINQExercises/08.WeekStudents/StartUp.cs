namespace _08.WeekStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Marks { get; set; }
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
                List<int> marks = new List<int>();

                for (int i = 2; i < inputArgs.Length; i++)
                {
                    marks.Add(int.Parse(inputArgs[i]));
                }

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Marks = marks
                };

                students.Add(student);
            }

            students
             .Where(student => student.Marks.Count(mark => mark <= 3) >= 2)
             .ToList()
             .ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName}"));
        }
    }
}