using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private double workingHours;

    public Worker(string firstName, string lastName, decimal weekSalary, double workingHours)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHours = workingHours;
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        private set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    public double WorkingHours
    {
        get
        {
            return this.workingHours;
        }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workingHours = value;
        }
    }

    private decimal SalaryPerHour()
    {
        return this.WeekSalary / (decimal)(this.WorkingHours * 5);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
        sb.AppendLine($"Hours per day: {this.WorkingHours:F2}");
        sb.AppendLine($"Salary per hour: {this.SalaryPerHour():F2}");

        return sb.ToString();
    }
}