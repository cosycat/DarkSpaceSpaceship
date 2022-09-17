using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Room _currRoom;
    
    [SerializeField] private float movementTime = 1;

    [SerializeField] private Vector2Int currGridPosition = Vector2Int.zero;

    private Vector2Int _goalPosition = Vector2Int.zero;
    private Vector2Int _startPosition = Vector2Int.zero;
    private float _moveStartTime;
    private bool _isMoving = false;
    
    // Start is called before the first frame update
    private void Start() {
        Debug.Log(RoomManager.Instance == null);
        Debug.Log(RoomManager.Instance);
        RoomManager.Instance.ChangeToRoom("Room1", new Vector2Int(2, 1), this);
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    // Update is called once per frame

    private void Update() {
        GetMovementInput();
    }

    private void HandleMovement() {
        if (!_isMoving) return;
        // Debug.Log("Player::Handle Movement");
        var currMovementTime = (Time.timeSinceLevelLoad - _moveStartTime) / movementTime;
        if (currMovementTime > 1) {
            Debug.Log("Reach goal tile");
            // We reached our goal
            transform.position = new Vector3(_goalPosition.x, _goalPosition.y);
            currGridPosition = _goalPosition;
            _isMoving = false;
                
            var goalTile = RoomManager.Instance.CurrentRoom.GetTileAt(_goalPosition.x, _goalPosition.y);
            if (goalTile.Type == TileType.DOOR) {
                Debug.Log("Moved to a door!");
                DoorTile doorTile = (DoorTile)goalTile;
                RoomManager.Instance.ChangeToRoom(doorTile.LinkedRoom, doorTile.LinkedPosition, this);
            }
                
            return;
        }

        Vector3 goalPos3D = new Vector3(_goalPosition.x, _goalPosition.y);
        Vector3 startPos3D = new Vector3(_startPosition.x, _startPosition.y);
        transform.position = Vector3.Lerp(startPos3D, goalPos3D, currMovementTime);
    }

    private void GetMovementInput() {
        if (_isMoving) {
            return;
        }

        _startPosition = currGridPosition;
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
            var goalTile = RoomManager.Instance.CurrentRoom.GetTileAt(_goalPosition.x, _goalPosition.y);
            if (goalTile == null || goalTile.Type == TileType.WALL) { // It can be null, if we are on a door and try to immediately turn back.
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
