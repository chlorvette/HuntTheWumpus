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
        Cave.Cave cave = new Cave.Cave(2, 5, 5);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var roomList = cave.GetFullCaveLayout();
            foreach (var room in roomList)
            {
                richTextBox1.AppendText($"Room Number: {room.RoomNumber} \n");
                richTextBox1.AppendText($"Adjacent Rooms: {string.Join(", ", room.AdjacentRooms.Select(r => r.RoomNumber))} \n");
                richTextBox1.AppendText($"Tunnel Rooms: {string.Join(", ", room.RoomTunnel.Select(r => r.RoomNumber))} \n");
                richTextBox1.AppendText("\n");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int roomNumber = int.Parse(textBox1.Text);
            var room = cave.GetRoom(roomNumber);
            richTextBox2.AppendText($"Room Number: {room.RoomNumber} \n");
            richTextBox2.AppendText($"Adjacent Rooms: {string.Join(", ", room.AdjacentRooms.Select(r => r.RoomNumber))} \n");
            richTextBox2.AppendText($"Tunnel Rooms: {string.Join(", ", room.RoomTunnel.Select(r => r.RoomNumber))} \n");
            richTextBox2.AppendText("\n");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //test to make sure all tunnesl are reachable 
            var roomList = cave.GetFullCaveLayout();
            foreach (var room in roomList)
            {
                if (room.RoomTunnel.Count > 0)
                {
                    foreach (var tunnelRoom in room.RoomTunnel)
                    {
                        if (!roomList.Any(r => r.RoomNumber == tunnelRoom.RoomNumber))
                        {
                            richTextBox3.AppendText($"Tunnel Room {tunnelRoom.RoomNumber} from Room {room.RoomNumber} is not reachable.\n");
                        }
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //test to make sure all tunnesl are reachable from anywhere in the cave
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            cave.RegenerateTunnels(cave.GetFullCaveLayout());
            richTextBox2.Clear();
             richTextBox3.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //cave.GetTunnelLayoutFromJson("demo.json");
             richTextBox1.Clear(); richTextBox2.Clear();
        }
    }
}
