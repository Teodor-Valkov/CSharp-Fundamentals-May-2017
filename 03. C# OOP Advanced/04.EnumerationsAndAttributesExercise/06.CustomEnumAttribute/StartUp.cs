using System;
using System.Collections.Generic;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        string rankOrSuit = Console.ReadLine();

        Type type;

        switch (rankOrSuit)
        {
            case "Rank":
                type = typeof(Rank);
                break;

            case "Suit":
                type = typeof(Suit);
                break;

            default:
                throw new InvalidOperationException();
        }

        //object[] attributes = type.GetCustomAttributes(false);
        IEnumerable<Attribute> attributes = type.GetCustomAttributes();

        foreach (TypeAttribute attribute in attributes)
        {
            Console.WriteLine(attribute);
        }
    }
}