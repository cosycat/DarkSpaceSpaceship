using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    [SerializeField] private TileGO floorTilePrefab;
    [SerializeField] private TileGO wallTilePrefab;
    [SerializeField] private TileGO doorTilePrefab;
    [SerializeField] private GameObject goalPrefab;
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private GameObject obstaclePrefab;
    
    private List<Room> _rooms = null;
    
    private static RoomManager _instance;


    public GameObject GoalPrefab => goalPrefab;
    public GameObject TrapPrefab => trapPrefab;
    public GameObject ObstaclePrefab => obstaclePrefab;

    public Room CurrentRoom { get; private set; }

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
        for (int y = 0; y < room.height; y++) {
            for (int x = 0; x < room.width; x++) {
                var tile = room.GetTileAt(x, y);
                var prefab = tile.Type switch {
                    TileType.FLOOR => floorTilePrefab,
                    TileType.WALL => wallTilePrefab,
                    TileType.DOOR => doorTilePrefab,
                    _ => floorTilePrefab
                };
                Debug.Log($"Instantiating {tile.Type} at ({x},{y})");
                var tileObject = Instantiate(prefab.gameObject, this.transform, true);
                tileObject.GetComponent<TileGO>().ConnectedTile = tile;
                tileObject.transform.position = new Vector3(x, y);

                tile.ItemOnTile?.CreateGO();
            }
        }
        player.SetPosition(doorEnteredThrough);

        CurrentRoom = room;
    }

    private void DestroyCurrentRoomTiles() {
        while (transform.childCount > 0) {
            var tileGO = transform.GetChild(0).GetComponent<TileGO>();
            if (tileGO == null) continue;
            tileGO.ConnectedTile.ItemOnTile?.DeleteGO();
            Destroy(tileGO);
        }
    }


    public List<Room> Rooms {
        get { return _rooms ??= RoomLayouts.GetTestRooms(); }
    }
}