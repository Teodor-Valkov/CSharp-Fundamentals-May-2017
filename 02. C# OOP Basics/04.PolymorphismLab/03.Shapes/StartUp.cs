using System;

public class StartUp
{
    public static void Main()
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(5, 10);

        Console.WriteLine(circle.Draw());
        Console.WriteLine(circle.CalculatePerimeter());
        Console.WriteLine(circle.CalculateArea());

        Console.WriteLine(rectangle.Draw());
        Console.WriteLine(rectangle.CalculatePerimeter());
        Console.WriteLine(rectangle.CalculateArea());
    }
}