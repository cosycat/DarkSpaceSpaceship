using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour {
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    
    public static Player Instance { get; private set; }

    private Room _currRoom;
    
    [SerializeField] private float movementTime = 0.3f;
    [SerializeField] private float movementPauseTime = 0.5f;
    
    [SerializeField] private Vector2Int currGridPosition = Vector2Int.zero;

    public Animator PlayerAnimator { get; private set; }


    private Vector2Int _goalPosition = Vector2Int.zero;
    private Vector2Int _startPosition = Vector2Int.zero;
    private float _moveStartTime;

    private bool _isMoving = false;
    public bool IsMoving {
        get => _isMoving;
        private set {
            if (value) {
                PlayerAnimator.SetBool(IsRunning, true);
                AudioManager.Instance.Play("Waddle");
            } else {
                PlayerAnimator.SetBool(IsRunning, false);
                AudioManager.Instance.Stop("Waddle");
            }
            _isMoving = value;
        }
    }

    public bool IsDead { get; private set; } = false;


    public Vector2Int GoalPosition {
        get => _goalPosition;
        private set => _goalPosition = value;
    }

    private float _currentMovementPauseTime = 0; // Time the movement is paused after e.g. after running into a wall.
    private Flashlight _flashlight;

    private void Awake() {
        _flashlight = GetComponent<Flashlight>();
        if (Instance != null) {
            Debug.LogError("TWO PLAYERS");
            DestroyImmediate(Instance);
        }
        Instance = this;
    }

    private void Start() {
        PlayerAnimator = GetComponent<Animator>();
        Debug.Log("Player Start");
    }

    private void FixedUpdate() {
        HandleMovement();
    }
    
    private void Update() {
        GetMovementInput();
        if (_currentMovementPauseTime > 0) _currentMovementPauseTime -= Time.deltaTime;
    }

    private void HandleMovement() {
        if (IsDead || !IsMoving) return;
        // Debug.Log("Player::Handle Movement");
        var currMovementTime = (Time.timeSinceLevelLoad - _moveStartTime) / movementTime;
        if (currMovementTime > 1) {
            // Debug.Log("Reach goal tile");
            // We reached our next tile
            transform.position = new Vector3(_goalPosition.x, _goalPosition.y);
            currGridPosition = _goalPosition;
            IsMoving = false;

            var goalTile = RoomManager.Instance.CurrentRoom.GetTileAt(_goalPosition.x, _goalPosition.y);
            if (goalTile == null) throw new Exception($"We moved onto a non existing tile at ({_goalPosition.x},{_goalPosition.y}) in room {RoomManager.Instance.CurrentRoom.Name}");
            
            if (goalTile.Type is TileType.DOOR_H_00 or TileType.DOOR_V_01 ) {
                Debug.Log("Moved to a door!");
                DoorTile doorTile = (DoorTile)goalTile;
                if (doorTile.LinkedRoom != null && doorTile.LinkedPosition != null) {
                    RoomManager.Instance.ChangeToRoom(doorTile.LinkedRoom, (Vector2Int)doorTile.LinkedPosition, this);
                }
            }
            else if (goalTile.Type == TileType.DROP_OFF) {
                OnDropOffPointReached();
            }
            else if (goalTile.ItemOnTile is { Type: ItemType.GOAL }) {
                // Debug.Log("Moved to goal!");
                if (RoomManager.Instance.CurrentHeldItem == null) {
                    goalTile.ConsumeItem();
                } else {
                    AudioManager.Instance.Play("FailedAction");
                }
            } else if (goalTile.ItemOnTile is { Type: ItemType.RECHARGE}) {
                _flashlight.Recharge();
                goalTile.ConsumeItem();
            }
            else if (goalTile.ItemOnTile is {Type: ItemType.TRAP}) {
                // DIIIEEEE
                Die(goalTile);
            }
                
            return;
        }

        Vector3 goalPos3D = new Vector3(_goalPosition.x, _goalPosition.y);
        Vector3 startPos3D = new Vector3(_startPosition.x, _startPosition.y);
        transform.position = Vector3.Lerp(startPos3D, goalPos3D, currMovementTime);
        
    }

    private void OnDropOffPointReached() {
        if (RoomManager.Instance.CurrentHeldItem != null) {
            AudioManager.Instance.Play("UnloadItem");
            RoomManager.Instance.CurrentHeldItem = null;
            RoomManager.Instance.CurrGoalItems = RoomManager.Instance.CurrGoalItems + 1;
            if (RoomManager.Instance.CurrGoalItems >= RoomManager.Instance.TotalGoalItemsNeeded) {
                GameController.Instance.HandleWin();
            }
        }
        else {
            AudioManager.Instance.Play("FailedAction");
        }
    }

    private void Die(Tile tileToDieOn) {
        GetComponent<SpriteRenderer>().enabled = false;
        tileToDieOn.ItemOnTile = Item.CreateDeathItem(_goalPosition.x, _goalPosition.y, RoomManager.Instance.CurrentRoom);
        tileToDieOn.ItemOnTile!.CreateGO();
        _flashlight.Flash(3, 1.5f);
        AudioManager.Instance.Play("DeathAndScream");
        IsDead = true;
    }

    private void GetMovementInput() {
        if (IsDead || IsMoving || _currentMovementPauseTime > 0) {
            return;
        }

        _startPosition = currGridPosition;
        _goalPosition = _startPosition;
        _moveStartTime = Time.timeSinceLevelLoad;
        int angle = 0;
        if (Input.GetAxis("Horizontal") < 0) {
            _goalPosition.x -= 1;
            angle = 90;
        }
        else if (Input.GetAxis("Horizontal") > 0) {
            _goalPosition.x += 1;
            angle = -90;
        }
        else if (Input.GetAxis("Vertical") < 0) {
            _goalPosition.y -= 1;
            angle = 180;
        }
        else if (Input.GetAxis("Vertical") > 0) {
            _goalPosition.y += 1;
            angle = 0;
        }

        if (_goalPosition != _startPosition) {
            var goalTile = RoomManager.Instance.CurrentRoom.GetTileAt(_goalPosition.x, _goalPosition.y);
            if (!CheckMovement(goalTile)) {
                _currentMovementPauseTime = movementPauseTime;
                return;
            }
            IsMoving = true;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            var goalDarknessTGO = RoomManager.Instance.GetDarknessTileGOAt(_goalPosition.x, _goalPosition.y);
            goalDarknessTGO.Brighten(movementTime);
            var currentDarknessTGO = RoomManager.Instance.GetDarknessTileGOAt(currGridPosition.x, currGridPosition.y);
            currentDarknessTGO.Darken(movementTime);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="goalTile">The tile to move to</param>
    /// <returns>True if movement is possible</returns>
    private bool CheckMovement(Tile goalTile) {
        if (goalTile == null || goalTile.Type is TileType.WALL or TileType.EMPTY) {
            // It can be null, if we are on a door and try to immediately turn back.
            // Debug.Log("wall");
            AudioManager.Instance.Play("BumpWall");
            return false;
        }

        if (goalTile.ItemOnTile is { Type: ItemType.OBSTACLE }) {
            // Debug.Log("obstacle");
            AudioManager.Instance.Play("BumpWall"); // Todo maybe different sound for obstacle than wall
            return false;
        }

        if (goalTile.ItemOnTile is {Type: ItemType.TRAP}) {
            Debug.Log("Walking on a TRAP");
            return true;
        }

        if (goalTile.Type is TileType.DOOR_H_00 or TileType.DOOR_V_01) {
            AudioManager.Instance.Play("Door");
        }

        return true;
    }

    public void SetPosition(Vector2Int pos, bool darkenPreviousTile = false) {
        if (darkenPreviousTile) {
            RoomManager.Instance.GetDarknessTileGOAt(currGridPosition.x, currGridPosition.y).Darken(0);
        }
        currGridPosition = pos;
        transform.position = new Vector3(pos.x, pos.y);
        RoomManager.Instance.GetDarknessTileGOAt(currGridPosition.x, currGridPosition.y).Brighten(0);
    }
}
