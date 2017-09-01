namespace _02.RadioactiveBunnies
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
                    matrix[playerRow][playerCol] = '.';
                }
            }

            string directions = Console.ReadLine();

            foreach (char move in directions)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;

                switch (move)
                {
                    case 'U': playerRow--; break;
                    case 'D': playerRow++; break;
                    case 'L': playerCol--; break;
                    case 'R': playerCol++; break;
                }

                matrix = SpreadBunnies(rows - 1, cols - 1);

                if (playerRow < 0 || playerRow >= rows ||
                    playerCol < 0 || playerCol >= cols)
                {
                    PrintResult(oldPlayerRow, oldPlayerCol, "won");
                    return;
                }

                if (matrix[playerRow][playerCol] == 'B')
                {
                    PrintResult(playerRow, playerCol, "dead");
                    return;
                }
            }
        }

        private static char[][] SpreadBunnies(int rows, int cols)
        {
            char[][] tempMatrix = new char[matrix.Length][];

            for (int row = 0; row < matrix.Length; row++)
            {
                tempMatrix[row] = (char[])matrix[row].Clone();
            }

            for (int row = 0; row <= rows; row++)
            {
                for (int col = 0; col <= cols; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        if (row > 0)
                        {
                            tempMatrix[row - 1][col] = 'B';
                        }

                        if (row < rows)
                        {
                            tempMatrix[row + 1][col] = 'B';
                        }

                        if (col > 0)
                        {
                            tempMatrix[row][col - 1] = 'B';
                        }

                        if (col < cols)
                        {
                            tempMatrix[row][col + 1] = 'B';
                        }
                    }
                }
            }

            return tempMatrix;
        }

        private static void PrintResult(int playerRow, int playerCol, string result)
        {
            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }

            Console.WriteLine($"{result}: {playerRow} {playerCol}");
        }
    }
}