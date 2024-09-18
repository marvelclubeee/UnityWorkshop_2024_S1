using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// GlobalSingleton is a custom class that makes sure a single instance of this class exists globally
public class GameManager : GlobalSingleton<GameManager> {
    public static readonly int WINING_SCORE = 10;
    private int _score = 0;

    public void RestartGame(){
        _score = 0;
        SceneManager.LoadScene("Level1");
    }

    public void AddScore(int score)
    {
        _score += score;
        Debug.Log("Score: " + _score);
        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        if (_score >= WINING_SCORE)
        {
            PublishWin();
        }
    }

    public void PublishWin()
    {
        Debug.Log("You Win!");
    }

    public void PublishLose(){
        Debug.Log("You Lose!");
    }
}