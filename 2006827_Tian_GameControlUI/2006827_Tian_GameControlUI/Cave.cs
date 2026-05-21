using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Xml.Linq;
using Microsoft.SqlServer.Server;

namespace CaveGeneration


{
    //generate new caves hexagonal layout
    public class Room
    {

        public int RoomNumber { get; set; }
        public List<Room> AdjacentRooms { get; set; }
        public List<Room> RoomTunnels { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Room(int x, int y, int roomNumber)
        {
            RoomNumber = roomNumber;
            Row = x;
            Col = y;

            AdjacentRooms = new List<Room>();
            RoomTunnels = new List<Room>();
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

        //
        // PUBLIC METHODS
        //

        public Room GetRoom(int roomNumber)
        {
            return roomList[roomNumber - 1];
            }
        public List<Room> GetAdjacentRoomsForRoomNumber(int roomNumber) 
        {
            var room = GetRoom(roomNumber);
            List<Room> adjacentRooms = room.AdjacentRooms;
            List<int> adjacentRoomNumbers = new List<int>();
            foreach (Room adjacentRoom in adjacentRooms)
            {
                adjacentRoomNumbers.Add(adjacentRoom.RoomNumber);
            }
            return (adjacentRooms, adjacentRoomNumbers);
        }
        public List<Room> GetTunnelRooms(int roomNumber)
        {
            var room = GetRoom(roomNumber);
            return room.RoomTunnels;
        }
        public List<Room> GetFullCaveLayout()
        {
            return roomList;

        }
        public List<Room> GetTunnels(int roomNumber)
        {
            
            var room = GetRoom(roomNumber);
            return room.RoomTunnels;
        }
        public bool IsInRoomIndex(int roomNumber)
        {
            //if its in the index
            try
            {
                Room test = roomList[roomNumber];
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<Room> RegenerateTunnels(List<Room> rooms)
        {
            rooms = ClearTunnels(rooms);
            rooms = GenerateTunnels(rooms);
            return rooms;
        }

        

        //
        //
        // PRIVATE METHODS
        //
        //

        private List<Room> PopulateAdjacentRooms(List<Room> rooms)
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
        private void PrintLayout(List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                Debug.WriteLine($"Room Number: {room.RoomNumber} \n");
                Debug.WriteLine($"Adjacent Rooms: {string.Join(", ", room.AdjacentRooms.Select(r => r.RoomNumber))} \n");
                Debug.WriteLine($"Tunnel Rooms: {string.Join(", ", room.RoomTunnels.Select(r => r.RoomNumber))} \n");
                Debug.WriteLine("\n");
            }
        }

        private List<Room> ClearTunnels(List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                room.RoomTunnels.Clear();
            }
            return rooms;
        }

        private List<Room> GenerateLayout()
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
            rooms = PopulateAdjacentRooms(rooms);
            rooms = GenerateTunnels(rooms);


            return rooms;
        }
    
        private List<Room> GenerateTunnels(List<Room> rooms)
        {
            if (rooms == null || rooms.Count == 0) 
                return rooms;

            List<Room> Path = new List<Room>();
            List<Room> roomsNotHit = new List<Room>(rooms);

            Room currentRoom = rooms[1];
            Path.Add(currentRoom);
            roomsNotHit.Remove(currentRoom);

            List<Room> ValidRooms = new List<Room>();
            Random rand = new Random();

            while (roomsNotHit.Any())
            {
                ValidRooms.Clear();
                foreach (var roomNextTo in currentRoom.AdjacentRooms)
                {
                    if (roomsNotHit.Any(r => r.RoomNumber == roomNextTo.RoomNumber))
                        ValidRooms.Add(roomNextTo);
                }

                if (ValidRooms.Count == 0)
                {
                    if (Path.Count <= 1)
                        break;
                    Path.RemoveAt(Path.Count - 1);
                    currentRoom = Path[Path.Count - 1];
                    continue;
                }

                Room nextRoom = ValidRooms[rand.Next(ValidRooms.Count)];

                var nextRoomRef = roomsNotHit.First(r => r.RoomNumber == nextRoom.RoomNumber);

                currentRoom.RoomTunnels.Add(nextRoomRef);
                nextRoomRef.RoomTunnels.Add(currentRoom);

                Path.Add(nextRoomRef);
                roomsNotHit.Remove(nextRoomRef);
                currentRoom = nextRoomRef;
            }
            return rooms;
        }

    }
}
