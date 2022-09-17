using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    [SerializeField] private TileGO floorTilePrefab;
    [SerializeField] private TileGO wallTilePrefab;
    [SerializeField] private TileGO doorTilePrefab;
    [SerializeField] private TileGO emptyTilePrefab;
    [SerializeField] private GameObject goalPrefab;
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private DarknessTileGO darknessTilePrefab;

    private List<Room> _rooms = null;

    private static RoomManager _instance;


    public GameObject GoalPrefab => goalPrefab;
    public GameObject TrapPrefab => trapPrefab;
    public GameObject ObstaclePrefab => obstaclePrefab;

    public Room CurrentRoom { get; private set; }
    private DarknessTileGO[,] DarknessSprites { get; set; }

    public static RoomManager Instance {
        get {
            if (_instance == null) {
                throw new Exception("Tried to get a RoomManager Instance, but is null!");
            }

            return _instance;
        }
        private set {
            if (_instance != null) {
                throw new Exception("RoomManager is already set!");
            }

            _instance = value;
        }
    }

    private void Awake() {
        Instance = this;
    }

    public void ChangeToRoom(string roomName, Vector2Int doorEnteredThrough, Player player) {
        Debug.Log($"Changing from {CurrentRoom?.Name} to Room {roomName}");
        DestroyCurrentRoomTiles();
        Room room = Rooms.Find(room1 => room1.Name == roomName);
        InstantiateTileGOs(room);
        player.SetPosition(doorEnteredThrough);

        CurrentRoom = room;
    }

    private void InstantiateTileGOs(Room room) {
        DarknessSprites = new DarknessTileGO[room.height, room.width];
        for (int y = 0; y < room.height; y++) {
            for (int x = 0; x < room.width; x++) {
                var tile = room.GetTileAt(x, y);
                var prefab = tile.Type switch {
                    TileType.FLOOR => floorTilePrefab,
                    TileType.WALL => wallTilePrefab,
                    TileType.DOOR => doorTilePrefab,
                    TileType.EMPTY => emptyTilePrefab,
                    _ => floorTilePrefab
                };
                // Debug.Log($"Instantiating {tile.Type} at ({x},{y})");
                var tileObject = Instantiate(prefab.gameObject, this.transform, true);
                tileObject.GetComponent<TileGO>().ConnectedTile = tile;
                tileObject.transform.position = new Vector3(x, y);
                tile.ItemOnTile?.CreateGO();

                var darknessTile = Instantiate(darknessTilePrefab);
                darknessTile.transform.position = new Vector3(x, y);
                DarknessSprites[y, x] = darknessTile.GetComponent<DarknessTileGO>();
                darknessTile.ConnectedTile = tile;
            }
        }
    }

    private void DestroyCurrentRoomTiles() {
        if (CurrentRoom == null) {
            return;
        }

        Debug.Log("Destroying All Tiles");
        Debug.Log(transform.childCount);
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform) {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren) {
            // var tileGO = child.GetComponent<TileGO>();
            // if (tileGO == null) continue;
            // tileGO.ConnectedTile.ItemOnTile?.DeleteGO();
            DestroyImmediate(child.gameObject);
        }

        Debug.Log(transform.childCount);

        CurrentRoom.RemoveAllItemGameObjects();

        // destroy the darkness tiles to redraw them again on each tile of the new level.
        foreach (var darknessSprite in DarknessSprites) {
            Destroy(darknessSprite.gameObject);
        }

        DarknessSprites = new DarknessTileGO[0, 0];
    }


    public List<Room> Rooms {
        get { return _rooms ??= RoomLayouts.GetTestRooms(); }
    }

    public DarknessTileGO GetDarknessTileGOAt(int x, int y) {
        try {
            return DarknessSprites[y, x];
        }
        catch (Exception) {
            return null;
        }
    }
}