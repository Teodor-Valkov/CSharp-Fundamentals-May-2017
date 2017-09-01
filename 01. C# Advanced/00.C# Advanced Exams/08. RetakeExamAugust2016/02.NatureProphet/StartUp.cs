namespace _02.NatureProphet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
                    matrix[row][col] = 0;
                }
            }

            List<int[]> targets = new List<int[]>();

            string input = string.Empty;
            while ((input = Console.ReadLine()).ToLower() != "bloom bloom plow")
            {
                targets.Add(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }

            targets = targets.OrderBy(target => target[0]).ThenBy(target => target[1]).ToList();

            foreach (int[] target in targets)
            {
                int targetRow = target[0];
                int targetCol = target[1];

                for (int row = 0; row < rows; row++)
                {
                    matrix[row][targetCol]++;
                }

                for (int col = 0; col < cols; col++)
                {
                    matrix[targetRow][col]++;
                }

                matrix[targetRow][targetCol]--;
            }

            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sb.Append(matrix[row][col] + " ");
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }
    }
}