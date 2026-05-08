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
            Arrows--;
            return Arrows;
        }
        public int GainArrow()
        {
            if (AskTriviaQuestion()) // Pretend method for Trivia
            {
                Arrows++;
                GoldCoins--;
                return Arrows;
            }
            else
            {
                // else lose Triva then won't gain arrrow
                Arrows--;
                return Arrows;
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
       
           
    }

   
}
