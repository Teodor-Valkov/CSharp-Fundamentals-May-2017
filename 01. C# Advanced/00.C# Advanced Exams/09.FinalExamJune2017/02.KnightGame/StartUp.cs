namespace _02.KnightGame
{
    using System;

    internal class StartUp
    {
        private static int result = 0;
        private static char[][] matrix;

        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int rows = size;
            int cols = size;

            matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            // Start from highest to lowest possible threats and check each knight
            for (int i = 8; i >= 1; i--)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            CheckCurrentKnight(row, col, size, i);
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }

        private static void CheckCurrentKnight(int row, int col, int size, int currentRound)
        {
            int removed = 0;

            //up left
            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (matrix[row - 2][col - 1] == 'K')
                {
                    removed++;
                }
            }

            // up right
            if (row - 2 >= 0 && col + 1 < size)
            {
                if (matrix[row - 2][col + 1] == 'K')
                {
                    removed++;
                }
            }

            // down left
            if (row + 2 < size && col - 1 >= 0)
            {
                if (matrix[row + 2][col - 1] == 'K')
                {
                    removed++;
                }
            }

            // down right
            if (row + 2 < size && col + 1 < size)
            {
                if (matrix[row + 2][col + 1] == 'K')
                {
                    removed++;
                }
            }

            //left up
            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (matrix[row - 1][col - 2] == 'K')
                {
                    removed++;
                }
            }

            //right up
            if (row - 1 >= 0 && col + 2 < size)
            {
                if (matrix[row - 1][col + 2] == 'K')
                {
                    removed++;
                }
            }

            //left down
            if (row + 1 < size && col - 2 >= 0)
            {
                if (matrix[row + 1][col - 2] == 'K')
                {
                    removed++;
                }
            }

            //right down
            if (row + 1 < size && col + 2 < size)
            {
                if (matrix[row + 1][col + 2] == 'K')
                {
                    removed++;
                }
            }

            // Remove the knight if he threats the highest possible number of knights
            if (currentRound == removed)
            {
                result++;
                matrix[row][col] = '0';
            }
        }
    }
}