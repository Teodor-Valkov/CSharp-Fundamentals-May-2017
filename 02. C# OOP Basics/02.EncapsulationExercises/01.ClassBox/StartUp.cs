using System;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            Box box = new Box(length, width, height);

            double surface = box.GetSurfaceArea();
            double lateralSurface = box.GetLateralSurfaceArea();
            double volume = box.GetVolume();

            Console.WriteLine($"Surface Area - {surface:F2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurface:F2}");
            Console.WriteLine($"Volume - {volume:F2}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}