namespace _03.GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            // Solution 1
            //
            Console.WriteLine(string.Join(" ", numbers.Where(num => num % 3 == 0)));
            Console.WriteLine(string.Join(" ", numbers.Where(num => num % 3 == 1 || num % 3 == -1)));
            Console.WriteLine(string.Join(" ", numbers.Where(num => num % 3 == 2 || num % 3 == -2)));

            // Solution 2
            //
            List<List<int>> matrix = new List<List<int>> { new List<int>(), new List<int>(), new List<int>() };

            foreach (int number in numbers)
            {
                if (number % 3 == 0)
                {
                    matrix[0].Add(number);
                }
                else if (number % 3 == -1 || number % 3 == 1)
                {
                    matrix[1].Add(number);
                }
                else if (number % 3 == -2 || number % 3 == 2)
                {
                    matrix[2].Add(number);
                }
            }

            foreach (List<int> list in matrix)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}