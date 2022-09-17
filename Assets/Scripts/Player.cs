using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Room _currRoom;
    
    [SerializeField] private float movementTime = 0.3f;
    [SerializeField] private float movementPauseTime = 0.5f;

    [SerializeField] private Vector2Int currGridPosition = Vector2Int.zero;

    private Vector2Int _goalPosition = Vector2Int.zero;
    private Vector2Int _startPosition = Vector2Int.zero;
    private float _moveStartTime;
    private bool _isMoving = false;
    private float _currentMovementPauseTime = 0; // Time the movement is paused after e.g. after running into a wall.

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
        if (_currentMovementPauseTime > 0) _currentMovementPauseTime -= Time.deltaTime;
    }

    private void HandleMovement() {
        if (!_isMoving) return;
        // Debug.Log("Player::Handle Movement");
        var currMovementTime = (Time.timeSinceLevelLoad - _moveStartTime) / movementTime;
        if (currMovementTime > 1) {
            // Debug.Log("Reach goal tile");
            // We reached our next tile
            transform.position = new Vector3(_goalPosition.x, _goalPosition.y);
            currGridPosition = _goalPosition;
            _isMoving = false;
                
            var goalTile = RoomManager.Instance.CurrentRoom.GetTileAt(_goalPosition.x, _goalPosition.y);
            if (goalTile == null) throw new Exception($"We moved onto a non existing tile at ({_goalPosition.x},{_goalPosition.y}) in room {RoomManager.Instance.CurrentRoom.Name}");
            
            if (goalTile is { Type: TileType.DOOR }) {
                Debug.Log("Moved to a door!");
                DoorTile doorTile = (DoorTile)goalTile;
                RoomManager.Instance.ChangeToRoom(doorTile.LinkedRoom, doorTile.LinkedPosition, this);
            }
            else if (goalTile.ItemOnTile is { Type: ItemType.GOAL }) {
                // Debug.Log("Moved to goal!");
                goalTile.ConsumeItem();
            }
                
            return;
        }

        Vector3 goalPos3D = new Vector3(_goalPosition.x, _goalPosition.y);
        Vector3 startPos3D = new Vector3(_startPosition.x, _startPosition.y);
        transform.position = Vector3.Lerp(startPos3D, goalPos3D, currMovementTime);
    }

    private void GetMovementInput() {
        if (_isMoving || _currentMovementPauseTime > 0) {
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
            if (!CheckMovement(goalTile)) {
                _currentMovementPauseTime = movementPauseTime;
                return;
            }

            // TODO check for traps
            _isMoving = true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="goalTile">The tile to move to</param>
    /// <returns>True if movement is possible</returns>
    private bool CheckMovement(Tile goalTile) {
        if (goalTile == null || goalTile.Type == TileType.WALL) {
            // It can be null, if we are on a door and try to immediately turn back.
            // Debug.Log("wall");
            return false;
        }

        if (goalTile.ItemOnTile is { Type: ItemType.OBSTACLE }) {
            // Debug.Log("obstacle");
            return false;
        }

        if (goalTile.ItemOnTile is {Type: ItemType.TRAP}) {
            Debug.Log("HIT A TRAP");
            // TODO handle getting hit.
            return false;
        }

        return true;
    }

    public void SetPosition(Vector2Int pos) {
        currGridPosition = pos;
        transform.position = new Vector3(pos.x, pos.y);
    }
}
