namespace _10.ClearingCommands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;

    internal class StartUp
    {
        private static char[] symbols = { '>', '<', '^', 'v' };

        private static void Main()
        {
            List<char[]> matrix = new List<char[]>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                matrix.Add(input.ToCharArray());
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    switch (matrix[row][col])
                    {
                        case '>': GoRigth(matrix, row, col); break;
                        case '<': GoLeft(matrix, row, col); break;
                        case 'v': GoDown(matrix, row, col); break;
                        case '^': GoUp(matrix, row, col); break;
                    }
                }
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine($"<p>{SecurityElement.Escape(string.Join("", row))}</p>");
                //Console.WriteLine($"<p>{SecurityElement.Escape(new string(row))}</p>");
            }
        }

        private static void GoRigth(List<char[]> matrix, int row, int startingCol)
        {
            for (int col = startingCol + 1; col < matrix[row].Length; col++)
            {
                if (symbols.Contains(matrix[row][col]))
                {
                    break;
                }

                matrix[row][col] = ' ';
            }
        }

        private static void GoLeft(List<char[]> matrix, int row, int startingCol)
        {
            for (int col = startingCol - 1; col >= 0; col--)
            {
                if (symbols.Contains(matrix[row][col]))
                {
                    break;
                }

                matrix[row][col] = ' ';
            }
        }

        private static void GoUp(List<char[]> matrix, int startingRow, int col)
        {
            for (int row = startingRow - 1; row >= 0; row--)
            {
                if (symbols.Contains(matrix[row][col]))
                {
                    break;
                }

                matrix[row][col] = ' ';
            }
        }

        private static void GoDown(List<char[]> matrix, int startingRow, int col)
        {
            for (int row = startingRow + 1; row < matrix.Count; row++)
            {
                if (symbols.Contains(matrix[row][col]))
                {
                    break;
                }

                matrix[row][col] = ' ';
            }
        }
    }
}