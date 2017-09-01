namespace _02.JedyGalaxy
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = row * cols + col;
                }
            }

            long sum = 0;
            string playerInput = string.Empty;
            while ((playerInput = Console.ReadLine()).ToLower() != "let the force be with you")
            {
                string evilInput = Console.ReadLine();

                int[] playerInputArgs = playerInput.Split().Select(int.Parse).ToArray();
                int playerStartRow = playerInputArgs[0];
                int playerStartCol = playerInputArgs[1];

                int[] evilInputArgs = evilInput.Split().Select(int.Parse).ToArray();
                int evilStartRow = evilInputArgs[0];
                int evilStartCol = evilInputArgs[1];

                while (evilStartRow >= 0 && evilStartCol >= 0)
                {
                    if (IsInMatrix(evilStartRow, evilStartCol, rows, cols))
                    {
                        matrix[evilStartRow][evilStartCol] = 0;
                    }

                    evilStartRow--;
                    evilStartCol--;
                }

                while (playerStartRow >= 0 && playerStartCol < cols)
                {
                    if (IsInMatrix(playerStartRow, playerStartCol, rows, cols))
                    {
                        sum += matrix[playerStartRow][playerStartCol];
                    }

                    playerStartRow--;
                    playerStartCol++;
                }
            }

            Console.WriteLine(sum);
        }

        private static bool IsInMatrix(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}