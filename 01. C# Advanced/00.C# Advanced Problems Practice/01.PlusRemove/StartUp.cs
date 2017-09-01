namespace _01.PlusRemove
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            List<string> input = new List<string>();
            List<string> result = new List<string>();

            string line = string.Empty;
            while ((line = Console.ReadLine()).ToLower() != "end")
            {
                input.Add(line);
                result.Add(line);
            }

            for (int row = 0; row < input.Count - 2; row++)
            {
                string first = input[row];
                string second = input[row + 1];
                string third = input[row + 2];

                int minLength = Math.Min(Math.Min(first.Length, second.Length), third.Length);

                for (int col = 1; col < minLength && col < second.Length - 1; col++)
                {
                    bool hasPlus = CheckForPlus(col, first, second, third);

                    if (hasPlus)
                    {
                        UpdateFinals(result, row, col);
                    }
                }
            }

            PrintFinals(result);
        }

        private static bool CheckForPlus(int col, string first, string second, string third)
        {
            string up = first.Substring(col, 1).ToLower();
            string middle = second.Substring(col - 1, 3).ToLower();
            string down = third.Substring(col, 1).ToLower();

            string match = new string(up[0], 3);

            if (up == down && match == middle)
            {
                return true;
            }

            return false;
        }

        private static void UpdateFinals(List<string> finals, int row, int col)
        {
            finals[row] = finals[row].Remove(col, 1).Insert(col, "+");
            finals[row + 1] = finals[row + 1].Remove(col - 1, 3).Insert(col - 1, new string('+', 3));
            finals[row + 2] = finals[row + 2].Remove(col, 1).Insert(col, "+");
        }

        private static void PrintFinals(List<string> finals)
        {
            for (int i = 0; i < finals.Count; i++)
            {
                finals[i] = finals[i].Replace("+", string.Empty);
                Console.WriteLine(finals[i]);
            }
        }
    }
}