using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Tile {
    
    public TileType Type { get; private set; }

    [CanBeNull] private Item _item = null;

    public Tile(TileType type = TileType.FLOOR) {
        Type = type;
    }

    public Tile(Item item) {
        _item = item;
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