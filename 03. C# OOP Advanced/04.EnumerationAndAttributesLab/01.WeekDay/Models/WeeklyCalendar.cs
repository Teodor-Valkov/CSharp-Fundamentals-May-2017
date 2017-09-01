using System.Collections.Generic;

public class WeeklyCalendar
{
    public WeeklyCalendar()
    {
        this.WeeklySchedule = new List<WeeklyEntry>();
    }

    public IList<WeeklyEntry> WeeklySchedule { get; private set; }

    public void AddEntry(string weekDay, string notes)
    {
        this.WeeklySchedule.Add(new WeeklyEntry(weekDay, notes));
    }
}