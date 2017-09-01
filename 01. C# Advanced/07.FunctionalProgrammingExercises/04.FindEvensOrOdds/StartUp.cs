namespace _04.FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            List<int> boundaries = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string oddOrEven = Console.ReadLine();

            int firstNumber = boundaries[0];
            int secondNumber = boundaries[1];

            List<int> numbers = Enumerable.Range(firstNumber, secondNumber - firstNumber + 1).ToList();

            Predicate<int> isEven = num => num % 2 == 0;
            //bool IsEven(int num) => num % 2 == 0;

            switch (oddOrEven)
            {
                case "even":
                    Console.WriteLine(string.Join(" ", numbers.Where(num => isEven(num))));
                    break;

                case "odd":
                    Console.WriteLine(string.Join(" ", numbers.Where(num => !isEven(num))));
                    break;
            }
        }
    }
}