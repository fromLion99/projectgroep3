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
        public int CountChair {get; set;}
        public int Row {get; set;}
        public int Chair {get; set;}

        public void addRoom(){
            int roomNumber, countChair, row, chair = 0;
            string valRoomNumber, valCountChair, valRow, valChair = "";

            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            Room room = new Room();
            for(int i = 0; i < roomDetail.Count; i++){
                Console.WriteLine("Room ID: " + roomDetail[i].Id);
                Console.WriteLine("Room number: " + roomDetail[i].RoomNumber);
                Console.WriteLine("\n===================================================================================\n");
            }
            var item = roomDetail[roomDetail.Count -1];
            var newId = item.Id+1;
            room.Id = newId;
            Console.WriteLine("Enter the room number: ");
            valRoomNumber = Console.ReadLine();
            roomNumber = Convert.ToInt32(valRoomNumber);
            room.RoomNumber = roomNumber;
            Console.WriteLine("Enter the count of chairs in the room: ");
            valCountChair = Console.ReadLine();
            countChair = Convert.ToInt32(valCountChair);
            room.CountChair = countChair;
            Console.WriteLine("Enter the count of chair rows: ");
            valRow = Console.ReadLine();
            row = Convert.ToInt32(valRow);
            room.Row = row;
            Console.WriteLine("Enter the count of chairs in a row: ");
            valChair = Console.ReadLine();
            chair = Convert.ToInt32(valChair);
            room.Chair = chair;
            roomDetail.Add(room);

            string resultJson = JsonSerializer.Serialize<List<Room>>(roomDetail);
            File.WriteAllText("rooms.json", resultJson);
            Console.WriteLine("Room successfully added.\n");
        }

        public void viewRoom(){
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            for(int i = 0; i < roomDetail.Count; i++){
                Console.WriteLine("Room ID: " + roomDetail[i].Id);
                Console.WriteLine("Room number: " + roomDetail[i].RoomNumber);
                Console.WriteLine("Count chairs: " + roomDetail[i].CountChair);
                Console.WriteLine("Amount of rows: " + roomDetail[i].Row);
                Console.WriteLine("Chairs in a row: " + roomDetail[i].Chair);
                Console.WriteLine("\n===================================================================================\n");
            }
        }

        public void editRoom(){
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            string roomId, roomNumber, countOfChair, countRow, countRowChair = "";
            int idRoom, numberRoom, chairCount, rowCount, rowChairCount = 0;

            for(int i = 0; i < roomDetail.Count; i++){
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
            Console.WriteLine("Count chairs: " + searchedRoom.CountChair);
            Console.WriteLine("Amount of rows: " + searchedRoom.Row);
            Console.WriteLine("Chairs in a row: " + searchedRoom.Chair);
            Console.WriteLine("\n===================================================================================\n");

            Console.WriteLine("Enter a new room number: ");
            roomNumber = Console.ReadLine();
            numberRoom = Convert.ToInt32(roomNumber);
            searchedRoom.RoomNumber = numberRoom;
            Console.WriteLine("Enter a new count of chairs: ");
            countOfChair = Console.ReadLine();
            chairCount = Convert.ToInt32(countOfChair);
            searchedRoom.CountChair = chairCount;
            Console.WriteLine("Enter a new amount of rows: ");
            countRow = Console.ReadLine();
            rowCount = Convert.ToInt32(countRow);
            searchedRoom.Row = rowCount;
            Console.WriteLine("Enter a new amount of chair in a row: ");
            countRowChair = Console.ReadLine();
            rowChairCount = Convert.ToInt32(countRowChair);
            searchedRoom.Chair = rowChairCount;

            string resultJson = JsonSerializer.Serialize<List<Room>>(roomDetail);
            File.WriteAllText("rooms.json", resultJson);
            Console.WriteLine("Changes successfully saved.");
        }

        public void deleteRoom(){
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            string valId = "";
            int id = 0;

            for(int i = 0; i < roomDetail.Count; i++){
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

            Console.WriteLine("Room with ID: " + id + "is successfully deleted.");
        }
    }
}