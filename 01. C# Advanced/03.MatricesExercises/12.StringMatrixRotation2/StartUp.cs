namespace _12.StringMatrixRotation2
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class StartUp
    {
        private static char[,] result;

        private static void Main()
        {
            string pattern = @"\d+";
            Regex regex = new Regex(pattern);

            string rotation = Console.ReadLine();
            int degreesAll = int.Parse(regex.Match(rotation).ToString());

            List<string> input = new List<string>();

            string word = string.Empty;
            int longestWordLength = 0;

            while ((word = Console.ReadLine()).ToLower() != "end")
            {
                input.Add(word);

                if (word.Length > longestWordLength)
                {
                    longestWordLength = word.Length;
                }
            }

            int degrees = (degreesAll / 90) % 4;

            switch (degrees)
            {
                case 0:
                    result = Rotate0Degree(input, longestWordLength);
                    PrintMatrix(result);
                    break;

                case 1:
                    result = Rotate90Degree(input, longestWordLength);
                    PrintMatrix(result);
                    break;

                case 2:
                    result = Rotate180Degree(input, longestWordLength);
                    PrintMatrix(result);
                    break;

                case 3:
                    result = Rotate270Degree(input, longestWordLength);
                    PrintMatrix(result);
                    break;
            }
        }

        private static char[,] Rotate0Degree(List<string> input, int longestWordLength)
        {
            int rows = input.Count;
            int cols = longestWordLength;
            char[,] matrix = new char[rows, cols];

            for (int row = 0, counter = 0; row < rows; row++, counter++)
            {
                string word = input[counter];
                for (int col = 0; col < cols; col++)
                {
                    if (col >= word.Length)
                    {
                        matrix[row, col] = ' ';
                    }
                    else
                    {
                        matrix[row, col] = word[col];
                    }
                }
            }

            return matrix;
        }

        private static char[,] Rotate90Degree(List<string> input, int longestWordLength)
        {
            int rows = longestWordLength;
            int cols = input.Count;
            char[,] matrix = new char[rows, cols];

            for (int col = cols - 1, counter = 0; col >= 0; col--, counter++)
            {
                string word = input[counter];
                for (int row = 0; row < rows; row++)
                {
                    if (row >= word.Length)
                    {
                        matrix[row, col] = ' ';
                    }
                    else
                    {
                        matrix[row, col] = word[row];
                    }
                }
            }

            return matrix;
        }

        private static char[,] Rotate180Degree(List<string> input, int longestWordLength)
        {
            int rows = input.Count;
            int cols = longestWordLength;
            char[,] matrix = new char[rows, cols];

            for (int row = rows - 1, counter = 0; row >= 0; row--, counter++)
            {
                string word = input[counter];
                for (int col = cols - 1, i = 0; col >= 0; col--, i++)
                {
                    if (i >= word.Length)
                    {
                        matrix[row, col] = ' ';
                    }
                    else
                    {
                        matrix[row, col] = word[i];
                    }
                }
            }

            return matrix;
        }

        private static char[,] Rotate270Degree(List<string> input, int longestWordLength)
        {
            int rows = longestWordLength;
            int cols = input.Count;
            char[,] matrix = new char[rows, cols];

            for (int col = 0, counter = 0; col < cols; col++, counter++)
            {
                string word = input[counter];
                for (int row = rows - 1, i = 0; row >= 0; row--, i++)
                {
                    if (row < rows - word.Length)
                    {
                        matrix[row, col] = ' ';
                    }
                    else
                    {
                        matrix[row, col] = word[i];
                    }
                }
            }

            return matrix;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}