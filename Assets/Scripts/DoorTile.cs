using UnityEngine;

class DoorTile : Tile {
    public Vector2Int? LinkedPosition { get; private set; } = null;
    public string LinkedRoom { get; private set; } = null;

    // public DoorTile(Vector2Int linkedPosition, string linkedRoom) : base(TileType.DOOR) {
    //     this.LinkedPosition = linkedPosition;
    //     this.LinkedRoom = linkedRoom;
    // }

    public DoorTile(int doorNumber) : base(doorNumber == 0 ? TileType.DOOR_H_00 : TileType.DOOR_V_01) {
        
    }
    
    public void ConfigureDoor(int x, int y, string linkedRoom) {
        // Debug.Log($"Linked door to {linkedRoom}({x},{y})");
        LinkedPosition = new Vector2Int(x, y);
        LinkedRoom = linkedRoom;
    }
}