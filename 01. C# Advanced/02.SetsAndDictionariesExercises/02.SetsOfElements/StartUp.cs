namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            HashSet<int> firstHashSet = new HashSet<int>();
            HashSet<int> secondHashSet = new HashSet<int>();

            for (int i = 0; i < numbers[0]; i++)
            {
                firstHashSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < numbers[1]; i++)
            {
                secondHashSet.Add(int.Parse(Console.ReadLine()));
            }

            firstHashSet.IntersectWith(secondHashSet);

            Console.WriteLine(string.Join(" ", firstHashSet));
        }
    }
}