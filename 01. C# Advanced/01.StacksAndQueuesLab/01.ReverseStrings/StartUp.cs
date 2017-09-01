namespace _01.ReverseStrings
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> reversedInput = new Stack<char>(input);

            Console.WriteLine(string.Join("", reversedInput));
        }
    }
}