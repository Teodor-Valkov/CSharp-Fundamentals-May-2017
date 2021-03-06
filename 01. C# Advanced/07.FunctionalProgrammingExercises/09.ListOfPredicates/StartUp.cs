﻿namespace _09.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> result = new List<int>();
            Func<int, bool>[] funcArray = divisors.Select(divisor => (Func<int, bool>)(num => num % divisor == 0)).ToArray();

            for (int i = 1; i <= number; i++)
            {
                bool isDivisible = true;

                foreach (Func<int, bool> func in funcArray)
                {
                    if (func(i))
                    {
                        continue;
                    }

                    isDivisible = false;
                    break;
                }

                if (isDivisible)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}