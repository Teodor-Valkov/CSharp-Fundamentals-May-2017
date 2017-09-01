using System;

public class JobHandlerEventArgs : EventArgs
{
    public JobHandlerEventArgs(Job job)
    {
        this.Job = job;
    }

    public Job Job { get; private set; }
}