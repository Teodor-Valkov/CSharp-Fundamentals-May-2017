namespace _06.TargetPractice
{
    using System;

    internal class StartUp
    {
        private static char[][] matrix = new char[rows][];
        private static int rows;
        private static int cols;

        private static void Main()
        {
            string[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string snake = Console.ReadLine();
            string[] shotArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            rows = int.Parse(rowsAndCols[0]);
            cols = int.Parse(rowsAndCols[1]);

            int impactRow = int.Parse(shotArgs[0]);
            int impactCol = int.Parse(shotArgs[1]);
            int shotRadius = int.Parse(shotArgs[2]);

            FillMatrix(snake);

            FireShot(impactRow, impactCol, shotRadius);

            DropCharacters();

            PrintMatrix();
        }

        private static void FillMatrix(string snake)
        {
            matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
            }

            bool isMovingLeft = true;
            int currentSymbolIndex = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                int col = isMovingLeft ? cols - 1 : 0;
                int colUpdate = isMovingLeft ? -1 : 1;

                while (0 <= col && col < cols)
                {
                    if (currentSymbolIndex >= snake.Length)
                    {
                        currentSymbolIndex = 0;
                    }

                    matrix[row][col] = snake[currentSymbolIndex];

                    currentSymbolIndex++;
                    col += colUpdate;
                }

                isMovingLeft = !isMovingLeft;
            }
        }

        private static void FireShot(int impactRow, int impactCol, int shotRadius)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (IsInsideRadius(row, col, impactRow, impactCol, shotRadius))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static bool IsInsideRadius(int row, int col, int impactRow, int impactCol, int shotRadius)
        {
            int deltaRow = row - impactRow;
            int deltaCol = col - impactCol;

            bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

            return isInRadius;
        }

        private static void DropCharacters()
        {
            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        continue;
                    }

                    int currentRow = row - 1;
                    while (currentRow >= 0)
                    {
                        if (matrix[currentRow][col] != ' ')
                        {
                            matrix[row][col] = matrix[currentRow][col];
                            matrix[currentRow][col] = ' ';
                            break;
                        }

                        currentRow--;
                    }
                }
            }
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
    }
}