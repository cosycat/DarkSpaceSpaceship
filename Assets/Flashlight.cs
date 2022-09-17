using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    [SerializeField] private float flashTimerDuration = 1;
    private float _flashTimer = 0;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            HandleFlashInput();
        }
    }

    private void HandleFlashInput() {
        if (_flashTimer > 0) {
            _flashTimer -= Time.deltaTime;
            return;
        }

        RoomManager.Instance.GetAllDarknessTiles().;
    }
}