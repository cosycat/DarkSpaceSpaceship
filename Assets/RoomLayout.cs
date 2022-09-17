using System.Collections.Generic;

public static class RoomLayout {
    
    public static List<Room> GetTestRooms() => new(new Room[]{
        new Room("Room1", new[] {
            new Tile[] { new (TileType.WALL), new (TileType.WALL), new (TileType.WALL), new (TileType.WALL) },
            new Tile[] { new (TileType.WALL), new (), new (), new (TileType.WALL) },
            new Tile[] { new (TileType.WALL), new (), new (), new (TileType.WALL) },
            new Tile[] { new (TileType.WALL), new (TileType.WALL), new DoorTile(2,0, "Room2"), new (TileType.WALL) },
        }),
        new Room("Room2", new[] {
            new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new DoorTile(2,3, "Room1"), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL) },
        })
    });
    
    
    
    public static List<Room> GetGameRooms() => new(new Room[]{
        new Room("Room1", new[] {
            new Tile[] { new (TileType.WALL), new (TileType.WALL), new (TileType.WALL), new (TileType.WALL) },
            new Tile[] { new (TileType.WALL), new (), new (), new (TileType.WALL) },
            new Tile[] { new (TileType.WALL), new (), new (), new (TileType.WALL) },
            new Tile[] { new (TileType.WALL), new (TileType.WALL), new DoorTile(2,0, "Room2"), new (TileType.WALL) },
        }),
        new Room("Room2", new[] {
            new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new DoorTile(2,3, "Room1"), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL) },
        })
    });
    
    
}