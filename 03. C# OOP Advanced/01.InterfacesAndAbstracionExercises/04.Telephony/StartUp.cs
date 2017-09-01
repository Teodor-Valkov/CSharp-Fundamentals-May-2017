namespace _04.Telephony
{
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone(numbers, websites);

            smartphone.Call();
            smartphone.Browse();
        }
    }
}