namespace _09.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Cell
    {
        public Cell(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Value { get; set; }
    }

    internal class StartUp
    {
        private static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            List<List<Cell>> matrix = FillMatrix(rows, cols);

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "nuke it from orbit")
            {
                int[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int targetRow = inputArgs[0];
                int targetCol = inputArgs[1];
                int radius = inputArgs[2];

                foreach (List<Cell> row in matrix)
                {
                    for (int col = 0; col < row.Count; col++)
                    {
                        Cell cell = row[col];
                        int distance = 0;

                        bool isEligibleForDestruction = cell.Row == targetRow || cell.Col == targetCol;

                        if (isEligibleForDestruction)
                        {
                            if (cell.Row == targetRow)
                            {
                                distance = Math.Abs(cell.Col - targetCol);
                            }

                            if (cell.Col == targetCol)
                            {
                                distance = Math.Abs(cell.Row - targetRow);
                            }

                            if (distance <= radius)
                            {
                                row.Remove(cell);

                                // Reduce the 'col' so the next cell remains at same index
                                if (cell.Row == targetRow)
                                {
                                    col--;
                                }
                            }
                        }
                    }
                }

                ClearUp(matrix);
            }

            PrintMatrix(matrix);
        }

        private static List<List<Cell>> FillMatrix(int rows, int cols)
        {
            List<List<Cell>> matrix = new List<List<Cell>>(rows);

            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<Cell>(cols));

                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(new Cell(row, col, row * cols + col + 1));
                }
            }

            return matrix;
        }

        // Method to remove empty lines and update cell coordinates
        private static void ClearUp(List<List<Cell>> matrix)
        {
            int row = 0;

            while (row < matrix.Count)
            {
                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                }
                else
                {
                    int col = 0;

                    while (col < matrix[row].Count)
                    {
                        matrix[row][col].Row = row;
                        matrix[row][col].Col = col++;
                    }

                    row++;
                }
            }
        }

        private static void PrintMatrix(List<List<Cell>> matrix)
        {
            foreach (List<Cell> row in matrix)
            {
                foreach (Cell cell in row)
                {
                    Console.Write($"{cell.Value} ");
                }

                Console.WriteLine();
            }
        }
    }
}