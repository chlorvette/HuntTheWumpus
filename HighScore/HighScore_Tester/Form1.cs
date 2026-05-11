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

        public Form1()
        {

            InitializeComponent();

        }

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
            if (coins < 5)
            {
                MessageBox.Show("Minimum of 5 coins to buy an arrow.");
                return;
            }
            else
            {
                totalArrows++;
                coins -= 5;
                textBoxArrows.Text = totalArrows.ToString();
                textBoxCoins.Text = coins.ToString();
                return;  // so this means that they lost five dollars to buy an arrow 
            }
        }

        private void buttonCorrectAnswer_Click(object sender, EventArgs e)
        {
            coins += 20;
            textBoxCoins.Text = coins.ToString();
        }

        private void buttonWrongAnswer_Click(object sender, EventArgs e)
        {
            coins -= 20;
            textBoxCoins.Text = coins.ToString();
        }

    }
}
