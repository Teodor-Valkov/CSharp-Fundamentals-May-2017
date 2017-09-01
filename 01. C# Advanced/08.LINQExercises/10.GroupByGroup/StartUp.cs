namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string Name { get; set; }
        public int Group { get; set; }
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
                int group = int.Parse(inputArgs[2]);

                Student student = new Student
                {
                    Name = firstName + " " + lastName,
                    Group = group
                };

                students.Add(student);
            }

            students
             .GroupBy(student => student.Group)
             .OrderBy(group => group.Key)
             .ToList()
             .ForEach(group => Console.WriteLine($"{group.Key} - {string.Join(", ", group.ToList().Select(student => student.Name))}"));
        }
    }
}