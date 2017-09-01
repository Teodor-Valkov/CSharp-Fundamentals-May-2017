using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        IList<IBox<string>> stringBoxes = new List<IBox<string>>();
        string input;

        for (int i = 0; i < number; i++)
        {
            input = Console.ReadLine();
            IBox<string> stringBox = new Box<string>(input);

            stringBoxes.Add(stringBox);
        }

        string dataToCompare = Console.ReadLine();
        int count = 0;

        foreach (IBox<string> stringBox in stringBoxes)
        {
            if (stringBox.IsDataGreater(dataToCompare))
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}