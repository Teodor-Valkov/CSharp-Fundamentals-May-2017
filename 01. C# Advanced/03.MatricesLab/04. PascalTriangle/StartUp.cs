namespace _04.PascalTriangle
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] matrix = new long[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new long[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    if (col == 0)
                    {
                        matrix[row][col] = 1;
                    }
                    else if (col == row)
                    {
                        matrix[row][col] = 1;
                    }
                    else
                    {
                        matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                    }
                }
            }

            foreach (long[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}