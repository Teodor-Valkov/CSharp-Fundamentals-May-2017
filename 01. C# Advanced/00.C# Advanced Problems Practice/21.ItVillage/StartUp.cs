namespace _21.ItVillage
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static int allHotels;
        private static int currentRow;
        private static int currentCol;
        private static bool winByForce;
        private static bool winByHotels;
        private static bool lossByCoins;

        private static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            int[] currentRowAndCol = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] moves = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[,] matrix = new string[4, 4];

            FillMatrix(inputArgs, matrix);

            long coins = 50;
            int hotels = 0;
            currentRow = currentRowAndCol[0] - 1;
            currentCol = currentRowAndCol[1] - 1;

            for (int i = 0; i < moves.Length; i++)
            {
                coins += hotels * 20;

                MovingToNextIndex(moves[i]);

                ActionInNextIndex(matrix, ref coins, ref hotels, ref i);

                if (matrix[currentRow, currentCol] == "N")
                {
                    winByForce = true;
                    break;
                }

                if (allHotels == hotels)
                {
                    winByHotels = true;
                    break;
                }

                if (coins < 0)
                {
                    lossByCoins = true;
                    break;
                }
            }

            if (lossByCoins)
            {
                Console.WriteLine($"<p>You lost! You ran out of money!<p>");
            }
            else if (winByHotels)
            {
                Console.WriteLine($"<p>You won! You own the village now! You have {coins} coins!<p>");
            }
            else if (winByForce)
            {
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
            }
            else
            {
                Console.WriteLine($"<p>You lost! No more moves! You have {coins} coins!<p>");
            }
        }

        private static void FillMatrix(string[] inputArgs, string[,] matrix)
        {
            for (int row = 0; row < 4; row++)
            {
                string[] args = inputArgs[row].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < 4; col++)
                {
                    matrix[row, col] = args[col];

                    if (matrix[row, col] == "I")
                    {
                        allHotels++;
                    }
                }
            }
        }

        private static void MovingToNextIndex(int move)
        {
            int counter = 0;

            while (counter != move)
            {
                counter++;

                if (currentRow == 0)
                {
                    currentCol++;

                    if (currentCol == 4)
                    {
                        currentRow = 1;
                        currentCol = 3;
                    }
                }
                else if (currentCol == 3)
                {
                    currentRow++;

                    if (currentRow == 4)
                    {
                        currentRow = 3;
                        currentCol = 2;
                    }
                }
                else if (currentRow == 3)
                {
                    currentCol--;

                    if (currentCol == -1)
                    {
                        currentRow = 2;
                        currentCol = 0;
                    }
                }
                else if (currentCol == 0)
                {
                    currentRow--;

                    if (currentRow == -1)
                    {
                        currentRow = 0;
                        currentCol = 1;
                    }
                }
            }
        }

        private static void ActionInNextIndex(string[,] matrix, ref long coins, ref int hotels, ref int i)
        {
            switch (matrix[currentRow, currentCol])
            {
                case "P":
                    coins -= 5;
                    break;

                case "I":
                    if (coins >= 100)
                    {
                        coins -= 100;
                        hotels++;
                    }
                    else
                    {
                        coins -= 10;
                    }
                    break;

                case "F":
                    coins += 20;
                    break;

                case "S":
                    i += 2;
                    break;

                case "V":
                    coins *= 10;
                    break;
            }
        }
    }
}