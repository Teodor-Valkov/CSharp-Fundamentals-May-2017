using System;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");

        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int number = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < number; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);

            Person member = new Person(name, age);
            family.AddMember(member);
        }

        Person oldestMember = family.GetOldestMember();
        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}