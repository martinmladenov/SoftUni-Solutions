namespace _10.The_Heigan_Dance
{
    using System;

    public class TheHeiganDance
    {
        public static void Main()
        {
            double heiganDamage = double.Parse(Console.ReadLine());

            double heiganHealth = 3000000;
            int playerHealth = 18500;

            int playerRow = 7, playerCol = 7;

            bool chamberCloudLastTurn = false;

            string lastDamage = null;

            while (heiganHealth > 0 && playerHealth > 0)
            {
                // Attack Heigan
                heiganHealth -= heiganDamage;

                // Apply spell
                string[] split = Console.ReadLine().Split();
                string spellName = split[0];
                int spellRow = int.Parse(split[1]);
                int spellCol = int.Parse(split[2]);

                bool[,] chamberEruption = new bool[15, 15];
                bool[,] chamberCloud = new bool[15, 15];

                if (heiganHealth > 0)
                {
                    if (spellName == "Cloud")
                    {
                        ApplySpell(spellRow, spellCol, chamberCloud);
                    }
                    else if (spellName == "Eruption")
                    {
                        ApplySpell(spellRow, spellCol, chamberEruption);
                    }
                }

                // Move player
                if (chamberEruption[playerRow, playerCol] ||
                    chamberCloud[playerRow, playerCol])
                {

                    if (playerRow > 0 &&
                        !chamberCloud[playerRow - 1, playerCol] &&
                        !chamberEruption[playerRow - 1, playerCol])
                    {
                        playerRow--;
                    }
                    else if (playerCol < 14 &&
                             !chamberCloud[playerRow, playerCol + 1] &&
                             !chamberEruption[playerRow, playerCol + 1])
                    {
                        playerCol++;
                    }
                    else if (playerRow < 14 &&
                             !chamberCloud[playerRow + 1, playerCol] &&
                             !chamberEruption[playerRow + 1, playerCol])
                    {
                        playerRow++;
                    }
                    else if (playerCol > 0 &&
                             !chamberCloud[playerRow, playerCol - 1] &&
                             !chamberEruption[playerRow, playerCol - 1])
                    {
                        playerCol--;
                    }
                }

                // Damage player

                if (chamberCloudLastTurn && playerHealth > 0)
                {
                    lastDamage = "Plague Cloud";
                    playerHealth -= 3500;
                    chamberCloudLastTurn = false;
                }

                if (chamberCloud[playerRow, playerCol] && playerHealth > 0)
                {
                    lastDamage = "Plague Cloud";
                    playerHealth -= 3500;
                    chamberCloudLastTurn = true;
                }

                if (chamberEruption[playerRow, playerCol] && playerHealth > 0)
                {
                    lastDamage = "Eruption";
                    playerHealth -= 6000;
                }
            }

            if (heiganHealth > 0)
            {
                Console.WriteLine($"Heigan: {heiganHealth:f2}");
            }
            else
            {
                Console.WriteLine("Heigan: Defeated!");
            }

            if (playerHealth > 0)
            {
                Console.WriteLine($"Player: {playerHealth}");
            }
            else
            {
                Console.WriteLine($"Player: Killed by {lastDamage}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static void ApplySpell(int row, int col, bool[,] targetMatrix)
        {
            for (int currRow = row - 1; currRow <= row + 1; currRow++)
            {
                if (currRow < 0 || currRow >= 15)
                    continue;

                for (int currCol = col - 1; currCol <= col + 1; currCol++)
                {
                    if (currCol < 0 || currCol >= 15)
                        continue;

                    targetMatrix[currRow, currCol] = true;
                }
            }

        }
    }
}
