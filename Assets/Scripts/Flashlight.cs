using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    [SerializeField] private int rechargeAmount = 4;

    [SerializeField] private float flashReloadDuration = 1;
    private float _flashReloadTimer = 0;

    [SerializeField] private float flashStayTime = 1f;
    [SerializeField] private float flashFadeTime = 1f;
    private Player _player;
    
    [SerializeField] private int charges = 6;
    
    public int Charges {
        get => charges;
        private set => charges = value;
    }

    private void Awake() {
        _player = GetComponent<Player>();
    }

    private void Update() {
        if (_flashReloadTimer > 0) {
            _flashReloadTimer -= Time.deltaTime;
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            HandleFlashInput();
        }
    }

    private void HandleFlashInput() {
        if (_player.IsMoving) return;
        if (Charges <= 0) return;
        _flashReloadTimer = flashReloadDuration;
        Charges -= 1;
        Flash();
    }

    public void Flash(float flashFadeTime, float flashStayTime) {
        Debug.Log("Flash!");
        foreach (var darknessTileGO in RoomManager.Instance.GetAllDarknessTiles()) {
            darknessTileGO.Brighten(0, 0, true);
            darknessTileGO.Darken(flashFadeTime, flashStayTime);
        }
    }
    
    public void Flash() {
        Flash(flashFadeTime, flashStayTime);
    }


    public void Recharge() {
        Charges += rechargeAmount;
    }
}