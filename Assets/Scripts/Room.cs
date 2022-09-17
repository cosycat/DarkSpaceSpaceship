using System;
using UnityEngine;

public class Room {
    public string Name { get; set; }
    public Tile[,] RoomMap { get; set; }

    public int height { get; private set; }
    public int width { get; private set; }

    public Tile GetTileAt(int x, int y) {
        return RoomMap[y, x];
    }

    public Room(string name, int width, int height, Tile[,] roomMap) {
        Name = name;
        RoomMap = roomMap;
        this.height = height;
        this.width = width;
    }

    public Room(string name, int width, int height, string layoutString) {
        Name = name;
        RoomMap = new Tile[height, width];
        this.height = height;
        this.width = width;
        var layoutCharArray = layoutString.ToCharArray();
        int pos = 0;
        for (int y = height - 1; y >= 0; y--) {
            for (int x = 0; x < width; x++) {
                Tile tile;
                var c = layoutCharArray[pos++];
                switch (c) {
                    case 'W':
                        tile = new Tile(TileType.WALL);
                        break;
                    case 'F':
                        tile = new Tile(TileType.FLOOR);
                        break;
                    case 'D':
                        tile = new DoorTile();
                        break;
                    case 'G':
                        tile = new Tile(Item.CreateGoalItem(x, y, this));
                        break;
                    case 'T':
                        tile = new Tile(Item.CreateTrapItem(x, y, this));
                        break;
                    case 'O':
                        tile = new Tile(Item.CreateObstacleItem(x, y, this));
                        break;
                    default:
                        Debug.Log($"Skipped {c} in room {name}");
                        continue;
                }

                // Debug.Log($"Created {tile.Type}-Tile at ({x}/{y}) for Room {name}");
                RoomMap[y, x] = tile;
            }
        }
    }
}