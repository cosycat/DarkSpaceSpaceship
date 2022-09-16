using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float speed = 1;

    [SerializeField] private float movementTime = 1;

    [SerializeField] private Vector2Int currGridPosition = Vector2Int.zero;

    private Vector3 _goalPosition = Vector3.zero;
    private Vector3 _startPosition = Vector3.zero;
    private float _moveStartTime;
    private bool _isMoving = false;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    // Update is called once per frame

    void Update() {
        GetMovementInput();
    }

    private void HandleMovement() {
        if (_isMoving) {
            float currMovementTime = (Time.timeSinceLevelLoad - _moveStartTime) / movementTime;
            if (currMovementTime > 1) {
                // We reached our goal
                transform.position = _goalPosition;
                currGridPosition = new Vector2Int((int)_goalPosition.x, (int)_goalPosition.y);
                _isMoving = false;
                return;
            }

            transform.position = Vector3.Lerp(_startPosition, _goalPosition, currMovementTime);
        }
    }

    private void GetMovementInput() {
        if (_isMoving) {
            return;
        }

        _startPosition = new Vector3(currGridPosition.x, currGridPosition.y, 0);
        _goalPosition = _startPosition;
        _moveStartTime = Time.timeSinceLevelLoad;
        if (Input.GetAxis("Horizontal") < 0) {
            _isMoving = true;
            _goalPosition.x -= 1;
        }
        else if (Input.GetAxis("Horizontal") > 0) {
            _isMoving = true;
            _goalPosition.x += 1;
        }
        else if (Input.GetAxis("Vertical") < 0) {
            _isMoving = true;
            _goalPosition.y -= 1;
        }
        else if (Input.GetAxis("Vertical") > 0) {
            _isMoving = true;
            _goalPosition.y += 1;
        }
    }
}
