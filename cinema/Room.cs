using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

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
            int id, roomNumber, countChair, row, chair = 0;
            string valId, valRoomNumber, valCountChair, valRow, valChair = "";

            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            Room room = new Room();
            Console.WriteLine("Enter room ID: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            room.Id = id;
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

            string resultJson = JsonSerializer.Serialize<List<Room>>(roomDetail);
            File.WriteAllText("rooms.json", resultJson);
            Console.WriteLine("Room successfully added.");
        }

        public void viewRoom(){
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            for(int i = 0; i < roomDetail.Count; i++){
                Console.WriteLine("Room ID: " + roomDetail[i].Id);
                Console.WriteLine("Roomnumber: " + roomDetail[i].RoomNumber);
                Console.WriteLine("Count chairs: " + roomDetail[i].CountChair);
                Console.WriteLine("Rows: " + roomDetail[i].Row);
                Console.WriteLine("Chair: " + roomDetail[i].Chair);
                Console.WriteLine("\n===================================================================================\n");
            }
        }
    }
}