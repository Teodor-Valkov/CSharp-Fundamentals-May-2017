using System;

public delegate void JobUpdateEventHandler(object sender, JobHandlerEventArgs args);

public class Job
{
    public Job(string name, int workedHoursRequired, IEmployee employee)
    {
        this.Name = name;
        this.WorkedHoursRequired = workedHoursRequired;
        this.Employee = employee;
    }

    public event JobUpdateEventHandler JobUpdateEvent;

    public string Name { get; private set; }

    public int WorkedHoursRequired { get; private set; }

    public IEmployee Employee { get; private set; }

    public void Update()
    {
        this.WorkedHoursRequired -= this.Employee.WorkedHoursPerWeek;

        if (this.WorkedHoursRequired <= 0)
        {
            Console.WriteLine($"Job {this.Name} done!");
            this.OnJobUpdate(new JobHandlerEventArgs(this));
        }
    }

    public void OnJobUpdate(JobHandlerEventArgs eventArgs)
    {
        if (this.JobUpdateEvent != null)
        {
            this.JobUpdateEvent(this, eventArgs);
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.WorkedHoursRequired}";
    }
}