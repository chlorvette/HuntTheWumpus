namespace Player
{
    public class Player
    {
        public int Arrows { get; set; }
        public int GoldCoins { get; set; }
        public int Turns { get; set; }
        public int EndingScore { get; set; }
        public bool IsAlive { get; private set; } = true; 

        public Player()
        {
            PlayerManager playerManager = new PlayerManager();
            Arrows = playerManager.Arrows;
            GoldCoins = playerManager.GoldCoins;
            Turns = playerManager.Turns;
            EndingScore = playerManager.EndingScore;
        }

        public int TakeTurns()
        {
            if (!IsAlive)
            {
                Console.WriteLine("You lost");
                Score();
                return Turns;
            }
            Turns++;
            return Turns;
        }

        public bool ShootArrow()
        {
            if (Arrows > 0)
            {
                Arrows--;
                return true;
            }
            if (!IsAlive)
            {
                return false;
            } 
            else
            {
                Console.WriteLine("You lost");
                IsAlive = false;
                Score();
                return false;
            }
        }

        public bool GainArrow()
        {
            if (!IsAlive) return false;

            if (Arrows > 0)
            {
                Arrows++;
                GoldCoins--;
                return true;
            }
            else
            {
                Console.WriteLine("You lost");
                IsAlive = false;
                Score();
                return false;
            }
        }

        public bool EncounterWumpus()
        {
            Arrows--;
            if (!IsAlive)
            {
                return false;
            }
            
            if (Arrows < 0)
            {
                Console.WriteLine("You lost");
                IsAlive = false;
                Score();
                return false;
            }
            return true;
        }

        public int Score()
        {
            // Ensures score never drops below 0
            EndingScore = Math.Max(0, (GoldCoins * 10) - (Turns * 1));
            return EndingScore;
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
