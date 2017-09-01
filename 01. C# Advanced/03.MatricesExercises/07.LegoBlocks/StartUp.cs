namespace _07.LegoBlocks
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static int[][] firstMatrix = new int[rows][];
        private static int[][] secondMatrix = new int[rows][];
        private static int rows;
        private static int cellsCount;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());

            firstMatrix = FillMatrix();
            secondMatrix = FillMatrix();

            bool isMatrixesFittingEachOther = CheckIfArraysFit();

            if (!isMatrixesFittingEachOther)
            {
                Console.WriteLine($"The total number of cells is: {cellsCount}");
            }
            else
            {
                PrintMatrix();
            }
        }

        private static int[][] FillMatrix()
        {
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            return matrix;
        }

        private static bool CheckIfArraysFit()
        {
            int a = firstMatrix[0].Length;
            int b = secondMatrix[0].Length;
            int c = a + b;

            cellsCount = c;
            bool fitting = true;

            for (int row = 1; row < rows; row++)
            {
                a = firstMatrix[row].Length;
                b = secondMatrix[row].Length;
                cellsCount += a + b;

                if (a + b != c)
                {
                    fitting = false;
                }
            }

            return fitting;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                Array.Reverse(secondMatrix[row]);
                Console.WriteLine($"[{string.Join(", ", firstMatrix[row])}, {string.Join(", ", secondMatrix[row])}]");
            }
        }
    }
}