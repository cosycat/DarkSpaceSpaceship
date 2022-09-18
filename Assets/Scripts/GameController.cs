using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool IsPlaying { get; private set; } = true;
    
    [SerializeField] private Player playerPrefab;

    // [SerializeField] private Vector2Int spawnPoint;
    // [SerializeField] private string spawnRoom;
    [SerializeField] private RoomPosition startingPoint;
    
    private const int RespawnObjectNumber = 08;
    
    [SerializeField] private float deathTime = 5f; // Time from moment of death until respawn.
    private float _deathTimer;

    private List<RoomPosition> _cryoChamberRespawnPoints;

    public static GameController Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            DestroyImmediate(Instance.gameObject);
        }
        Instance = this;
        _deathTimer = deathTime;
    }

    private void Start() {
        FindRespawnPoints();
        
        SpawnPlayerInitial();
    }

    private void FindRespawnPoints() {
        _cryoChamberRespawnPoints = new List<RoomPosition>();
        foreach (var room in RoomManager.Instance.Rooms) {
            for (var y = 0; y < room.height; y++) {
                for (var x = 0; x < room.width; x++) {
                    var tile = room.GetTileAt(x, y);
                    if (tile.ItemOnTile != null) {
                        Debug.Log($"FindRespawnPoints - checking tile ({x},{y}) = {tile.ItemOnTile.Type}:{tile.ItemOnTile.ItemNumber}");
                    }
                    if (tile is { ItemOnTile: { Type: ItemType.OBSTACLE, ItemNumber: RespawnObjectNumber } }) {
                        _cryoChamberRespawnPoints.Add(new RoomPosition(room.Name, new Vector2Int(x, y)));
                        Debug.Log("Found Cryochamber");
                    }
                }
            }
        }
    }

    private void Update() {
        if (!IsPlaying) {
            return;
        }
        if (Player.Instance.IsDead) {
            _deathTimer -= Time.deltaTime;
            if (_deathTimer <= 0) {
                _deathTimer = deathTime;
                ReSpawnPlayer();
            }
        }
    }

    public void ReSpawnPlayer() {
        if (_cryoChamberRespawnPoints.Count == 0) {
            // TODO GAME OVER
            Debug.Log("GAME OVER");
            IsPlaying = false;
            return;
        }

        var respawnPoint = _cryoChamberRespawnPoints[0];
        _cryoChamberRespawnPoints.Remove(respawnPoint);
        var itemOnTile = RoomManager.Instance.GetRoomWithName(respawnPoint.RoomName)!
            .GetTileAt(respawnPoint.Position.x, respawnPoint.Position.y)!.ItemOnTile;
        if (itemOnTile != null)
            itemOnTile.SetCryochamberToUsed();
        else
            throw new Exception("No cryochamber found");

        SpawnPlayerAt(respawnPoint);
    }

    public void SpawnPlayerInitial() {
        SpawnPlayerAt(startingPoint);
    }
    

    private void SpawnPlayerAt(RoomPosition respawnPoint) {
        SpawnPlayerAt(respawnPoint.RoomName, respawnPoint.Position);
    }

    private void SpawnPlayerAt(string roomName, Vector2Int pos) {
        if (Player.Instance != null) {
            DestroyImmediate(Player.Instance);
        }
        RoomManager.Instance.ChangeToRoom(roomName, pos, Instantiate(playerPrefab));
    }
    
}