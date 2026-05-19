namespace Player
{
    public class Player
    {
        public int Arrows { get; set; }
        public int GoldCoins { get; set; }
        public int Turns { get; set; }
        public int EndingScore { get; set; }
        public bool IsAlive { get; set; } = true;

        public Player()
        {
            Arrows = 3;
            GoldCoins = 0;
            Turns = 0;
            EndingScore = 0;
            
        }

        public int Score()
        {
            // Score never drops below 0
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
