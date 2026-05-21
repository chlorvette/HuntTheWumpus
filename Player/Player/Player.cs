namespace Player
{
    public class Player
    {

        public int Arrows { get; set; } = 3;
        public int GoldCoins { get; set; } = 0;
        public int Turns { get; set; } = 0;
        public int EndingScore { get; set; } = 0;
        public bool IsAlive { get; set; } = true;
        public bool WumpusAlive { get; set; } = true;

        public Player()
        {

        }
        public int GetScore(bool WumpusAlive)
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
            EndingScore = GetScore(WumpuseAlive);
        }
        public bool EncounterWumpus()
        {
            if (Arrows <= 0)
            {
                Console.WriteLine("You have no arrows left. The Wumpus eats you and you die");
                IsAlive = false;
                EndingScore = GetScore(WumpuseAlive);
                return false;
            }
            
            Arrows--;
            EndingScore = GetScore(WumpuseAlive);
            return true; 
        }
        public bool Gold_Arrows()
        {
            if (GoldCoins > 0)
            {
                // If you have gold coins, you can use the coin in exchange for an arrow
                GoldCoins--;
                Arrows++;
                return true;
            }
            else
            {
                Console.WriteLine("You have no gold coins left");
                EndingScore = GetScore(WumpuseAlive);
                return false;
            }
        }

        public void TakeTurn()
        {
            if (!IsAlive) return;
            Turns++;
            EndingScore = GetScore(WumpuseAlive);
        }

        public void Display()
        {
            Console.WriteLine($"Arrows: {Arrows}");
            Console.WriteLine($"Gold Coins: {GoldCoins}");
            Console.WriteLine($"Turns: {Turns}");
            Console.WriteLine($"Ending Score: {EndingScore}");
            Console.WriteLine($"Status: {(IsAlive ? "Alive" : "Dead")}");
        }
    }
}





    


