namespace _06.X_Removal
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

                for (int col = 0; col < first.Length - 2 && col < second.Length - 1 && col < third.Length - 2; col++)
                {
                    bool hasX = CheckForX(col, first, second, third);

                    if (hasX)
                    {
                        UpdateFinals(result, row, col);
                    }
                }
            }

            PrintFinals(result);
        }

        private static bool CheckForX(int col, string first, string second, string third)
        {
            string upLeft = first.Substring(col, 1).ToLower();
            string upRight = first.Substring(col + 2, 1).ToLower();
            string middle = second.Substring(col + 1, 1).ToLower();
            string downLeft = third.Substring(col, 1).ToLower();
            string downRight = third.Substring(col + 2, 1).ToLower();

            if (upLeft == upRight && upRight == middle && middle == downLeft && downLeft == downRight)
            {
                return true;
            }

            return false;
        }

        private static void UpdateFinals(List<string> finals, int row, int col)
        {
            finals[row] = finals[row].Remove(col, 1).Insert(col, "x");
            finals[row] = finals[row].Remove(col + 2, 1).Insert(col + 2, "x");
            finals[row + 1] = finals[row + 1].Remove(col + 1, 1).Insert(col + 1, "x");
            finals[row + 2] = finals[row + 2].Remove(col, 1).Insert(col, "x");
            finals[row + 2] = finals[row + 2].Remove(col + 2, 1).Insert(col + 2, "x");
        }

        private static void PrintFinals(List<string> finals)
        {
            for (int i = 0; i < finals.Count; i++)
            {
                finals[i] = finals[i].Replace("x", string.Empty);
                Console.WriteLine(finals[i]);
            }
        }
    }
}