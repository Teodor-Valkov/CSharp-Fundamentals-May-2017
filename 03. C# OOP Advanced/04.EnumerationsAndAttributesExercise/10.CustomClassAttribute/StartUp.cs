using System;

public class StartUp
{
    public static void Main()
    {
        Type type = typeof(Weapon);
        object[] attributes = type.GetCustomAttributes(false);
        WeaponAttribute attribute = attributes[0] as WeaponAttribute;

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            switch (command)
            {
                case "Author":
                    Console.WriteLine($"Author: {attribute.Author}");
                    break;

                case "Revision":
                    Console.WriteLine($"Revision: {attribute.Revision}");
                    break;

                case "Description":
                    Console.WriteLine($"Class description: {attribute.Description}");
                    break;

                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                    break;
            }
        }
    }
}