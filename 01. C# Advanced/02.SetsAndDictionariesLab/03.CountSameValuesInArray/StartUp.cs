namespace _03.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            double[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            SortedDictionary<double, int> dict = new SortedDictionary<double, int>();

            foreach (double number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }

                dict[number]++;
            }

            foreach (KeyValuePair<double, int> pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}