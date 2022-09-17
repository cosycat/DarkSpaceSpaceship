using UnityEngine;

class DoorTile : Tile {
    public Vector2Int LinkedPosition { get; private set; }
    public string LinkedRoom { get; private set; }

    // public DoorTile(Vector2Int linkedPosition, string linkedRoom) : base(TileType.DOOR) {
    //     this.LinkedPosition = linkedPosition;
    //     this.LinkedRoom = linkedRoom;
    // }

    public DoorTile() : base(TileType.DOOR) {
        
    }
    
    public void ConfigureDoor(int x, int y, string linkedRoom) {
        Debug.Log($"Linked door to {linkedRoom}({x},{y})");
        LinkedPosition = new Vector2Int(x, y);
        LinkedRoom = linkedRoom;
    }
}