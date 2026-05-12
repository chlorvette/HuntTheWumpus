using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cave;

namespace Wumpus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Cave.Cave cave = new Cave.Cave(2, 20, 5);
            var roomList = cave.GetFullCaveLayout();
            foreach (var room in roomList)
            {
                richTextBox1.AppendText($"Room Number: {room.RoomNumber} \n");
                richTextBox1.AppendText($"Adjacent Rooms: {string.Join(", ", room.AdjacentRooms.Select(r => r.RoomNumber))} \n");
                richTextBox1.AppendText($"Tunnel Rooms: {string.Join(", ", room.RoomTunnel.Select(r => r.RoomNumber))} \n");
                richTextBox1.AppendText("\n");
            }
        }
    }
}
