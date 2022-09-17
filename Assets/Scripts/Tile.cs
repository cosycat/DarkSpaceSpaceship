using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Tile {
    
    public TileType Type { get; private set; }

    [CanBeNull] public Item ItemOnTile { get; private set; } = null;

    public Tile(TileType type = TileType.FLOOR) {
        Type = type;
    }

    public Tile(Item item) {
        ItemOnTile = item;
    }

    public void ConsumeItem() {
        ItemOnTile?.OnConsume();
    }
}

class DoorTile : Tile {
    public Vector2Int LinkedPosition { get; private set; }
    public string LinkedRoom { get; private set; }

    // public DoorTile(Vector2Int linkedPosition, string linkedRoom) : base(TileType.DOOR) {
    //     this.LinkedPosition = linkedPosition;
    //     this.LinkedRoom = linkedRoom;
    // }

    public DoorTile() : base(TileType.DOOR) {
        
    }
    
    public DoorTile(int x, int y, string linkedRoom) : base(TileType.DOOR) {
        this.LinkedPosition = new Vector2Int(x, y);
        this.LinkedRoom = linkedRoom;
    }

    public void ConfigureDoor(int x, int y, string linkedRoom) {
        Debug.Log($"Linked door to {linkedRoom}({x},{y})");
        LinkedPosition = new Vector2Int(x, y);
        LinkedRoom = linkedRoom;
    }
}