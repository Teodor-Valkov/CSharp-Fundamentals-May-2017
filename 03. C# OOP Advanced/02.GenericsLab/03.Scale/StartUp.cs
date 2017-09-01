using System;

public class StartUp
{
    public static void Main()
    {
        Scale<string> stringScale = new Scale<string>("left", "right");
        Console.WriteLine(stringScale.GetHavier());

        Scale<int> intScale = new Scale<int>(1, 2);
        Console.WriteLine(intScale.GetHavier());
    }
}