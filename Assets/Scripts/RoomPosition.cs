using System;
using UnityEngine;

[Serializable]
public class RoomPosition {
    [SerializeField]private string roomName;
    [SerializeField] private Vector2Int position;

    public string RoomName => roomName;

    public Vector2Int Position => position;

    public RoomPosition(string roomName, Vector2Int position) {
        this.roomName = roomName;
        this.position = position;
    }
}