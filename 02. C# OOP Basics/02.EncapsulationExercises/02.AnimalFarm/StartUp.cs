using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        Type chickenType = typeof(Chicken);
        FieldInfo[] fields = chickenType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo[] methods = chickenType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        Debug.Assert(fields.Count(f => f.IsPrivate) == 2);
        Debug.Assert(methods.Count(m => m.IsPrivate) == 1);

        try
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);
            Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.GetProductPerDay()} eggs per day.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}