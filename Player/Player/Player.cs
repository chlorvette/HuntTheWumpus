namespace Player
{
    public class Player
    {
        public int Arrows { get; set; }
        public int GoldCoins { get; set; }
        public int Turns { get; set; }
        public int EndingScore { get; set; }

        public Player() 
        {
            Arrows = 3; 
            GoldCoins = 0;
            Turns = 0;
            EndingScore = 0;
        }
        public int TakeTurns()
        {
            Turns++;
            return Turns;

        }
        public int ShootArrow()
        {
            if (Arrows > 0)
            {
                Arrows--;
                return Arrows;
            }
            return Arrows;
               
        }

        public (int, int) GainArrow(bool PassTrivia)
        {
            if (PassTrivia) // Pretend method for Trivia
            {
                Arrows++;
                GoldCoins--;
                return (Arrows, GoldCoins);
  
            }
            else
            {
                // else lose Triva then won't gain arrrow
                Arrows--;
                return (Arrows, GoldCoins);
            }
        }


        public bool EncounterWumpus()
        {
            Arrows--;
            return false;
        }
        public int Score()
        {
            EndingScore = (GoldCoins * 10) - (Turns * 1);
            return EndingScore;
        }
        public void DisplayRepository()
        {
            Console.WriteLine($"Arrows: {Arrows}");
            Console.WriteLine($"Gold Coins: {GoldCoins}");
            Console.WriteLine($"Turns: {Turns}");
            Console.WriteLine($"Ending Score: {EndingScore}");
        }
       
           
    }

   
}
