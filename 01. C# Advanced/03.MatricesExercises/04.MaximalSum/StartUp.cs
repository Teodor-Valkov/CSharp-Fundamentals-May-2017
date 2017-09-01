namespace _04.MaximalSum
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int startRow = 0;
            int startCol = 0;

            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            long maxSum = long.MinValue;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    long sum = CurrentSum(matrix, row, col);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static long CurrentSum(int[][] matrix, int row, int col)
        {
            long sum = 0;

            for (int tempRow = 0; tempRow < 3; tempRow++)
            {
                for (int tempCol = 0; tempCol < 3; tempCol++)
                {
                    sum += matrix[row + tempRow][col + tempCol];
                }
            }
            return sum;
        }
    }
}