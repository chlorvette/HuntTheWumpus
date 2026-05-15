using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class PlayerManager
    {
        public int Arrows { get; set; }
        public int GoldCoins { get; set; }
        public int Turns { get; set; }
        public int EndingScore { get; set; }

        public PlayerManager()
        {
            Arrows = 3;
            GoldCoins = 0;
            Turns = 0;
            EndingScore = 0;    

        }
        public PlayerManager(int arrows, int goldCoins, int turns, int endingScore)
        {
            Arrows = arrows;
            GoldCoins = goldCoins;
            Turns = turns;
            EndingScore = endingScore;
        }

    }
}
