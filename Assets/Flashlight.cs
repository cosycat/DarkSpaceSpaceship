using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    [SerializeField] private float flashReloadDuration = 1;
    private float _flashReloadTimer = 0;

    [SerializeField] private float flashStayTime = 1f;
    [SerializeField] private float flashFadeTime = 1f;
    private Player _player;

    private void Awake() {
        _player = GetComponent<Player>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            HandleFlashInput();
        }
    }

    private void HandleFlashInput() {
        if (_flashReloadTimer > 0) {
            _flashReloadTimer -= Time.deltaTime;
            return;
        }
        if (_player.IsMoving) return;
        foreach (var darknessTileGO in RoomManager.Instance.GetAllDarknessTiles()) {
            darknessTileGO.Brighten(0, 0);
            darknessTileGO.Darken(flashFadeTime, flashStayTime);
        }
    }
}