namespace _01.ArrangeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Dictionary<int, int> repetitions = new Dictionary<int, int>();
            Dictionary<int, string> dict = new Dictionary<int, string>();

            foreach (int number in numbers)
            {
                if (dict.ContainsKey(number))
                {
                    repetitions[number]++;
                    continue;
                }

                dict[number] = string.Empty;

                foreach (char digit in number.ToString())
                {
                    switch (digit)
                    {
                        case '0': dict[number] += "zero-"; break;
                        case '1': dict[number] += "one-"; break;
                        case '2': dict[number] += "two-"; break;
                        case '3': dict[number] += "three-"; break;
                        case '4': dict[number] += "four-"; break;
                        case '5': dict[number] += "five-"; break;
                        case '6': dict[number] += "six-"; break;
                        case '7': dict[number] += "seven-"; break;
                        case '8': dict[number] += "eight-"; break;
                        case '9': dict[number] += "nine-"; break;
                    }
                }

                dict[number] = dict[number].TrimEnd('-');
                repetitions[number] = 1;
            }

            dict = dict.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<int, string> pair in dict)
            {
                int number = pair.Key;

                if (repetitions.ContainsKey(number))
                {
                    for (int i = 0; i < repetitions[number]; i++)
                    {
                        sb.Append($"{number}, ");
                    }
                }
                else
                {
                    sb.Append($"{number}, ");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
        }
    }
}