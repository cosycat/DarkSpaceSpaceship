using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    [SerializeField] private TileGO floorTilePrefab;
    [SerializeField] private TileGO wallTilePrefab;
    [SerializeField] private TileGO doorHor00TilePrefab;
    [SerializeField] private TileGO doorVert01TilePrefab;
    [SerializeField] private TileGO emptyTilePrefab;
    
    [SerializeField] private List<GameObject> goalPrefabs;
    [SerializeField] private List<GameObject> trapPrefabs;
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private List<GameObject> rechargePrefabs;
    [SerializeField] private GameObject deathPrefab;

    [SerializeField] private DarknessTileGO darknessTilePrefab;
    [SerializeField] private Player playerPrefab;

    [SerializeField] private Vector2Int spawnPoint;
    [SerializeField] private string spawnRoom;
    private float _deathTimer = 5f; // Time from moment of death until respawn.

    private List<Room> _rooms = null;

    private static RoomManager _instance;

    public GameObject DeathPrefab => deathPrefab;
    public List<GameObject> GoalPrefabs => goalPrefabs;
    public List<GameObject> TrapPrefabs => trapPrefabs;
    public List<GameObject> ObstaclePrefabs => obstaclePrefabs;
    public List<GameObject> RechargePrefabs => rechargePrefabs;
    
    public static GameObject InvisiblePrefab => new GameObject("Invisible",typeof(SpriteRenderer));



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

    private void Start() {
        SpawnPlayer();
    }

    private void Update() {
        if (Player.Instance.IsDead) {
            _deathTimer -= Time.deltaTime;
            if (_deathTimer <= 0) {
                RoomManager.Instance.SpawnPlayer();
            }
        }
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
                    TileType.DOOR_H_00 => doorHor00TilePrefab,
                    TileType.DOOR_V_01 => doorVert01TilePrefab,
                    TileType.EMPTY => emptyTilePrefab,
                    _ => floorTilePrefab
                };
                // Debug.Log($"Instantiating {tile.Type} at ({x},{y})");
                GameObject tileObject = Instantiate(prefab.gameObject, this.transform, true);
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

    public DarknessTileGO[,] GetAllDarknessTiles() {
        return DarknessSprites;
    }

    public void SpawnPlayer() {
        if (Player.Instance != null) {
            DestroyImmediate(Player.Instance);
        }
        ChangeToRoom(spawnRoom, spawnPoint, Instantiate(playerPrefab));
    }
    
}