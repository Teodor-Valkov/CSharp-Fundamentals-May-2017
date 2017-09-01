using System;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        string input;

        for (int i = 0; i < number; i++)
        {
            input = Console.ReadLine();
            Box<string> stringBox = new Box<string>(input);

            Console.WriteLine(stringBox);
        }
    }
}