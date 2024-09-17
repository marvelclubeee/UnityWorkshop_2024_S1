using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCanvas : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        // listen to the game winning or losing events from GameManager
        GameManager.Instance.Win += OnGameWin;
        GameManager.Instance.Lose += OnGameLost;
    }

    private void OnDestroy() { // remember to unsubscribe the event when the object is destroyed
        GameManager.Instance.Win -= OnGameWin;
        GameManager.Instance.Lose -= OnGameLost;
    }

    private void OnGameWin()
    {
        winScreen.SetActive(true);
    }

    private void OnGameLost()
    {
        loseScreen.SetActive(true);
    }

    public void OnRestartButtonClicked() // function that button will call when clicked
    {
        GameManager.Instance.RestartGame();
    }

}
