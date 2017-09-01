namespace _01.MatrixOfPalindromes
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

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{alphabet[row]}{alphabet[row + col]}{alphabet[row]} ");
                }

                Console.WriteLine();
            }
        }
    }
}