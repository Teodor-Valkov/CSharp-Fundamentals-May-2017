using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        IList<IBox<double>> doubleBoxes = new List<IBox<double>>();
        double input;

        for (int i = 0; i < number; i++)
        {
            input = double.Parse(Console.ReadLine());
            IBox<double> doubleBox = new Box<double>(input);

            doubleBoxes.Add(doubleBox);
        }

        double dataToCompare = double.Parse(Console.ReadLine());
        int count = 0;

        foreach (IBox<double> doubleBox in doubleBoxes)
        {
            if (doubleBox.IsDataGreater(dataToCompare))
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}