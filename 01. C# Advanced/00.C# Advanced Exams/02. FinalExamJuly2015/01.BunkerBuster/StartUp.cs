namespace _01.BunkerBuster
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int destroyedCells = 0;

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] cells = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "cease fire!")
            {
                string[] inputArgs = input.Split();
                int targetRow = int.Parse(inputArgs[0]);
                int targetCol = int.Parse(inputArgs[1]);

                int centerPower = Convert.ToChar(inputArgs[2]);
                int neighbourPower = (int)Math.Ceiling((double)centerPower / 2);

                int startingRow = Math.Max(0, targetRow - 1);
                int endingRow = Math.Min(rows - 1, targetRow + 1);

                int startingCol = Math.Max(0, targetCol - 1);
                int endingCol = Math.Min(cols - 1, targetCol + 1);

                for (int row = startingRow; row <= endingRow; row++)
                {
                    for (int col = startingCol; col <= endingCol; col++)
                    {
                        if (row == targetRow && col == targetCol)
                        {
                            matrix[row, col] -= centerPower;
                        }
                        else
                        {
                            matrix[row, col] -= neighbourPower;
                        }
                    }
                }
            }

            foreach (int cell in matrix)
            {
                if (cell <= 0)
                {
                    destroyedCells++;
                }
            }

            double percentage = (double)destroyedCells / (rows * cols) * 100;

            Console.WriteLine($"Destroyed bunkers: {destroyedCells}");
            Console.WriteLine($"Damage done: {percentage:F1} %");
        }
    }
}