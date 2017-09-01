using System;
using System.Collections.Generic;

// 80/100 in Judge
public class StartUp
{
    public static void Main()
    {
        ModifiedJobList jobs = new ModifiedJobList();
        Dictionary<string, IEmployee> employeesByName = new Dictionary<string, IEmployee>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string action = inputArgs[0];
            string employeeName;
            string jobName;
            int workHoursRequired;

            switch (action)
            {
                case "StandartEmployee":
                    employeeName = inputArgs[1];
                    IEmployee standartEmployee = new StandartEmployee(employeeName);

                    employeesByName[employeeName] = standartEmployee;
                    break;

                case "PartTimeEmployee":
                    employeeName = inputArgs[1];
                    IEmployee partTimeEmployee = new PartTimeEmployee(employeeName);

                    employeesByName[employeeName] = partTimeEmployee;
                    break;

                case "Job":
                    jobName = inputArgs[1];
                    workHoursRequired = int.Parse(inputArgs[2]);
                    employeeName = inputArgs[3];

                    IEmployee employee = employeesByName[employeeName];
                    Job job = new Job(jobName, workHoursRequired, employee);

                    job.JobUpdateEvent += jobs.HandleJobDone;
                    jobs.Add(job);
                    break;

                case "Pass":
                    UpdateJobs(jobs);
                    break;

                case "Status":
                    jobs.ForEach(j => Console.WriteLine(j));
                    break;
            }
        }
    }

    private static void UpdateJobs(ModifiedJobList jobs)
    {
        for (int i = 0; i < jobs.Count; i++)
        {
            jobs[i].Update();
        }
    }
}