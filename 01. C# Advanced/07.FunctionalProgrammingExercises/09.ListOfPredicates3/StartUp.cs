namespace _09.ListOfPredicates3
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

            List<int> numbers = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                numbers.Add(i);
            }

            foreach (int divisor in divisors)
            {
                Predicates.AddPredicate(num => num % divisor == 0);
            }

            numbers = Predicates.ApplyPredicates(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    internal static class Predicates
    {
        public static List<Func<int, bool>> predicates = new List<Func<int, bool>>();

        public static void AddPredicate(Func<int, bool> predicate)
        {
            predicates.Add(predicate);
        }

        public static List<int> ApplyPredicates(List<int> collection)
        {
            List<int> result = new List<int>();

            foreach (int number in collection)
            {
                bool isDivisible = true;

                foreach (Func<int, bool> predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}