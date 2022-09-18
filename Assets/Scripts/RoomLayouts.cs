using System.Collections.Generic;

public static class RoomLayouts {
    public static List<Room> GetTestRooms() {
        var rooms = new List<Room>(new Room[] {
            new Room("StasisRoom", 14, 9,
                new string[] {
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", 
                    "W00", "F00", "F00", "F00", "W00", "o00", "O08", "o00", "F00", "W00", "o00", "O08", "o00", "W00",
                    "W00", "F00", "F00", "F00", "W00", "o00", "F00", "F00", "F00", "W00", "o00", "F00", "F00", "D00", // x = 13, y = 2
                    "W00", "F00", "F00", "F00", "W00", "F00", "F00", "W00", "F00", "W00", "T00", "F00", "F00", "W00",
                    "W00", "F00", "G00", "F00", "W00", "F00", "F00", "W00", "F00", "W00", "W00", "W00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "G00", "F00", "Z00", "T00", "F00", "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "T00", "T00", "T00", "F00", "T00", "R00", "W00", "o00", "O08", "o00", "F00", "F00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "o00", "W00", "W00", "W00", "W00", "W00",
                }),
            new Room("CorridorRoom", 11, 16,
                new string[]
                {
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "E00", "E00", "E00", "E00",
                    "W00", "F00", "O10", "o10", "F00", "F00", "W00", "E00", "E00", "E00", "E00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "D01", "E00", "E00", "E00", "E00", // x = 6, y = 2
                    "D01", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", "E00", "E00", // x = 0, y = 3 
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", "E00", "E00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "W00", "W00", "W00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "O00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "T01", "G03", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "W00", "W00", "W00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", "E00", "E00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", "E00", "E00",
                    "D01", "F00", "F00", "F00", "F00", "F00", "D01", "E00", "E00", "E00", "E00", // x1 = 0, y = 11, x2 = 6
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", "E00", "E00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", "E00", "E00",
                    "W00", "O02", "F00", "F00", "t00", "O07", "W00", "E00", "E00", "E00", "E00",
                    "W00", "W00", "W00", "D00", "W00", "W00", "W00", "E00", "E00", "E00", "E00" // x = 3, y = 15
                }),
            new Room("EngineRoom", 14, 12,
                new string[]
                {
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00",
                    "W00", "T00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "t00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "D01", // x = 13, y = 2
                    "W00", "F00", "t00", "O14", "t00", "F00", "W00", "W00", "W00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "t00", "F00", "R00", "W00", "o11", "o11", "o11", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "F00", "O11", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "F00", "o11", "F00", "o11", "o11", "o11", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00", "F00", "F00", "F00", "F00", "O11", "F00", "W00",
                    "W00", "F00", "F00", "F00", "W00", "W00", "W00", "F00", "F00", "F00", "F00", "o11", "F00", "W00",
                    "W00", "F00", "F00", "F00", "W00", "F00", "F00", "F00", "O01", "F00", "F00", "F00", "F00", "D01", // x = 13, y = 9
                    "W00", "G10", "F00", "F00", "W00", "G02", "T01", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00",
                }),
            new Room("Room", 11, 13,
                new string[]
                {
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00",
                    "D01", "F00", "F00", "F00", "O02", "F00", "F00", "O02", "F00", "R00", "W00", // x = 0, y = 1
                    "W00", "F00", "F00", "O02", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "F00", "F00", "F00", "O02", "F00", "W00",
                    "E00", "E00", "E00", "E00", "W00", "G03", "O02", "O02", "F00", "F00", "W00",
                    "E00", "E00", "E00", "E00", "W00", "O02", "F00", "F00", "F00", "O02", "W00",
                    "E00", "E00", "E00", "E00", "W00", "O02", "F00", "O02", "O02", "F00", "W00",
                    "E00", "E00", "E00", "E00", "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "O02", "O02", "F00", "O02", "O02", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "D01", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", // x = 0, y = 10 
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00"
                }),
            new Room("WeaponRoom", 11, 11, 
                new string[]
                {
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00",
                    "W00", "O01", "F00", "O13", "F00", "F00", "G02", "F00", "O01", "O01", "W00",
                    "W00", "F00", "F00", "F00", "F00", "T00", "F00", "F00", "O01", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "T00", "T00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "O10", "o10", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "O04", "O04", "F00", "F00", "F00", "W00",
                    "D01", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", // x = 0, y = 8
                    "W00", "F00", "F00", "F00", "F00", "O05", "O05", "F00", "F00", "F00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00"
                }),
            new Room("VentilationRoom", 11, 5,
                new string[]
                {
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", 
                    "D01", "F00", "O13", "O13", "O13", "O13", "F00", "F00", "F00", "F00", "W00", // x = 0, y = 1
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "G07", "O13", "O13", "O13", "O13", "F00", "F00", "F00", "R00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "W00", "D00", "W00", "W00", "W00", "W00", // x = 6, y = 4
                }),
            new Room("O2Room", 4, 9,
                new string[]
                {
                    "W00", "W00", "W00", "W00",
                    "W00", "T01", "F00", "W00",
                    "D01", "F00", "F00", "W00", // x = 0, y = 2
                    "W00", "F00", "F00", "W00",
                    "W00", "F00", "o12", "W00",
                    "W00", "F00", "O12", "W00",
                    "W00", "F00", "F00", "D01", // x = 3, y = 6
                    "W00", "F00", "F00", "W00",
                    "W00", "W00", "W00", "W00",
                }),
            new Room("StorageRoom", 10, 9,
                new string[]
                {
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", 
                    "W00", "G09", "R00", "O01", "F00", "F00", "F00", "F00", "F00", "D01", // x = 9, y = 1 
                    "W00", "F00", "F00", "O01", "F00", "F00", "o09", "O09", "o09", "W00",
                    "W00", "F00", "O01", "O01", "F00", "F00", "o09", "F00", "G01", "W00",
                    "W00", "F00", "F00", "F00", "F00", "t00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "t00", "O14", "t00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "t00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "O01", "F00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "D00", "W00", "W00", "W00", "W00", // x = 5, y = 8
                }),
            new Room("Cockpit", 31, 10,
                new string[]
                {
                    "W00", "W00", "W00", "W00", "W00", "D00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "D00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "D00", "W00", "W00", "W00", "W00", // x1 = 5, x2 = 17, x3 = 26, y = 0
                    "W00", "W00", "W00", "F00", "F00", "F00", "F00", "t00", "O07", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "t00", "O07", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "W00", "W00", 
                    "E00", "E00", "W00", "F00", "F00", "T00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", 
                    "E00", "E00", "W00", "W00", "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "W00", "W00", "E00", "E00", 
                    "E00", "E00", "E00", "E00", "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "O06", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", "E00", "E00", 
                    "E00", "E00", "E00", "E00", "W00", "W00", "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "W00", "W00", "E00", "E00", "E00", "E00", 
                    "E00", "E00", "E00", "E00", "E00", "E00", "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "O06", "Z00", "O06", "F00", "F00", "F00", "F00", "F00", "F00", "G00", "W00", "E00", "E00", "E00", "E00", "E00", "E00", 
                    "E00", "E00", "E00", "E00", "E00", "E00", "W00", "W00", "W00", "F00", "F00", "F00", "F00", "F00", "O03", "O03", "O03", "F00", "F00", "F00", "F00", "F00", "W00", "W00", "W00", "E00", "E00", "E00", "E00", "E00", "E00", 
                    "E00", "E00", "E00", "E00", "E00", "E00", "E00", "E00", "W00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "E00", "E00", "E00", "E00", "E00", "E00", "E00", "E00", 
                    "E00", "E00", "E00", "E00", "E00", "E00", "E00", "E00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "E00", "E00", "E00", "E00", "E00", "E00", "E00", "E00",
                }),
            new Room("CorridorRoom2", 7, 16,
                new string[]
                {
                    "W00", "W00", "W00", "D00", "W00", "W00", "W00", // x = 3, y = 0
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "D01", "F00", "F00", "F00", "F00", "F00", "W00", // x = 0, y = 4
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "D01", // x = 6 , y = 8
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "D01", // x = 6 , y = 12
                    "D01", "F00", "F00", "F00", "F00", "F00", "W00", // x = 0, y = 13,
                    "W00", "F00", "F00", "F00", "F00", "F00", "W00",  
                    "W00", "W00", "W00", "D00", "W00", "W00", "W00"  // x = 3 , y = 15
                })
        });
        
        ConnectDoors(rooms[0], 13, 2, rooms[1], 0,  3);
        ConnectDoors(rooms[1], 0, 11, rooms[2], 13, 2);
        ConnectDoors(rooms[1], 6, 2,  rooms[3], 0,  1);
        ConnectDoors(rooms[1], 6, 11, rooms[3], 0,  10);
        ConnectDoors(rooms[1], 3, 15, rooms[9], 3,  0);
        
        ConnectDoors(rooms[5], 6, 4,  rooms[8], 26, 0);
        ConnectDoors(rooms[6], 0, 2,  rooms[7], 9,  1);
        ConnectDoors(rooms[7], 5, 8,  rooms[8], 5,  0);
        
        ConnectDoors(rooms[9], 0, 4,  rooms[2], 13, 9);
        ConnectDoors(rooms[9], 6, 8,  rooms[4], 0,  8);
        ConnectDoors(rooms[9], 6, 12, rooms[5], 0,  1);
        ConnectDoors(rooms[9], 0, 13, rooms[6], 3,  6);
        ConnectDoors(rooms[9], 3, 15, rooms[8], 17, 0);
        
        return rooms;
    }

    
    public static void ConnectDoors(Room room1, int doorX1, int doorY1, Room room2, int doorX2, int doorY2) {
        DoorTile doorTile = (DoorTile)room1.GetTileAt(doorX1, doorY1);
        DoorTile otherDoorTile = (DoorTile)room2.GetTileAt(doorX2, doorY2);
        doorTile.ConfigureDoor(doorX2, doorY2, room2.Name);
        otherDoorTile.ConfigureDoor(doorX1, doorY1, room1.Name);
    }
    
    // public static List<Room> GetTestRooms() => new(new Room[]{
    //     new Room("Room1", new[] {
    //         new Tile[] { new (TileType.WALL), new (TileType.WALL), new (TileType.WALL), new (TileType.WALL) },
    //         new Tile[] { new (TileType.WALL), new (), new (), new (TileType.WALL) },
    //         new Tile[] { new (TileType.WALL), new (), new (), new (TileType.WALL) },
    //         new Tile[] { new (TileType.WALL), new (TileType.WALL), new DoorTile(2,0, "Room2"), new (TileType.WALL) },
    //     }),
    //     new Room("Room2", new[] {
    //         new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new DoorTile(2,3, "Room1"), new Tile(TileType.WALL) },
    //         new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
    //         new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
    //         new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL) },
    //     })
    // });
    //
    //
    //
    // public static List<Room> GetGameRooms() => new(new Room[]{
    //     new Room("Room1", new[] {
    //         new Tile[] { new (TileType.WALL), new (TileType.WALL), new (TileType.WALL), new (TileType.WALL) },
    //         new Tile[] { new (TileType.WALL), new (), new (), new (TileType.WALL) },
    //         new Tile[] { new (TileType.WALL), new (), new (), new (TileType.WALL) },
    //         new Tile[] { new (TileType.WALL), new (TileType.WALL), new DoorTile(2,0, "Room2"), new (TileType.WALL) },
    //     }),
    //     new Room("Room2", new[] {
    //         new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new DoorTile(2,3, "Room1"), new Tile(TileType.WALL) },
    //         new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
    //         new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
    //         new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL) },
    //     })
    // });


}