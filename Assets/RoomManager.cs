using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    [SerializeField] private GameObject freeTilePrefab;
    [SerializeField] private GameObject wallTilePrefab;
    [SerializeField] private GameObject doorTilePrefab;
    private GameObject goalTilePrefab;
    private GameObject basicTrapTilePrefab;
    private GameObject batteryTilePrefab;

    public Room CurrentRoom { get; private set; }

    public static RoomManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public void ChangeToRoom(string roomName, Vector2Int doorEnteredThrough, Player player) {
        Room room = Rooms.Find(room1 => room1.Name == roomName);
        for (int y = 0; y < room.height; y++) {
            for (int x = 0; x < room.width; x++) {
                var tile = room.GetTileAt(x, y);
                GameObject prefab = tile.Type switch {
                    TileType.FREE => freeTilePrefab,
                    TileType.WALL => wallTilePrefab,
                    TileType.DOOR => doorTilePrefab,
                    _ => freeTilePrefab
                };
                GameObject tileObject = Instantiate(prefab);
                tileObject.transform.position = new Vector3(x, y);
            }
        }
        player.SetPosition(doorEnteredThrough);

        CurrentRoom = room;
    }
    
    
    public List<Room> Rooms => new List<Room>(new Room[]{
        new Room("Room1", new[] {
            new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(TileType.GOAL), new Tile(), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new DoorTile(2,0, "Room2"), new Tile(TileType.WALL) },
        }),
        new Room("Room2", new[] {
            new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new DoorTile(2,3, "Room1"), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(), new Tile(), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(TileType.GOAL), new Tile(), new Tile(TileType.WALL) },
            new[] { new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL), new Tile(TileType.WALL) },
        })
    });


}