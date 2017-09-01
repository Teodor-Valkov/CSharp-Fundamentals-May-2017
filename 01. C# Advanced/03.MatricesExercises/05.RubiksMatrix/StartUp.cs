namespace _05.RubiksMatrix
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static int[][] matrix = new int[rows][];
        private static int rows;
        private static int cols;

        private static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            rows = rowsAndCols[0];
            cols = rowsAndCols[1];

            matrix = FillMatrix(rows, cols);

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int target = int.Parse(inputArgs[0]);
                string direction = inputArgs[1];
                long moves = long.Parse(inputArgs[2]);

                switch (direction)
                {
                    case "up":
                        MoveUpOrDown(target, moves % rows);
                        break;

                    case "down":
                        MoveUpOrDown(target, rows - moves % rows);
                        break;

                    case "left":
                        MoveLeftOrRight(target, moves % cols);
                        break;

                    case "right":
                        MoveLeftOrRight(target, cols - moves % cols);
                        break;
                }
            }

            RearrangeMatrix();
        }

        private static int[][] FillMatrix(int rows, int cols)
        {
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = row * cols + (col + 1);
                }
            }

            return matrix;
        }

        private static void MoveUpOrDown(int target, long moves)
        {
            int[] temp = new int[matrix.Length];

            for (int row = 0; row < rows; row++)
            {
                temp[row] = matrix[(row + moves) % rows][target];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][target] = temp[row];
            }
        }

        private static void MoveLeftOrRight(int target, long moves)
        {
            int[] temp = new int[cols];

            for (int col = 0; col < cols; col++)
            {
                temp[col] = matrix[target][(col + moves) % cols];
            }

            matrix[target] = temp;
        }

        public static void RearrangeMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int initialValue = row * cols + (col + 1);
                    int currentValue = matrix[row][col];

                    if (initialValue == currentValue)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < rows; r++)
                        {
                            for (int c = 0; c < cols; c++)
                            {
                                if (matrix[r][c] == initialValue)
                                {
                                    matrix[row][col] = initialValue;
                                    matrix[r][c] = currentValue;

                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}