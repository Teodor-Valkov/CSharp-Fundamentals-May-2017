namespace _06.ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = num => num % divisor == 0;
            //bool IsDivisible(int num) => num % divisor == 0;

            numbers = numbers.Where(num => !isDivisible(num)).Reverse().ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}