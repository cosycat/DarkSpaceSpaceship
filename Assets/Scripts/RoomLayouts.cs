using System.Collections.Generic;

public static class RoomLayouts {
    public static List<Room> GetTestRooms() {
        var rooms = new List<Room>(new Room[] {
            new Room("StasisRoom", 14, 9,
                new string[] {
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", 
                    "W00", "F00", "F00", "F00", "W00", "O02", "T01", "F00", "F00", "F00", "W00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "W00", "F00", "F00", "F00", "F00", "F00", "W00", "F00", "F00", "D00", // x = 13, y = 2
                    "W00", "F00", "F00", "F00", "W00", "F00", "F00", "W00", "F00", "F00", "W00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "W00", "F00", "F00", "W00", "F00", "F00", "W00", "W00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "F00", "F00", "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "F00", "F00", "F00", "F00", "T00", "R00", "W00", "F00", "F00", "F00", "F00", "F00", "W00",
                    "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00", "W00",
                }),
            // new Room("CorridorRoom", 11, 30, 
            //     "WWWWWWWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFDEEEE" + // x = 6, y = 2 
            //     "DFFFFFWEEEE" + // x = 0, y = 3 
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWWWWW" +
            //     "WFFFFFFFFFW" +
            //     "WFFFFFFFFFW" +
            //     "WFFFFFWWWWW" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "DFFFFFDEEEE" + // x1 = 0, y = 11, x2 = 6
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "DFFFFFWEEEE" + // x = 0, y = 18 
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFDEEEE" + // x = 6 , y = 22 
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFWEEEE" +
            //     "WFFFFFDEEEE" + // x = 7 , y = 26
            //     "DFFFFFDEEEE" + // x1 = 0, y = 27, x2 = 6  
            //     "WFFFFFWEEEE" +
            //     "WWWDWWWEEEE"   // x = 3 , y = 29
            //     ),
            // new Room("Engine Room", 14, 12,
            //     "WWWWWWWWWWWWWW" +
            //     "WFFFFFFFFFFFFW" +
            //     "WFFFFFFFFFFFFD" + // x = 13, y = 2 
            //     "WFFFFFWWWFFFFW" +
            //     "WFFFFFWFFFFFFW" +
            //     "WFFFFFWFFFFFFW" +
            //     "WFFFFFWFFFFFFW" +
            //     "WFFFFFWFFFFFFW" +
            //     "WFFFWWWFFFFFFW" +
            //     "WFFFWFFFFFFFFD" + // x = 13, y = 9
            //     "WFFFWFFFFFFFFW" +
            //     "WWWWWWWWWWWWWW"
            // ),
            // new Room("Kitchen", )
        });
        
        // ConnectDoors(rooms[0],13, 2, rooms[1], 0, 3 );
        // ConnectDoors(rooms[1], 0, 11, rooms[2], 13, 2 );
        // ConnectDoors(rooms[1], 0, 18, rooms[2], 13,  9);
        
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