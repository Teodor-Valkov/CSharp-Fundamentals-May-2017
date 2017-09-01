namespace _02.DiagonalDifference
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int rows = size;
            int cols = size;

            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int leftDiagonalSum = 0;
            int rightDiagonalSum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == col)
                    {
                        leftDiagonalSum += matrix[row][col];
                    }
                    if (col == cols - row - 1)
                    {
                        rightDiagonalSum += matrix[row][col];
                    }
                }
            }

            int difference = Math.Abs(leftDiagonalSum - rightDiagonalSum);
            Console.WriteLine(difference);
        }
    }
}