using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameControlUI
{
    public class Player
    {
        public int turns { get; set; }
        public int arrows { get; set; }
        public int correctTrivia { get; set; }
        public int coins { get; set; }
        public bool wumpusKilled { get; set; }

        public Player()
        {
            turns = 0;
            arrows = 3;
            correctTrivia = 0;
            coins = 0;
            wumpusKilled = false;
        }
        public Player(int turns, int arrows, int correctTrivia)
        {
            this.turns = turns;
            this.arrows = arrows;
            this.correctTrivia = correctTrivia;
        }
        public void TakeTurn()
        {
            turns++;
            coins++;
        }
        public int CalculateScore()
        {
            return Math.Max(0, (100 - turns + coins + (5 * arrows) + (wumpusKilled ? 50 : 0)));
        }
        public bool UseCoin()
        {
            if (coins == 0) return false;
            else
            {
                coins--;
                return true;
            }
        }
        public bool UseCoin(int coin)
        {
            if (coins - coin < 0) return false;
            else
            {
                coins -= coin;
                return true;
            }
        }
    }
}
