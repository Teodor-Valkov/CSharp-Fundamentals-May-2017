namespace _08.TextGravity
{
    using System;
    using System.Security;

    internal class StartUp
    {
        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int rows = (int)Math.Ceiling((double)input.Length / size);
            int cols = size;
            char[][] matrix = new char[rows][];

            FillMatrix(input, rows, cols, matrix);

            UpdateMatrix(rows, cols, matrix);

            PrintMatrix(rows, cols, matrix);
        }

        private static void FillMatrix(string input, int rows, int cols, char[][] matrix)
        {
            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                for (int col = 0; col < cols; col++)
                {
                    if (counter >= input.Length)
                    {
                        matrix[row][col] = ' ';
                    }
                    else
                    {
                        matrix[row][col] = input[counter++];
                    }
                }
            }
        }

        private static void UpdateMatrix(int rows, int cols, char[][] matrix)
        {
            // Solution I
            //
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

            // Solution II
            //
            bool fallen;

            do
            {
                fallen = false;
                for (int row = 0; row < rows - 1; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row][col] != ' ' && matrix[row + 1][col] == ' ')
                        {
                            matrix[row + 1][col] = matrix[row][col];
                            matrix[row][col] = ' ';
                            fallen = true;
                        }
                    }
                }
            } while (fallen);
        }

        private static void PrintMatrix(int rows, int cols, char[][] matrix)
        {
            Console.Write("<table>");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("<tr>");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"<td>{SecurityElement.Escape(matrix[row][col].ToString())}</td>");
                }
                Console.Write("</tr>");
            }
            Console.WriteLine("</table>");
        }
    }
}