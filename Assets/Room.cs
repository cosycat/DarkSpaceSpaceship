
using UnityEngine;

public class Room {
    public string Name { get; set; }
    public Tile[][] RoomMap { get; set; }

    public int height => RoomMap.Length;
    public int width => RoomMap[0].Length;
    
    public Tile GetTileAt(int x, int y) {
        return RoomMap[y][x];
    }

    public Room(string name, Tile[][] roomMap) {
        Name = name;
        RoomMap = roomMap;
    }
}
