namespace _08.CustomComparator
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Sort(numbers, Compare);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int Compare(int a, int b)
        {
            int remainderA = Math.Abs(a) % 2;
            int remainderB = Math.Abs(b) % 2;

            if (remainderA != remainderB)
            {
                return remainderA.CompareTo(remainderB);
            }

            return a.CompareTo(b);
        }
    }
}