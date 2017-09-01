namespace _01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> reversedNumbers = new Stack<int>();

            foreach (int number in numbers)
            {
                reversedNumbers.Push(number);
            }

            Console.WriteLine(string.Join(" ", reversedNumbers));
        }
    }
}