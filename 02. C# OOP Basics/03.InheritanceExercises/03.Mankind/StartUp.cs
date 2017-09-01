using System;

public class StartUp
{
    public static void Main()
    {
        string[] studentArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] workerArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string studentFirstName = studentArgs[0];
        string studentLastName = studentArgs[1];
        string studentFacultyNumber = studentArgs[2];

        string workerFirstName = workerArgs[0];
        string workerLastName = workerArgs[1];
        decimal workerSalary = decimal.Parse(workerArgs[2]);
        double workerHours = double.Parse(workerArgs[3]);

        try
        {
            Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
            Worker worker = new Worker(workerFirstName, workerLastName, workerSalary, workerHours);

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}