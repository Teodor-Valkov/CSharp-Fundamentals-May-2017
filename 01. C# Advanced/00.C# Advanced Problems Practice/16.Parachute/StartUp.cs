namespace _16.Parachute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static int playerRow;
        private static int playerCol;

        private static int row;
        private static int col;

        private static void Main()
        {
            List<string> matrix = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                if (input.Contains("o"))
                {
                    playerRow = matrix.Count;
                    playerCol = input.IndexOf("o");
                }

                matrix.Add(input);
            }

            FindFinalLocation(matrix);

            PrintResult(matrix);
        }

        private static void FindFinalLocation(List<string> matrix)
        {
            for (int currentRow = playerRow + 1; currentRow < matrix.Count; currentRow++)
            {
                string line = matrix[currentRow];

                int left = line.Count(symbol => symbol == '<');
                int right = line.Count(symbol => symbol == '>');

                playerCol -= left;
                playerCol += right;

                if (matrix[currentRow][playerCol] != '-' && matrix[currentRow][playerCol] != 'o'
                    && matrix[currentRow][playerCol] != '>' && matrix[currentRow][playerCol] != '<')
                {
                    row = currentRow;
                    col = playerCol;
                    break;
                }
            }
        }

        private static void PrintResult(List<string> matrix)
        {
            switch (matrix[row][col])
            {
                case '_':
                    Console.WriteLine("Landed on the ground like a boss!");
                    break;

                case '~':
                    Console.WriteLine("Drowned in the water like a cat!");
                    break;

                case '/':
                case '|':
                case '\\':
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    break;
            }

            Console.WriteLine($"{row} {col}");
        }
    }
}