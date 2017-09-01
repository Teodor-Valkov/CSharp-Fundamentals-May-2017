namespace _21.ItVillage2
{
    using System;
    using System.Linq;
    using System.Text;

    internal class StartUp
    {
        private static bool winByForce;
        private static bool winByHotels;
        private static bool lossByCoins;

        private static void Main()
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            int[] startingRowAndCol = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] moves = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string board = FillBoard(inputArgs);
            int allHotels = board.Count(symbol => symbol == 'I');

            int index = FindStartingIndex(startingRowAndCol);

            long coins = 50;
            int hotels = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                coins += hotels * 20;

                index = (index + moves[i]) % board.Length;

                switch (board[index])
                {
                    case 'P':
                        coins -= 5;
                        break;

                    case 'I':
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

                    case 'F':
                        coins += 20;
                        break;

                    case 'S':
                        i += 2;
                        break;

                    case 'V':
                        coins *= 10;
                        break;
                }

                if (board[index] == 'N')
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

        private static string FillBoard(string[] inputArgs)
        {
            StringBuilder sb = new StringBuilder();
            string last = string.Empty;
            string beforeLast = string.Empty;

            for (int row = 0; row < 4; row++)
            {
                string[] args = inputArgs[row].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string currentRow = string.Join("", args);

                if (row == 0)
                {
                    sb.Append(currentRow);
                }

                if (row == 1)
                {
                    last = currentRow[0].ToString();
                    sb.Append(currentRow[3]);
                }

                if (row == 2)
                {
                    beforeLast = currentRow[0].ToString();
                    sb.Append(currentRow[3]);
                }

                if (row == 3)
                {
                    char[] temp = currentRow.ToCharArray();
                    Array.Reverse(temp);

                    sb.Append(temp);
                    sb.Append(beforeLast);
                    sb.Append(last);
                }
            }

            return sb.ToString();
        }

        private static int FindStartingIndex(int[] startingRowAndCol)
        {
            int index = 0;

            int row = startingRowAndCol[0] - 1;
            int col = startingRowAndCol[1] - 1;

            if (row == 0)
            {
                index = col;
            }
            else if (row == 1)
            {
                if (col == 0)
                {
                    index = 11;
                }
                else if (col == 3)
                {
                    index = 4;
                }
            }
            else if (row == 2)
            {
                if (col == 0)
                {
                    index = 10;
                }
                else if (col == 3)
                {
                    index = 5;
                }
            }
            else if (row == 3)
            {
                if (col == 0)
                {
                    index = 9;
                }
                else if (col == 1)
                {
                    index = 8;
                }
                else if (col == 2)
                {
                    index = 7;
                }
                else if (col == 3)
                {
                    index = 6;
                }
            }

            return index;
        }
    }
}