using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        IList<IBox<int>> intBoxes = new List<IBox<int>>();
        int input;

        for (int i = 0; i < number; i++)
        {
            input = int.Parse(Console.ReadLine());
            IBox<int> intBox = new Box<int>(input);

            intBoxes.Add(intBox);
        }

        int[] indexes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int firstIndex = indexes[0];
        int secondIndex = indexes[1];

        Swap(intBoxes, firstIndex, secondIndex);

        foreach (IBox<int> intBox in intBoxes)
        {
            Console.WriteLine(intBox);
        }
    }

    public static void Swap<T>(IList<IBox<T>> boxes, int firstIndex, int secondIndex)
    {
        IBox<T> temp = boxes[firstIndex];
        boxes[firstIndex] = boxes[secondIndex];
        boxes[secondIndex] = temp;
    }
}