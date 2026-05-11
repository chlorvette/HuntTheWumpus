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
            Arrows--;
            // Return

        }
        public bool EncounterWumpus()
        {
            // Answer Trivia
            // Lose coin
            return false;
        }
        public int Score()
        {
            EndingScore = (GoldCoins * 10) - (Turns * 1);
            return EndingScore;
        }
       
           
    }

   
}
