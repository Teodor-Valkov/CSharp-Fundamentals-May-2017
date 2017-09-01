namespace _09.StudentsEnrolledIn2014And2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FacultyNumber { get; set; }
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
                string facultyNumber = inputArgs[0];
                List<int> marks = new List<int>();

                for (int i = 1; i < inputArgs.Length; i++)
                {
                    marks.Add(int.Parse(inputArgs[i]));
                }

                Student student = new Student
                {
                    FacultyNumber = facultyNumber,
                    Marks = marks
                };

                students.Add(student);
            }

            students
             .Where(student => student.FacultyNumber.EndsWith("14") || student.FacultyNumber.EndsWith("15"))
             .ToList()
             .ForEach(student => Console.WriteLine($"{string.Join(" ", student.Marks)}"));
        }
    }
}