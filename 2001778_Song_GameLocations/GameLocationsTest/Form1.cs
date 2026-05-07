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
        GameLocations.GameLocations gameLocations = new GameLocations.GameLocations();


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
    }
}
