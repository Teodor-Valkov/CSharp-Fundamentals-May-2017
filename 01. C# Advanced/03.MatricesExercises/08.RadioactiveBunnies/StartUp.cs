namespace _08.RadioactiveBunnies
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static char[][] matrix = new char[rows][];
        private static int rows;
        private static int cols;

        private static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            rows = rowsAndCols[0];
            cols = rowsAndCols[1];

            matrix = new char[rows][];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

                if (matrix[row].Contains('P'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(matrix[row], 'P');
                }
            }

            int newPlayerRow = 0;
            int newPlayerCol = 0;

            string directions = Console.ReadLine();

            foreach (char move in directions)
            {
                matrix[playerRow][playerCol] = '.';

                switch (move)
                {
                    case 'U':
                        newPlayerRow = playerRow - 1;
                        newPlayerCol = playerCol;
                        break;

                    case 'D':
                        newPlayerRow = playerRow + 1;
                        newPlayerCol = playerCol;
                        break;

                    case 'L':
                        newPlayerRow = playerRow;
                        newPlayerCol = playerCol - 1;
                        break;

                    case 'R':
                        newPlayerRow = playerRow;
                        newPlayerCol = playerCol + 1;
                        break;
                }

                matrix = FillTheMatrixAtTheEndOfTurn();

                if (newPlayerRow < 0 || newPlayerRow >= rows ||
                    newPlayerCol < 0 || newPlayerCol >= cols)
                {
                    PrintMatrix();
                    PrintResult("won", playerRow, playerCol);
                    return;
                }

                if (matrix[newPlayerRow][newPlayerCol] == 'B')
                {
                    PrintMatrix();
                    PrintResult("dead", newPlayerRow, newPlayerCol);
                    return;
                }

                if (matrix[newPlayerRow][newPlayerCol] == '.')
                {
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
            }
        }

        private static char[][] FillTheMatrixAtTheEndOfTurn()
        {
            char[][] tempMatrix = new char[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                tempMatrix[row] = (char[])matrix[row].Clone();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (tempMatrix[row][col] != 'B')
                    {
                        tempMatrix[row][col] = matrix[row][col];
                    }

                    if (matrix[row][col] == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            tempMatrix[row - 1][col] = 'B';
                        }

                        if (row + 1 < rows)
                        {
                            tempMatrix[row + 1][col] = 'B';
                        }

                        if (col - 1 >= 0)
                        {
                            tempMatrix[row][col - 1] = 'B';
                        }

                        if (col + 1 < cols)
                        {
                            tempMatrix[row][col + 1] = 'B';
                        }
                    }
                }
            }

            return tempMatrix;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void PrintResult(string result, int playerRow, int playerCol)
        {
            Console.WriteLine($"{result}: {playerRow} {playerCol}");
        }
    }
}