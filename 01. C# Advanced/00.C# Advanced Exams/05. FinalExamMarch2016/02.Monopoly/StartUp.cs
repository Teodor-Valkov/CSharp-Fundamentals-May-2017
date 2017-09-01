namespace _02.Monopoly
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                char[] cells = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }

            int turns = 0;
            int money = 50;
            int hotels = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    int col = row % 2 == 0 ? column : cols - column - 1;

                    switch (matrix[row, col])
                    {
                        case 'H':
                            hotels++;
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                            money = 0;
                            break;

                        case 'J':
                            Console.WriteLine($"Gone to jail at turn {turns}.");
                            money += hotels * 20;
                            turns += 2;
                            break;

                        case 'S':
                            int moneyToSpend = Math.Min((row + 1) * (col + 1), money);
                            Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                            money -= moneyToSpend;
                            break;
                    }

                    money += hotels * 10;
                    turns++;
                }
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }
    }
}