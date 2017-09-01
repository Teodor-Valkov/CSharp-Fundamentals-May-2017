using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int number = numbers[0];
        int intersections = numbers[1];

        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < number; i++)
        {
            string[] inptArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string id = inptArgs[0];
            double width = double.Parse(inptArgs[1]);
            double height = double.Parse(inptArgs[2]);
            double x = double.Parse(inptArgs[3]);
            double y = double.Parse(inptArgs[4]);

            Rectangle rectangle = new Rectangle(id, width, height, x, y);
            rectangles.Add(rectangle);
        }

        for (int i = 0; i < intersections; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Rectangle firstRectangle = rectangles.First(r => r.Id == inputArgs[0]);
            Rectangle secondRectangle = rectangles.First(r => r.Id == inputArgs[1]);

            Console.WriteLine(firstRectangle.Intersects(secondRectangle)
                ? "true"
                : "false");
        }
    }
}