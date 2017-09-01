namespace _01.ActionPrint
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printOnNewLine = name => Console.WriteLine(string.Join("\n", names));
            //void PrintOnNewLine(string[] name) => Console.WriteLine(string.Join("\n", names));

            printOnNewLine(names);
        }
    }
}