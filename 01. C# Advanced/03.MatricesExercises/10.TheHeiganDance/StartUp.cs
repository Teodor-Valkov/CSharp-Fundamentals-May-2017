namespace _10.TheHeiganDance
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            double heiganHealth = 3000000;
            double playerHealth = 18500;

            bool isHeiganDead = false;
            bool isPlayerDead = false;

            bool hasCloud = false;
            string causeOfDeath = string.Empty;

            int playerRow = 7;
            int playerCol = 7;

            double averageDamage = double.Parse(Console.ReadLine());

            while (true)
            {
                string attack = Console.ReadLine();

                string[] attackArgs = attack.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int attackRow = int.Parse(attackArgs[1]);
                int attackCol = int.Parse(attackArgs[2]);

                heiganHealth -= averageDamage;

                if (heiganHealth <= 0)
                {
                    isHeiganDead = true;
                }

                if (hasCloud)
                {
                    playerHealth -= 3500;
                    hasCloud = false;

                    causeOfDeath = "Plague Cloud";
                    if (playerHealth <= 0)
                    {
                        isPlayerDead = true;
                    }
                }

                if (isHeiganDead || isPlayerDead)
                {
                    break;
                }

                Dictionary<string, int> damageArea = GetDamageArea(attackRow, attackCol);

                if (IsPlayerInDamageZone(damageArea, playerRow, playerCol))
                {
                    if (playerRow > 0 && playerRow == damageArea["minRow"])
                    {
                        playerRow--;
                    }
                    else if (playerCol < 15 && playerCol == damageArea["maxCol"])
                    {
                        playerCol++;
                    }
                    else if (playerRow < 15 && playerRow == damageArea["maxRow"])
                    {
                        playerRow++;
                    }
                    else if (playerCol > 0 && playerCol == damageArea["minCol"])
                    {
                        playerCol--;
                    }
                }

                if (IsPlayerInDamageZone(damageArea, playerRow, playerCol))
                {
                    if (attackArgs[0].ToLower() == "cloud")
                    {
                        playerHealth -= 3500;
                        hasCloud = true;
                        causeOfDeath = "Plague Cloud";
                    }
                    else
                    {
                        playerHealth -= 6000;
                        causeOfDeath = "Eruption";
                    }
                }

                if (playerHealth <= 0)
                {
                    isPlayerDead = true;
                }

                if (isPlayerDead)
                {
                    break;
                }
            }

            Console.WriteLine(isHeiganDead
                ? "Heigan: Defeated!"
                : $"Heigan: {heiganHealth:F2}");

            Console.WriteLine(isPlayerDead
                ? $"Player: Killed by {causeOfDeath}"
                : $"Player: {playerHealth}");

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static bool IsPlayerInDamageZone(Dictionary<string, int> damagePositions, int playerRow, int playerCol)
        {
            bool isInHitRow = playerRow >= damagePositions["minRow"] &&
                              playerRow <= damagePositions["maxRow"];

            bool isInHitCol = playerCol >= damagePositions["minCol"] &&
                              playerCol <= damagePositions["maxCol"];

            return isInHitRow && isInHitCol;
        }

        private static Dictionary<string, int> GetDamageArea(int attackRow, int attackCol)
        {
            Dictionary<string, int> damagePositions = new Dictionary<string, int>
            {
                {"minRow", attackRow - 1},
                {"maxRow", attackRow + 1},
                {"minCol", attackCol - 1},
                {"maxCol", attackCol + 1}
            };

            return damagePositions;
        }
    }
}