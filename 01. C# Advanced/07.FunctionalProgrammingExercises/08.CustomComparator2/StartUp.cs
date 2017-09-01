namespace _08.CustomComparator2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Sort(numbers, new MyComparer());

            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class MyComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }

            //if (x < y)
            //{
            //    return -1;
            //}

            //if (x > y)
            //{
            //    return 1;
            //}

            //return 0;

            return x.CompareTo(y);
        }
    }
}