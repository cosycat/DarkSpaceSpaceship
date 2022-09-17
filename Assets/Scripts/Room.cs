using System;
using JetBrains.Annotations;
using UnityEngine;

public class Room {
    public string Name { get; set; }
    public Tile[,] RoomMap { get; set; }

    public int height { get; private set; }
    public int width { get; private set; }

    [CanBeNull]
    public Tile GetTileAt(int x, int y) {
        if (x < 0 || x >= width || y < 0 || y >= height) {
            return null;
        }
        return RoomMap[y, x];
    }

    public Room(string name, int width, int height, Tile[,] roomMap) {
        Name = name;
        RoomMap = roomMap;
        this.height = height;
        this.width = width;
    }

    public Room(string name, int width, int height, string[] layoutStrings) {
        Name = name;
        RoomMap = new Tile[height, width];
        this.height = height;
        this.width = width;
        int pos = 0;
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                Tile tile;
                var tileString = layoutStrings[pos++];
                var typeChar = tileString[0];
                var typeNumber = Int32.Parse(tileString[1..]);
                switch (typeChar) {
                    case 'W':
                        tile = new Tile(TileType.WALL);
                        break;
                    case 'F':
                        tile = new Tile(TileType.FLOOR);
                        break;
                    case 'D':
                        tile = new DoorTile();
                        break;
                    case 'E':
                        tile = new Tile(TileType.EMPTY);
                        break;
                    case 'G':
                        tile = new Tile(Item.CreateGoalItem(x, y, this, typeNumber));
                        break;
                    case 'T':
                        tile = new Tile(Item.CreateTrapItem(x, y, this, typeNumber));
                        break;
                    case 'O':
                        tile = new Tile(Item.CreateObstacleItem(x, y, this, typeNumber));
                        break;
                    case 'R':
                        tile = new Tile(Item.CreateRechargeItem(x, y, this, typeNumber));
                        break;
                    default:
                        Debug.Log($"Skipped {tileString} in room {name}");
                        continue;
                }

                // if (c is 'D' or 'G') {
                //     Debug.Log($"Created {tile.Type}-Tile at ({x}/{y}) for Room {name}");
                // }
                RoomMap[y, x] = tile;
            }
        }
        
    }

    // public Room(string name, int width, int height, string layoutString) {
    //     Name = name;
    //     RoomMap = new Tile[height, width];
    //     this.height = height;
    //     this.width = width;
    //     var layoutCharArray = layoutString.ToCharArray();
    //     int pos = 0;
    //     for (int y = 0; y < height; y++) {
    //         for (int x = 0; x < width; x++) {
    //             Tile tile;
    //             var c = layoutCharArray[pos++];
    //             switch (c) {
    //                 case 'W':
    //                     tile = new Tile(TileType.WALL);
    //                     break;
    //                 case 'F':
    //                     tile = new Tile(TileType.FLOOR);
    //                     break;
    //                 case 'D':
    //                     tile = new DoorTile();
    //                     break;
    //                 case 'G':
    //                     tile = new Tile(Item.CreateGoalItem(x, y, this));
    //                     break;
    //                 case 'T':
    //                     tile = new Tile(Item.CreateTrapItem(x, y, this));
    //                     break;
    //                 case 'O':
    //                     tile = new Tile(Item.CreateObstacleItem(x, y, this));
    //                     break;
    //                 case 'E':
    //                     tile = new Tile(TileType.EMPTY);
    //                     break;
    //                 case 'R':
    //                     tile = new Tile(Item.CreateRechargeItem(x, y, this));
    //                     break;
    //                 default:
    //                     Debug.Log($"Skipped {c} in room {name}");
    //                     continue;
    //             }
    //
    //             // if (c is 'D' or 'G') {
    //             //     Debug.Log($"Created {tile.Type}-Tile at ({x}/{y}) for Room {name}");
    //             // }
    //             RoomMap[y, x] = tile;
    //         }
    //     }
    // }

    public void RemoveAllItemGameObjects() {
        foreach (var tile in RoomMap) {
            tile.ItemOnTile?.DeleteGO();
        }
    }
}