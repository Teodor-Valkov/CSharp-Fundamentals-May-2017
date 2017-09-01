namespace _03.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Stack<int> stack = new Stack<int>();

            while (number > 0)
            {
                int reminder = number % 2;

                stack.Push(reminder);

                number /= 2;
            }

            Console.WriteLine(string.Join("", stack));
        }
    }
}