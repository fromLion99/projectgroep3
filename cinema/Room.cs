using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Room
    {
        //Properties Room
        public int Id {get; set;}
        public int RoomNumber {get; set;}
        public int ChairCount {
            get{
                return RowCount * ChairsPerRow;
            } 
            set{}
        }
        public int RowCount {get; set;}
        public int ChairsPerRow {get; set;}
        public static void addRoom()
        {
            //This function adds a room to the JSON
            int row, chair = 0;
            string valRoomNumber, valRow, valChair = "";

            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            for(int i = 0; i < roomDetail.Count; i++)
            {
                Console.WriteLine("Room ID: " + roomDetail[i].Id);
                Console.WriteLine("Room number: " + roomDetail[i].RoomNumber);
                Console.WriteLine("\n===================================================================================\n");
            }

            Room room = new Room();
            var item = roomDetail[roomDetail.Count -1];
            room.Id = item.Id+1;

            Console.WriteLine("Enter the room number: ");
            valRoomNumber = Console.ReadLine();
            room.RoomNumber = Convert.ToInt32(valRoomNumber);

            Console.WriteLine("Enter the count of chair rows: ");
            valRow = Console.ReadLine();
            row = Convert.ToInt32(valRow);
            room.RowCount = row;

            Console.WriteLine("Enter the count of chairs in a row: ");
            valChair = Console.ReadLine();
            chair = Convert.ToInt32(valChair);
            room.ChairsPerRow = chair;
            roomDetail.Add(room);

            string resultJson = JsonSerializer.Serialize<List<Room>>(roomDetail);
            File.WriteAllText("rooms.json", resultJson);

            Console.WriteLine("Room successfully added.\n");
        }

        public static void viewRoom()
        {
            //This function displays all the rooms on the screen
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            for(int i = 0; i < roomDetail.Count; i++)
            {
                Console.WriteLine("Room ID: " + roomDetail[i].Id);
                Console.WriteLine("Room number: " + roomDetail[i].RoomNumber);
                Console.WriteLine("Count chairs: " + roomDetail[i].ChairCount);
                Console.WriteLine("Amount of rows: " + roomDetail[i].RowCount);
                Console.WriteLine("Chairs in a row: " + roomDetail[i].ChairsPerRow);
                Console.WriteLine("\n===================================================================================\n");
            }
        }

        public static void editRoom()
        {
            //This function can edit a room
            string roomId, roomNumber, countOfChair, countRow, countRowChair = "";
            int idRoom, numberRoom, chairCount, rowCount, rowChairCount = 0;

            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            for(int i = 0; i < roomDetail.Count; i++)
            {
                Console.WriteLine("Room ID: " + roomDetail[i].Id);
                Console.WriteLine("Room number: " + roomDetail[i].RoomNumber);
                Console.WriteLine("\n===================================================================================\n");
            }

            Console.WriteLine("Enter the ID of the room you want to edit: ");
            roomId = Console.ReadLine();
            idRoom = Convert.ToInt32(roomId);
            var searchedRoom = roomDetail.FirstOrDefault(m=>m.Id==idRoom);

            Console.WriteLine("Room ID: " + searchedRoom.Id);
            Console.WriteLine("Room number: " + searchedRoom.RoomNumber);
            Console.WriteLine("Count chairs: " + searchedRoom.ChairCount);
            Console.WriteLine("Amount of rows: " + searchedRoom.RowCount);
            Console.WriteLine("Chairs in a row: " + searchedRoom.ChairsPerRow);
            Console.WriteLine("\n===================================================================================\n");

            Console.WriteLine("Enter a new room number: ");
            roomNumber = Console.ReadLine();
            numberRoom = Convert.ToInt32(roomNumber);
            searchedRoom.RoomNumber = numberRoom;
            Console.WriteLine("Enter a new count of chairs: ");
            countOfChair = Console.ReadLine();
            chairCount = Convert.ToInt32(countOfChair);
            searchedRoom.ChairCount = chairCount;
            Console.WriteLine("Enter a new amount of rows: ");
            countRow = Console.ReadLine();
            rowCount = Convert.ToInt32(countRow);
            searchedRoom.RowCount = rowCount;
            Console.WriteLine("Enter a new amount of chair in a row: ");
            countRowChair = Console.ReadLine();
            rowChairCount = Convert.ToInt32(countRowChair);
            searchedRoom.ChairsPerRow = rowChairCount;

            string resultJson = JsonSerializer.Serialize<List<Room>>(roomDetail);
            File.WriteAllText("rooms.json", resultJson);

            Console.WriteLine("Changes successfully saved.");
        }

        public static void deleteRoom()
        {
            //This function deletes a room from the JSON
            string valId = "";
            int id = 0;

            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            for(int i = 0; i < roomDetail.Count; i++)
            {
                Console.WriteLine("Room ID: " + roomDetail[i].Id);
                Console.WriteLine("Room number: " + roomDetail[i].RoomNumber);
                Console.WriteLine("\n===================================================================================\n");
            }

            Console.WriteLine("Enter the ID of the room you want to delete: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            roomDetail.Remove(roomDetail.FirstOrDefault(m=>m.Id==id));

            string resultJson = JsonSerializer.Serialize<List<Room>>(roomDetail);
            File.WriteAllText("rooms.json", resultJson);

            Console.WriteLine("Room with ID: " + id + " is successfully deleted.");
        }

        public static Room GetRoom(int id){
            var rooms = JsonSerializer.Deserialize<List<Room>>(File.ReadAllText("rooms.json"));
            return rooms.Find(r => r.Id == id);
        }
    }
}