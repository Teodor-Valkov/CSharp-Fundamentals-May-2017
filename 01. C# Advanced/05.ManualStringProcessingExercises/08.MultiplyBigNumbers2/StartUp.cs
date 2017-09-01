namespace _08.MultiplyBigNumbers2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            Stack<char> firstNumber = new Stack<char>(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder result = new StringBuilder();
            int product = 0;

            while (firstNumber.Count != 0)
            {
                product /= 10;

                product += int.Parse(firstNumber.Pop().ToString()) * number;

                result.Insert(0, product % 10);
            }

            result.Insert(0, product / 10);

            Console.WriteLine(result.ToString().TrimStart('0'));
        }
    }
}