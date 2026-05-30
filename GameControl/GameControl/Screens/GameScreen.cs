using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

namespace GameControlUI.Screens
{
    partial class GameScreen
    {
        partial void CustomInitialize()
        {
        
        }

        public void UpdateStatistics(int roomNumber, int turn, int coins, int arrows)
        {
            roomNumberDisplay.Text = "room " + roomNumber.ToString();
            turnNumberDisplay.Text = "turn " + turn.ToString();
            numberOfCoinsDisplay.Text = coins.ToString() + " coin" + (coins == 1 ? "":"s");
            numberOfArrowsDisplay.Text = arrows.ToString() + " arrow" + (arrows == 1 ? "":"s");
        }
    }
}
