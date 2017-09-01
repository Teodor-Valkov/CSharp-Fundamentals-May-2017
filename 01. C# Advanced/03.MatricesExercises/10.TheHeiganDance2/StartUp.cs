namespace _10.TheHeiganDance2
{
    using System;

    internal class StartUp
    {
        private const int ChamberSize = 15;
        private const int CloudDamage = 3500;
        private const int ErruptionDamage = 6000;
        private static double PlayerHealth = 18500;
        private static double HeiganHealth = 3000000;
        private static int PlayerRow = 7;
        private static int PlayerCol = 7;

        private static void Main()
        {
            double averageDamage = double.Parse(Console.ReadLine());

            bool isHeiganDead = false;
            bool isPlayerDead = false;
            bool hasCloud = false;

            string deathCause = string.Empty;
            while (true)
            {
                string attack = Console.ReadLine();

                string[] attackArgs = attack.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string attackType = attackArgs[0];
                int attackRow = int.Parse(attackArgs[1]);
                int attackCol = int.Parse(attackArgs[2]);

                HeiganHealth -= averageDamage;

                if (HeiganHealth <= 0)
                {
                    isHeiganDead = true;
                }

                if (hasCloud)
                {
                    PlayerHealth -= CloudDamage;
                    hasCloud = false;
                    if (PlayerHealth <= 0)
                    {
                        isPlayerDead = true;
                    }
                }

                if (isPlayerDead || isHeiganDead)
                {
                    break;
                }

                if (IsPlayerInDamageArea(attackRow, attackCol))
                {
                    if (!IsPlayerEscapingDamageArea(attackRow, attackCol))
                    {
                        switch (attackType)
                        {
                            case "Cloud":
                                PlayerHealth -= CloudDamage;
                                hasCloud = true;
                                deathCause = "Plague Cloud";
                                break;

                            case "Eruption":
                                PlayerHealth -= ErruptionDamage;
                                deathCause = "Eruption";
                                break;
                        }
                    }
                }

                if (PlayerHealth <= 0)
                {
                    isPlayerDead = true;
                }

                if (isPlayerDead)
                {
                    break;
                }
            }

            PrintResult(isHeiganDead, isPlayerDead, deathCause);
        }

        private static bool IsPlayerInDamageArea(int attackRow, int attackCol)
        {
            bool isHitRow = PlayerRow >= attackRow - 1 && PlayerRow <= attackRow + 1;
            bool isHitCol = PlayerCol >= attackCol - 1 && PlayerCol <= attackCol + 1;

            return isHitRow && isHitCol;
        }

        private static bool IsPlayerEscapingDamageArea(int attackRow, int attackCol)
        {
            int attackMinRow = attackRow - 1;
            int attackMaxRow = attackRow + 1;

            int attackMinCol = attackCol - 1;
            int attackMaxCol = attackCol + 1;

            if (PlayerRow - 1 >= 0 && PlayerRow - 1 < attackMinRow)
            {
                PlayerRow--;
                return true;
            }

            if (PlayerCol + 1 < ChamberSize && PlayerCol + 1 > attackMaxCol)
            {
                PlayerCol++;
                return true;
            }

            if (PlayerRow + 1 < ChamberSize && PlayerRow + 1 > attackMaxRow)
            {
                PlayerRow++;
                return true;
            }

            if (PlayerCol - 1 >= 0 && PlayerCol - 1 < attackMinCol)
            {
                PlayerCol--;
                return true;
            }

            return false;
        }

        private static void PrintResult(bool isHeiganDead, bool isPlayerDead, string deathCause)
        {
            Console.WriteLine(isHeiganDead
                ? "Heigan: Defeated!"
                : $"Heigan: {HeiganHealth:F2}");

            Console.WriteLine(isPlayerDead
                ? $"Player: Killed by {deathCause}"
                : $"Player: {PlayerHealth}");

            Console.WriteLine($"Final position: {PlayerRow}, {PlayerCol}");
        }
    }
}