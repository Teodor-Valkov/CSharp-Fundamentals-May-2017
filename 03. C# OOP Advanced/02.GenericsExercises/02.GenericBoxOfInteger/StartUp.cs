using System;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int input;

        for (int i = 0; i < number; i++)
        {
            input = int.Parse(Console.ReadLine());
            Box<int> intBox = new Box<int>(input);

            Console.WriteLine(intBox);
        }
    }
}