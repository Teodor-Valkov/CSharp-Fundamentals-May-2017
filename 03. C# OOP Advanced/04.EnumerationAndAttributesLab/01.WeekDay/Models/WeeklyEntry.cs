using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    public WeeklyEntry(string weekDay, string notes)
    {
        this.WeekDay = (WeekDay)Enum.Parse(typeof(WeekDay), weekDay);
        this.Notes = notes;
    }

    public WeekDay WeekDay { get; private set; }

    public string Notes { get; private set; }

    public int CompareTo(WeeklyEntry other)
    {
        if (this.WeekDay.CompareTo(other.WeekDay) != 0)
        {
            return this.WeekDay.CompareTo(other.WeekDay);
        }

        if (this.Notes.CompareTo(other.Notes) != 0)
        {
            return this.Notes.CompareTo(other.Notes);
        }

        return 0;
    }

    public override string ToString()
    {
        return $"{this.WeekDay} - {this.Notes}";
    }
}