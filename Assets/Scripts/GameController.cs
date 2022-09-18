using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private Player playerPrefab;

    [SerializeField] private Vector2Int spawnPoint;
    [SerializeField] private string spawnRoom;
    
    [SerializeField] private float deathTimer = 5f; // Time from moment of death until respawn.

    public static GameController Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            DestroyImmediate(Instance.gameObject);
        }
        Instance = this;
    }

    private void Start() {
        SpawnPlayerInitial();
    }

    private void Update() {
        if (Player.Instance.IsDead) {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0) {
                ReSpawnPlayer();
            }
        }
    }

    public void ReSpawnPlayer() {
        // SpawnPlayerInitial(); // TODO
    }
    
    
    public void SpawnPlayerInitial() {
        SpawnPlayerAt(spawnRoom, spawnPoint.x, spawnPoint.y);
    }

    private void SpawnPlayerAt(string roomName, int x, int y) {
        if (Player.Instance != null) {
            DestroyImmediate(Player.Instance);
        }
        RoomManager.Instance.ChangeToRoom(roomName, new Vector2Int(x, y), Instantiate(playerPrefab));
    }
    
}