using System.Collections.Generic;
using UnityEngine;

public class Tile {
    
    public TileType Type { get; private set; }

    public Tile(TileType type = TileType.FREE) {
        Type = type;
    }
    
}

class DoorTile : Tile {
    public Vector2Int LinkedPosition { get; }
    public string LinkedRoom { get; }

    // public DoorTile(Vector2Int linkedPosition, string linkedRoom) : base(TileType.DOOR) {
    //     this.LinkedPosition = linkedPosition;
    //     this.LinkedRoom = linkedRoom;
    // }

    public DoorTile(int x, int y, string linkedRoom) : base(TileType.DOOR) {
        this.LinkedPosition = new Vector2Int(x, y);
        this.LinkedRoom = linkedRoom;
    }
}