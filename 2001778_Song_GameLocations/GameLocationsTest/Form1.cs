using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLocations;

namespace _2001778_Song_GameLocations
{

    public partial class Form1 : Form
    {
        List<int> connectedLocations = new List<int>();
        GameLocations.GameLocations gameLocations = new GameLocations.GameLocations();
        Random random = new Random();


        public Form1()
        {
            InitializeComponent();
           
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            gameLocations.MakeHazardLocations();
            
            gameLocations.SetWumpusLocation();
            richTextBoxLocations.Text = $"Wumpus Location: {gameLocations.WumpusLocation}\nPit Locations: {string.Join(", ", gameLocations.PitLocations)}\nBat Locations: {string.Join(", ", gameLocations.BatLocations)}";
        }

        private void buttonFallIntoPit_Click(object sender, EventArgs e)
        {
            gameLocations.PlayerLocation = gameLocations.PitLocations[0];

            if (gameLocations.IsPitLocation(gameLocations.PlayerLocation))
            { gameLocations.ClimbOutOfPit(); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxPlayerLocation.Text = $"Player Location: {gameLocations.PlayerLocation}";
            textBoxWumpusLocation.Text = $"Wumpus Location: {gameLocations.WumpusLocation}";
            richTextBoxConnectedCaves.Text = $"Connected Caves: {string.Join(", ", connectedLocations)}";
            textBoxWumpusCondition.Text = gameLocations.WumpusIsAwake.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameLocations.SetPlayerStartingLocation();
            textBoxStartingLocation.Text = $"Player Starting Location: {gameLocations.StartingLocation}";
        }

        private void buttonMovePlayer_Click(object sender, EventArgs e)
        {
             gameLocations.MovePlayer(int.Parse(textBoxChosenLocation.Text));
        }

        private void buttonBats_Click(object sender, EventArgs e)
        {
            gameLocations.PlayerLocation = gameLocations.BatLocations[0];
            if (gameLocations.IsBatLocation(gameLocations.PlayerLocation))
            { gameLocations.MovePlayerToRandomLocation(); }
        }

        private void textBoxStartingLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonShootArrow_Click(object sender, EventArgs e)
        {
            labelHit.Text = gameLocations.ShootArrow(int.Parse(textBoxChosenLocation.Text)) ? "Hit!" : "Miss!";
            if (gameLocations.ShootArrow(int.Parse(textBoxChosenLocation.Text))==false)
            {
                
                gameLocations.MoveWumpusAfterArrowMiss(connectedLocations);
            }
        }

        private void buttonGenerateRandomConnected_Click(object sender, EventArgs e)
        {
            //generate random numbers to represent connected locations

            connectedLocations.Clear();
            while (connectedLocations.Count < 3)
            {
                int randomLocation = random.Next(1, 26);
                if (!connectedLocations.Contains(randomLocation))
                {
                    connectedLocations.Add(randomLocation);
                }
            }

        }

        private void buttonWarning_Click(object sender, EventArgs e)
        {
            //this is suppsoed to be the adjacent locations not the connectedLocations but for testing purposes we will just use the connected locations
            richTextBoxWarnings.Text = gameLocations.GetHazardWarning(connectedLocations);
        }

        private void richTextBoxConnectedCaves_TextChanged(object sender, EventArgs e)
        {

        }
        private void GenerateRandomConnectedRooms()
        {
            connectedLocations.Clear();
            while (connectedLocations.Count < 3)
            {
                int randomLocation = random.Next(1, 26);
                if (!connectedLocations.Contains(randomLocation))
                {
                    connectedLocations.Add(randomLocation);
                }
            }
        }

        private void textBoxWumpusLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonWinTrivia_Click(object sender, EventArgs e)
        {
            int numberOfRooms = random.Next(2, 5);
            while (numberOfRooms > 0)
            {
                gameLocations.MoveWumpusToRandomConnectedRoom(connectedLocations);
                //in an actual implementation it would be like this but after you would do like GetTunnels(gameLocations.WumpusLocation) to get the connected rooms and then pass that to the MoveWumpusToRandomConnectedRoom method
                GenerateRandomConnectedRooms();
                numberOfRooms--;
            }
            gameLocations.ResetWumpusAsleepTimer();


        }

        private void buttonOneTurn_Click(object sender, EventArgs e)
        {
            if (gameLocations.TurnsUntilWumpusIsAsleep != 0)
            {
                gameLocations.MoveWumpusToRandomConnectedRoom(connectedLocations);

            }
            gameLocations.OneTurnPasses();
            
        }

        private void buttonBuySecret_Click(object sender, EventArgs e)
        {
            richTextBoxSecret.Text = gameLocations.BuySecret();
        }
    }
}
