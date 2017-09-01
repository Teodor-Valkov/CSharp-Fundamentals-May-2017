namespace _02.StringLength
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            string result = input.Length > 20
                ? input.Substring(0, 20)
                : input.PadRight(20, '*');

            Console.WriteLine(result);
        }
    }
}