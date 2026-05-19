using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class PlayerManager
    {
        private Player _player;
        

        public PlayerManager(Player player)
        {
            _player = player;

        }
        public void ShootArrow()
        {
            if (!_player.IsAlive) return;

            if (_player.Arrows > 0)
            {
                _player.Arrows--;
            }
            else
            {
                Console.WriteLine("You lost");
                _player.IsAlive = false;
            }
            _player.Score();
        }
        public bool EncounterWumpus()
        {
            _player.Arrows--;

            if (_player.Arrows < 0)
            {
                Console.WriteLine("You lost");
                _player.IsAlive = false;
                _player.Score();
                return false;
            }
            return true;
        }
        public bool Gold_Arrows()
        {
            if (!_player.IsAlive)
            {
                return false;
            }

            if (_player.GoldCoins > 0)
            {
                _player.Arrows++;
                _player.GoldCoins--;
                return true;
            }
            else
            {
                Console.WriteLine("You lost");
                _player.IsAlive = false;
                _player.Score();
                return false;
            }
        }

        public void TakeTurn()
        {
            if (!_player.IsAlive) return;
            _player.Turns++;
            _player.Score();
        }
    }
}
    

