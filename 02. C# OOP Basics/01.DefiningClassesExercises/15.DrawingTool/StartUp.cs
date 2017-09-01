using System;

public class StartUp
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Figure figure = null;

        switch (input)
        {
            case "Square":
                int size = int.Parse(Console.ReadLine());
                figure = new Square(size);
                break;

            case "Rectangle":
                int width = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                figure = new Rectangle(width, height);
                break;
        }

        figure.Draw();
    }
}