namespace _11.StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Specialty
    {
        public string Name { get; set; }
        public string FacultyNumber { get; set; }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FacultyNumber { get; set; }
    }

    internal class StartUp
    {
        private static void Main()
        {
            List<Specialty> specialties = new List<Specialty>();
            List<Student> students = new List<Student>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "students:")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstPart = inputArgs[0];
                string secondPart = inputArgs[1];
                string facultyNumber = inputArgs[2];

                Specialty specialty = new Specialty()
                {
                    Name = firstPart + " " + secondPart,
                    FacultyNumber = facultyNumber
                };

                specialties.Add(specialty);
            }

            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string facultyNumber = inputArgs[0];
                string firstName = inputArgs[1];
                string lastName = inputArgs[2];

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    FacultyNumber = facultyNumber
                };

                students.Add(student);
            }

            specialties
             .Join(students,
                 specialty => specialty.FacultyNumber,
                 student => student.FacultyNumber,
                 (specialty, student) => new
                 {
                     StudentName = student.FirstName + " " + student.LastName,
                     FacultyNumber = student.FacultyNumber,
                     SpecialtyName = specialty.Name
                 }
             )
             .OrderBy(st => st.StudentName)
             .ToList()
             .ForEach(group => Console.WriteLine($"{group.StudentName} {group.FacultyNumber} {group.SpecialtyName}"));
        }
    }
}