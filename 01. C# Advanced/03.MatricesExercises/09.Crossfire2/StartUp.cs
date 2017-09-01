namespace _09.Crossfire2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            List<List<int>> matrix = FillMatrix(rows, cols);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "nuke it from orbit")
            {
                int[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int targetRow = inputArgs[0];
                int targetCol = inputArgs[1];
                int radius = inputArgs[2];

                for (int row = targetRow - radius; row <= targetRow + radius; row++)
                {
                    if (IsInMatrix(row, targetCol, matrix))
                    {
                        matrix[row][targetCol] = -1;
                    }
                }

                for (int col = targetCol - radius; col <= targetCol + radius; col++)
                {
                    if (IsInMatrix(targetRow, col, matrix))
                    {
                        matrix[targetRow][col] = -1;
                    }
                }

                ClearUp(matrix);
            }

            PrintMatrix(matrix);
        }

        private static List<List<int>> FillMatrix(int rows, int cols)
        {
            List<List<int>> matrix = new List<List<int>>();

            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>(cols));

                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(row * cols + col + 1);
                }
            }

            return matrix;
        }

        private static bool IsInMatrix(int currentRow, int currentCol, List<List<int>> matrix)
        {
            if (currentRow >= 0 && currentRow < matrix.Count && currentCol >= 0 && currentCol < matrix[currentRow].Count)
            {
                return true;
            }

            return false;
        }

        private static void ClearUp(List<List<int>> matrix)
        {
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                for (int col = matrix[row].Count - 1; col >= 0; col--)
                {
                    if (matrix[row][col] == -1)
                    {
                        matrix[row].RemoveAt(col);
                    }
                }

                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                }
            }
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (List<int> row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}