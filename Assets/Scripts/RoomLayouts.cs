using System.Collections.Generic;

public static class RoomLayouts {
    public static List<Room> GetTestRooms() {
        var rooms = new List<Room>(new Room[] {
            new Room("Room1", 4, 4,
                "WWWW" +
                "WFFW" +
                "WFFW" +
                "WWDW"),
            new Room("Room2", 6, 6,
                "WWWDWW" +
                "WFFFFW" +
                "WFTOFW" +
                "WFGFFW" +
                "WFFFFW" +
                "WWDWWW"),
            new Room("Room3", 10, 6,
                "WWDWWWWWWW" +
                "WFFFFFFFFW" +
                "WFFFFFFFFW" +
                "WFFFFFFFFW" +
                "WFFFFFFFFD" +
                "WWWWWWWWWW" 
                ),
            new Room("Room4", 9, 13,
                "WWWWWWWWW" +
                "WFFFFFFFW" +
                "WFFFFFFFW" +
                "WFFFFFFFW" +
                "DFFFFFFFW" +
                "WWWWWFFFW" + 
                "EEEEWFFFW" + 
                "EEEEWFFFW" + 
                "EEEEWFFFW" + 
                "EEEEWFFFW" + 
                "EEEEWFFFW" + 
                "EEEEWFFFW" + 
                "EEEEWFFFW" + 
                "EEEEWWWWW" 
                )
        });
        ConnectDoors(rooms[0], 2, 3, rooms[1], 3, 0);
        ConnectDoors(rooms[1], 2, 5,rooms[2],2, 0);
        ConnectDoors(rooms[2], 9, 4,rooms[3],0, 4);
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