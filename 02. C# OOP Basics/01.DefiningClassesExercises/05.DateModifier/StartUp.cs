using System;

public class StartUp
{
    public static void Main()
    {
        string firstDateAsString = Console.ReadLine();
        string secondDateAsString = Console.ReadLine();

        int days = DateModifier.FindTimeDiff(firstDateAsString, secondDateAsString);
        Console.WriteLine(days);
    }
}