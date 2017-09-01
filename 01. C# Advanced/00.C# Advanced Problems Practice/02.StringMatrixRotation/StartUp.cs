namespace _02.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static void Main()
        {
            string rotation = Console.ReadLine();

            string pattern = @"\d+";
            Regex regex = new Regex(pattern);

            int degrees = int.Parse(regex.Match(rotation).Value);

            List<string> input = new List<string>();

            string word = string.Empty;
            int longestWordLength = 0;

            while ((word = Console.ReadLine()).ToLower() != "end")
            {
                input.Add(word);

                if (longestWordLength < word.Length)
                {
                    longestWordLength = word.Length;
                }
            }

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Length < longestWordLength)
                {
                    input[i] = $"{input[i]}{new string(' ', longestWordLength - input[i].Length)}";
                }
            }

            char[,] rotate90 = new char[longestWordLength, input.Count];

            for (int row = 0; row < rotate90.GetLength(0); row++)
            {
                for (int col = 0; col < rotate90.GetLength(1); col++)
                {
                    rotate90[row, col] = input[col][row];
                }
            }

            RotateOn90Degrees(degrees, rotate90);

            RotateOn180Degrees(degrees, input);

            RotateOn270Degrees(degrees, rotate90);

            RotateOn360Degrees(degrees, input);
        }

        private static void RotateOn90Degrees(int degrees, char[,] rotate90)
        {
            if (degrees == 90 || degrees % 360 == 90)
            {
                for (int row = 0; row < rotate90.GetLength(0); row++)
                {
                    for (int col = rotate90.GetLength(1) - 1; col >= 0; col--)
                    {
                        Console.Write(rotate90[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }

        private static void RotateOn180Degrees(int degrees, List<string> input)
        {
            if (degrees == 180 || degrees % 360 == 180)
            {
                for (int row = input.Count - 1; row >= 0; row--)
                {
                    for (int col = input[row].Length - 1; col >= 0; col--)
                    {
                        Console.Write(input[row][col]);
                    }

                    Console.WriteLine();
                }
            }
        }

        private static void RotateOn270Degrees(int degrees, char[,] rotate90)
        {
            if (degrees == 270 || degrees % 360 == 270)
            {
                for (int row = rotate90.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int col = 0; col < rotate90.GetLength(1); col++)
                    {
                        Console.Write(rotate90[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }

        private static void RotateOn360Degrees(int degrees, List<string> input)
        {
            if (degrees == 0 || degrees % 360 == 0)
            {
                foreach (string rotate360 in input)
                {
                    Console.WriteLine(rotate360);
                }
            }
        }
    }
}