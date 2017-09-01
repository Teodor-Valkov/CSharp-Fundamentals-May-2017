namespace _09.ListOfPredicates2
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
            Func<int, int, bool> funcArray = (n, d) => n % d == 0;
            //bool FuncArray(int n, int d) => n % d == 0;

            for (int i = 1; i <= number; i++)
            {
                bool isDivisible = true;

                foreach (int divisor in divisors)
                {
                    // Solution II
                    //
                    //Predicate<int> predicate = n => i % n == 0;
                    //if (predicate(divisor))
                    //{
                    //    continue;
                    //}

                    if (funcArray(i, divisor))
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