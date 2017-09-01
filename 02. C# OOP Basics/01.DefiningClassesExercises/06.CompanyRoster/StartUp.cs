using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < number; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = inputArgs[0];
            decimal salary = decimal.Parse(inputArgs[1]);
            string position = inputArgs[2];
            string deparment = inputArgs[3];

            Employee employee = null;
            string email = string.Empty;
            int age = 0;

            switch (inputArgs.Length)
            {
                case 4:
                    employee = new Employee(name, salary, position, deparment);
                    break;

                case 5:
                    bool isDigit = inputArgs[4].All(char.IsDigit);

                    if (isDigit)
                    {
                        age = int.Parse(inputArgs[4]);
                        employee = new Employee(name, salary, position, deparment, age);
                    }
                    else
                    {
                        email = inputArgs[4];
                        employee = new Employee(name, salary, position, deparment, email);
                    }
                    break;

                case 6:
                    email = inputArgs[4];
                    age = int.Parse(inputArgs[5]);
                    employee = new Employee(name, salary, position, deparment, email, age);
                    break;
            }

            employees.Add(employee);
        }

        var groupedByDepartmentWithHighestAverageSalary = employees
                .GroupBy(group => group.Department)
                .Select(group => new
                {
                    Department = group.Key,
                    AverageSalary = group.Average(employee => employee.Salary),
                    Employees = group.OrderByDescending(employee => employee.Salary)
                })
                .OrderByDescending(group => group.AverageSalary)
                .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {groupedByDepartmentWithHighestAverageSalary.Department}");

        foreach (Employee employee in groupedByDepartmentWithHighestAverageSalary.Employees)
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
        }
    }
}