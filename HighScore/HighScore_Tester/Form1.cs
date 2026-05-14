using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HighScore_Tester
{
    public partial class Form1 : Form
    {

        int coins = 0;
        int roomsMoved = 0;
        int totalArrows = 0; //deduct and add arrows when purchased or shot
        int totalItems = 0;

        public Form1()
        {

            InitializeComponent();

        }

        // at the begining there are 0 coins

        private void buttonShootArrow_Click(object sender, EventArgs e)
        {
            if (totalArrows <= 0)
            {
                MessageBox.Show("You don't have enough arrows to shoot!");
                return;
            }
            else
            {
                totalArrows--;
                textBoxArrows.Text = totalArrows.ToString();
                return; // so this means they shot an arrow and now they have one less arrow (because we keep track of how many arrows they have)
            }
        }

        private void buttonGetArrow_Click(object sender, EventArgs e)
        {
            if (coins < 15)
            {
                MessageBox.Show("Minimum of 5 coins to buy an arrow.");
                return;
            }
            else
            {
                totalArrows++;
                coins -= 15;
                textBoxArrows.Text = totalArrows.ToString();
                textBoxCoins.Text = coins.ToString();
                return;  // so this means that they lost five dollars to buy an arrow 
            }
        }

        private void buttonCorrectAnswer_Click(object sender, EventArgs e)
        {
            coins += 5;
            textBoxCoins.Text = coins.ToString();
        }

        private void buttonWrongAnswer_Click(object sender, EventArgs e)
        {
            coins -= 5;
            textBoxCoins.Text = coins.ToString();
        }

        private void buttonItem_Click(object sender, EventArgs e)
        {
            string itemName = textBoxItems.Text;

            listBoxItems.Items.Add(itemName);
            textBoxItems.Clear();
            totalItems++;
            
        }


        private void buttonKillWompus_Click(object sender, EventArgs e)
        {
            coins += 500;
        }

        private void buttonDieWompus_Click(object sender, EventArgs e)
        {
            coins = 0;
        }

        private void buttonBats_Click(object sender, EventArgs e)
        {
            coins -= 30;
        }

        private void buttonFallDown_Click(object sender, EventArgs e)
        {
            coins = 0;
        }
    }
}
