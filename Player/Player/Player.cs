using System.Numerics;

namespace Player
{
    public class Player
    {
        public int Arrows { get; set; } = 3;
        public int GoldCoins { get; set; } = 0;
        public int Turns { get; set; } = 0;
        public int UpdateScore { get; set; } = 0;
        // Player starts alive and the Wumpus starts alive
        public bool IsAlive { get; set; } = true;
        public bool WumpusAlive { get; set; } = true;

        public int GetScore()
        {
            // Score never drops below 0
            int Score = Math.Max(0, 100 - Turns + GoldCoins + (5 * Arrows));
            if (!WumpusAlive)
            {
                Score += 50; // Bonus for killing the Wumpus
            }           
            return Score;
        }
        public void ShootArrow()
        {
            if (!IsAlive) return;

            if (Arrows > 0)
            {
                Arrows--;
                Console.WriteLine("You shot an arrow");
            }
            else
            {
                Console.WriteLine("You have no arrows left. The Wumpus eats you and you die");
                IsAlive = false;
            }
            UpdateScore = GetScore();
        }
        public bool EncounterWumpus()
        {
            if (Arrows <= 0)
            {
                Console.WriteLine("You have no arrows left. The Wumpus eats you and you die");
                IsAlive = false;
                UpdateScore = GetScore();
                return false;
            }
            
            Arrows--;
            UpdateScore = GetScore();
            return true; // Arrow was used
        }
        public bool Gold_Arrows()
        {
            if (GoldCoins > 0)
            {
                // If you have gold coins, you can use the coin in exchange for an arrow
                GoldCoins--;
                Arrows++;
                UpdateScore = GetScore();
                return true;
            }
            else
            {
                Console.WriteLine("You have no gold coins left");
                UpdateScore = GetScore();
                return false;
            }
        }

        public void TakeTurn()
        {
            if (!IsAlive) return;
            Turns++;
            UpdateScore = GetScore();
        }
        public void Display()
        {
            Console.WriteLine($"Arrows: {Arrows}");
            Console.WriteLine($"Gold Coins: {GoldCoins}");
            Console.WriteLine($"Turns: {Turns}");
            Console.WriteLine($"Score: {UpdateScore}");
            Console.WriteLine($"Status: {(IsAlive ? "Alive" : "Dead")}");
        }
    }
}





    


