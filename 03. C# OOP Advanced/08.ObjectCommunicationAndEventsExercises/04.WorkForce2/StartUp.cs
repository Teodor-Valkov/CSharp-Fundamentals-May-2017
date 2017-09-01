using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public delegate void JobDoneEventHandler(object sender, JobEventArgs e);

    public static void Main()
    {
        JobsList jobs = new JobsList();
        List<Employee> emploees = new List<Employee>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs[0];

            switch (command)
            {
                case "Job":
                    Job job = new Job(inputArgs[1], int.Parse(inputArgs[2]), emploees.FirstOrDefault(e => e.Name == inputArgs[3]));
                    job.JobDone += job.OnJobDone;
                    jobs.Add(job);
                    break;

                case "StandartEmployee":
                    emploees.Add(new StandartEmploee(inputArgs[1]));
                    break;

                case "PartTimeEmployee":
                    emploees.Add(new PartTimeEmploee(inputArgs[1]));
                    break;

                case "Pass":
                    foreach (Job currentJob in jobs)
                    {
                        currentJob.Update();
                    }
                    break;

                case "Status":
                    foreach (Job currentJob in jobs)
                    {
                        if (!currentJob.IsDone)
                        {
                            Console.WriteLine(currentJob.ToString());
                        }
                    }
                    break;
            }
        }
    }
}