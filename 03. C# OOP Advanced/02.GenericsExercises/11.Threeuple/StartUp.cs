using System;

public class StartUp
{
    public static void Main()
    {
        string[] firstInputArgs = Console.ReadLine().Split();
        string firstName = firstInputArgs[0];
        string secondName = firstInputArgs[1];
        string address = firstInputArgs[2];
        string town = firstInputArgs[3];

        Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(firstName + " " + secondName, address, town);

        string[] secondInputArgs = Console.ReadLine().Split();
        string name = secondInputArgs[0];
        int beers = int.Parse(secondInputArgs[1]);
        string status = secondInputArgs[2];

        Threeuple<string, int, string> secondThreeuple = status == "drunk"
            ? new Threeuple<string, int, string>(name, beers, "True")
            : new Threeuple<string, int, string>(name, beers, "False");

        string[] thirdInputArgs = Console.ReadLine().Split();
        string personName = thirdInputArgs[0];
        double account = double.Parse(thirdInputArgs[1]);
        string bankName = thirdInputArgs[2];

        Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(personName, account, bankName);

        Console.WriteLine($"{firstThreeuple.FirstItem} -> {firstThreeuple.SecondItem} -> {firstThreeuple.ThirdItem}");
        Console.WriteLine($"{secondThreeuple.FirstItem} -> {secondThreeuple.SecondItem} -> {secondThreeuple.ThirdItem}");
        Console.WriteLine($"{thirdThreeuple.FirstItem} -> {thirdThreeuple.SecondItem:F1} -> {thirdThreeuple.ThirdItem}");
    }
}