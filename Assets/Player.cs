using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Room _currRoom;
    
    [SerializeField] private float movementTime = 1;

    [SerializeField] private Vector2Int currGridPosition = Vector2Int.zero;

    private Vector3 _goalPosition = Vector3.zero;
    private Vector3 _startPosition = Vector3.zero;
    private float _moveStartTime;
    private bool _isMoving = false;
    
    // Start is called before the first frame update
    void Start() {
        RoomManager.Instance.ChangeToRoom("Room1", new Vector2Int(2, 1), this);
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    // Update is called once per frame

    void Update() {
        GetMovementInput();
    }

    private void HandleMovement() {
        if (!_isMoving) return;
        var currMovementTime = (Time.timeSinceLevelLoad - _moveStartTime) / movementTime;
        if (currMovementTime > 1) {
            // We reached our goal
            transform.position = _goalPosition;
            currGridPosition = new Vector2Int((int)_goalPosition.x, (int)_goalPosition.y);
            _isMoving = false;
                
            var goalTile = RoomManager.Instance.CurrentRoom.GetTileAt((int)_goalPosition.x, (int)_goalPosition.y);
            if (goalTile.Type == TileType.DOOR) {
                DoorTile doorTile = (DoorTile)goalTile;
                RoomManager.Instance.ChangeToRoom(doorTile.LinkedRoom, doorTile.LinkedPosition, this);
            }
                
            return;
        }

        transform.position = Vector3.Lerp(_startPosition, _goalPosition, currMovementTime);
    }

    private void GetMovementInput() {
        if (_isMoving) {
            return;
        }

        _startPosition = new Vector3(currGridPosition.x, currGridPosition.y, 0);
        _goalPosition = _startPosition;
        _moveStartTime = Time.timeSinceLevelLoad;
        if (Input.GetAxis("Horizontal") < 0) {
            _goalPosition.x -= 1;
        }
        else if (Input.GetAxis("Horizontal") > 0) {
            _goalPosition.x += 1;
        }
        else if (Input.GetAxis("Vertical") < 0) {
            _goalPosition.y -= 1;
        }
        else if (Input.GetAxis("Vertical") > 0) {
            _goalPosition.y += 1;
        }

        if (_goalPosition != _startPosition) {
            var goalTile = RoomManager.Instance.CurrentRoom.GetTileAt((int)_goalPosition.x, (int)_goalPosition.y);
            if (goalTile.Type == TileType.WALL) {
                Debug.Log("RUN INTO WALL");
                return;
            }

            // TODO check for traps
            _isMoving = true;
        }
    }

    public void SetPosition(Vector2Int pos) {
        currGridPosition = pos;
        transform.position = new Vector3(pos.x, pos.y);
    }
}
