namespace Player
{
    public class Player
    {
        public int Arrows { get; set; }
        public int GoldCoins { get; set; }
        public int Turns { get; set; }
        public int EndingScore { get; set; }
        public bool IsAlive { get; set; } = true;
        public bool WumpuseAlive { get; set; } = true;

        public Player()
        {
            Arrows = 3;
            GoldCoins = 0;
            Turns = 0;
            IsAlive = true;
            WumpuseAlive = true;
            EndingScore = 0;
            
        }
        public int GetScore(bool WumpusAlive)
        {
            // Score never drops below 0
            EndingScore = Math.Max(0, 100 - Turns + GoldCoins + (5 * Arrows));
            if (!WumpusAlive)
            {
                EndingScore += 50; // Bonus for killing the Wumpus
            }
            return EndingScore;
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
            GetScore(WumpuseAlive);
        }
        public bool EncounterWumpus()
        {
            if (Arrows <= 0)
            {
                Console.WriteLine("You have no arrows left. The Wumpus eats you and you die");
                IsAlive = false;
                GetScore(WumpuseAlive);
                return false;
            }
            
            Arrows--;
            GetScore(WumpuseAlive);
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
                GetScore(WumpuseAlive);
                return false;
            }
        }

        public void TakeTurn()
        {
            if (!IsAlive) return;
            Turns++;
            GetScore(WumpuseAlive);
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





    


