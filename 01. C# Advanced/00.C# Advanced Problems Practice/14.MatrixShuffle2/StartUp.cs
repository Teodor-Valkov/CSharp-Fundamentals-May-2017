﻿namespace _14.MatrixShuffle2
{
    using System;
    using System.Linq;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string input = Console.ReadLine().PadRight(size * size, ' ');

            char[,] matrix = new char[size, size];

            FillTheSpiralMatrix(size, input, matrix);

            string result = GetResult(size, matrix);

            Console.WriteLine(IsPalindrome(result)
                ? $"<div style='background-color:#4FE000'>{result}</div>"
                : $"<div style='background-color:#E0000F'>{result}</div>");
        }

        private static void FillTheSpiralMatrix(int size, string input, char[,] matrix)
        {
            int leftColumn = 0;
            int rightColumn = size - 1;
            int upperRow = 0;
            int bottomRow = size - 1;
            int index = 0;

            while (index < size * size)
            {
                // Filling the upper row
                for (int col = leftColumn; col <= rightColumn; col++)
                {
                    matrix[upperRow, col] = input[index++];
                }

                // Move one row down
                upperRow++;

                // Filling the right column
                for (int row = upperRow; row <= bottomRow; row++)
                {
                    matrix[row, rightColumn] = input[index++];
                }

                // Move one column left
                rightColumn--;

                // Filling the bottom row
                for (int col = rightColumn; col >= leftColumn; col--)
                {
                    matrix[bottomRow, col] = input[index++];
                }

                // Move one row up
                bottomRow--;

                // Filling the left column
                for (int row = bottomRow; row >= upperRow; row--)
                {
                    matrix[row, leftColumn] = input[index++];
                }

                // Move one column right
                leftColumn++;
            }
        }

        private static string GetResult(int size, char[,] matrix)
        {
            StringBuilder firstPart = new StringBuilder();
            StringBuilder secondPart = new StringBuilder();

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row % 2 == 0 && col % 2 == 0 || row % 2 == 1 && col % 2 == 1)
                    {
                        firstPart.Append(matrix[row, col]);
                    }
                    else if (row % 2 == 0 && col % 2 == 1 || row % 2 == 1 && col % 2 == 0)
                    {
                        secondPart.Append(matrix[row, col]);
                    }
                }
            }

            return firstPart + secondPart.ToString();
        }

        private static bool IsPalindrome(string result)
        {
            string resultToLower = result.ToLower();

            StringBuilder resultWithOnlyLetters = new StringBuilder();

            foreach (char symbol in resultToLower)
            {
                if (char.IsLower(symbol))
                {
                    resultWithOnlyLetters.Append(symbol);
                }
            }

            string first = string.Join("", resultWithOnlyLetters);
            string second = string.Join("", first.Reverse());

            return first == second;
        }
    }
}