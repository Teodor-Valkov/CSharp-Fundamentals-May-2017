using System;

public class StartUp
{
    public static void Main()
    {
        string[] firstInputArgs = Console.ReadLine().Split();
        string firstName = firstInputArgs[0];
        string secondName = firstInputArgs[1];
        string address = firstInputArgs[2];

        Tuple<string, string> firstTuple = new Tuple<string, string>(firstName + " " + secondName, address);

        string[] secondInputArgs = Console.ReadLine().Split();
        string name = secondInputArgs[0];
        int beers = int.Parse(secondInputArgs[1]);

        Tuple<string, int> secondTuple = new Tuple<string, int>(name, beers);

        string[] thirdInputArgs = Console.ReadLine().Split();
        int intNumber = int.Parse(thirdInputArgs[0]);
        double doubleNumber = double.Parse(thirdInputArgs[1]);

        Tuple<int, double> thirdTuple = new Tuple<int, double>(intNumber, doubleNumber);

        Console.WriteLine(firstTuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }
}