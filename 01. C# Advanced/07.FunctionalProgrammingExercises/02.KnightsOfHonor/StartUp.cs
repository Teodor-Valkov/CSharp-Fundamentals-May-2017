namespace _02.KnightsOfHonor
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printOnNewLine = name => Console.WriteLine($"Sir {string.Join("\nSir ", names)}");
            //void PrintOnNewLine(string[] name) => Console.WriteLine($"Sir {string.Join("\nSir ", names)}");

            printOnNewLine(names);
        }
    }
}