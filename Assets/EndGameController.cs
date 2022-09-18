using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour {
    [SerializeField] private GameObject winImage;
    [SerializeField] private GameObject gameOverImage;

    // public static EndGameController Instance { get; private set; }
    //
    // private void Awake() {
    //     if (Instance != null) {
    //         DestroyImmediate(gameObject);
    //         return;
    //     }
    //     Instance = this;
    // }

    private void Start() {
        if (GameController.Instance.HasWon)
            DisplayWin();
        else
            DisplayLoss();
    }

    private void DisplayLoss() {
        gameOverImage.SetActive(true);
        winImage.SetActive(false);
        AudioManager.Instance.Play("Loosesound");
    }

    private void DisplayWin() {
        winImage.SetActive(true);
        gameOverImage.SetActive(false);
        AudioManager.Instance.Play("Winsound");
    }

    public void RestartGame() {
        AudioManager.Instance.Stop("Winsound");
        AudioManager.Instance.Stop("Loosesound");
        SceneManager.LoadScene(GameController.Instance.MainSceneNumber, LoadSceneMode.Single);
        GameController.Instance.ReStartGame();
    }
    
}