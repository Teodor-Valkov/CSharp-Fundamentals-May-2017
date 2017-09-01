using System;

public class DateModifier
{
    public static int FindTimeDiff(string firstDateAsString, string secondDateAsString)
    {
        DateTime firstDate = DateTime.Parse(firstDateAsString);
        DateTime secondDate = DateTime.Parse(secondDateAsString);

        TimeSpan timeDiff = firstDate - secondDate;
        return Math.Abs(timeDiff.Days);
    }
}