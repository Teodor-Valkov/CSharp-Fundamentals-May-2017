using System;
using System.Collections.Generic;
using System.Linq;

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

        int[] indexes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int firstIndex = indexes[0];
        int secondIndex = indexes[1];

        Swap(stringBoxes, firstIndex, secondIndex);

        foreach (IBox<string> stringBox in stringBoxes)
        {
            Console.WriteLine(stringBox);
        }
    }

    public static void Swap<T>(IList<IBox<T>> boxes, int firstIndex, int secondIndex)
    {
        IBox<T> temp = boxes[firstIndex];
        boxes[firstIndex] = boxes[secondIndex];
        boxes[secondIndex] = temp;
    }
}