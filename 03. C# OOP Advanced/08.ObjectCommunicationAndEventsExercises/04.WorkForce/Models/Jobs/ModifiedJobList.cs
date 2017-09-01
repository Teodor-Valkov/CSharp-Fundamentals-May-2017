using System.Collections.Generic;

public class ModifiedJobList : List<Job>
{
    public void HandleJobDone(object sender, JobHandlerEventArgs eventArgs)
    {
        this.Remove(eventArgs.Job);
    }
}