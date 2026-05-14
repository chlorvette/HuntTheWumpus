using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave


{
    //generate new caves hexagonal layout
    public class Room
    {

        public int RoomNumber { get; set; }
        public List<Room> AdjacentRooms { get; set; }
        public List<Room> RoomTunnel { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Room(int x, int y, int roomNumber)
        {
            RoomNumber = roomNumber;
            Row = x;
            Col = y;

            AdjacentRooms = new List<Room>();
            RoomTunnel = new List<Room>();
        }

        public static implicit operator List<object>(Room v)
        {
            throw new NotImplementedException();
        }
    }

    public class Cave
    {
        public int NumberOfTunnelsPerRoom { get; set; } 
        public int CaveLayout { get; set; }
        public int CaveSize { get; set; }
        public int CaveWidth { get; set; }
        public List<Room> roomList { get; set; } 
        public Cave(int numberOfTunnelsPerRoom, int caveSize, int caveWidth)
        {
            NumberOfTunnelsPerRoom = numberOfTunnelsPerRoom;
            CaveSize = caveSize;
            CaveWidth = caveWidth;
            roomList = new List<Room>();
            roomList = GenerateLayout();


        }

        // PUBLIC METHODS
        public Room GetRoom(int roomNumber)
        {
            return roomList[roomNumber - 1];
            }
        public List<Room> GetAdjacentRoomsForRoomNumber(int roomNumber) 
        {
            var room = GetRoom(roomNumber);
            return room.AdjacentRooms;
        }
        public List<Room> GetTunnelRooms(int roomNumber)
        {
            var room = GetRoom(roomNumber);
            return room.RoomTunnel;
        }
        public List<Room> GetFullCaveLayout()
        {
            return roomList;

        }
        public List<Room> GetTunnels(int roomNumber)
        {
            
                var room = GetRoom(roomNumber);
            return room.RoomTunnel;
        }













        // PRIVATE METHODS
        private List<Room> FindAdjacentRooms(List<Room> rooms)
        {
            //Find the adjacent rooms for each room in the layout and add them to the adjacent room list
             
            foreach (var room in rooms)
            {
                int row = room.Row;
                int col = room.Col;
                var adjacentPositions = new List<(int, int)>
                {(row - 1, col),(row + 1, col), (row, col - 1),  (row, col + 1)};
                foreach (var pos in adjacentPositions)
                {
                    var adjacentRoom = rooms.FirstOrDefault(r => r.Row == pos.Item1 && r.Col == pos.Item2); // <- not real
                    if (adjacentRoom != null)
                    {
                        room.AdjacentRooms.Add(adjacentRoom);
                    }
                }
            }
                return rooms;

        }
        public List<Room> GenerateLayout()
        {
            List<Room> rooms = new List<Room>();
            int RoomNumber = 1;
            for (int i = 0; i < CaveSize; i++)
            {
                for (int j = 0; j < CaveWidth; j++)
                {
                    rooms.Add(new Room(i, j, RoomNumber));
                    RoomNumber++;
                }
            }
            Random rand = new Random();
            // populate adjacency once for all rooms
            rooms = FindAdjacentRooms(rooms);
            rooms = GenerateTunnels(rooms);


            return rooms;
        }
        private List<Room> GenerateTunnels(List<Room> rooms)
        {
            //
            List<Room> Path = new List<Room>();
            List<Room> roomsNotHit = new List<Room>(rooms);
            Debug.WriteLine(rooms.ToString());

            Room currnetRoom = rooms[1];
            Path.Add(currnetRoom);

            List<Room> ValidRooms = new List<Room>();
            Random rand = new Random();


            int debug = 0;
            
            while (roomsNotHit.Any())
            {
                //Go Though a random tunnel that hasnt been entered add it to the travel path
                //Remove tunnel you wentthough 
                //If a room has no vaild tunnels then go back to the previous room in the list
                foreach (var roomNextTo in currnetRoom.AdjacentRooms)
                {
                    if (roomsNotHit.Any(r => r.RoomNumber == roomNextTo.RoomNumber))
                        ValidRooms.Add(roomNextTo);
                }
                if (!roomsNotHit.Any())
                {
                    //break out of the loop if there are no more rooms to hit
                    break;
                }
                if (ValidRooms.Count == 0)
                {
                    if (Path.Count == 0)
                        break;
                    currnetRoom = Path[Path.Count - 1];
                    Path.RemoveAt(Path.Count - 1);
                    continue;
                }
                Room nextRoom = ValidRooms[rand.Next(ValidRooms.Count)];
                currnetRoom.RoomTunnel.Add(nextRoom);
                nextRoom.RoomTunnel.Add(currnetRoom);
                Path.Add(nextRoom);
                roomsNotHit.Remove(currnetRoom);
                currnetRoom = nextRoom;
                ValidRooms = new List<Room>();
            }
            return rooms;
        }
    }
}
