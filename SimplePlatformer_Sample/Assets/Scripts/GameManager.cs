using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// GlobalSingleton is a custom class that makes sure a single instance of this class exists globally
public class GameManager : GlobalSingleton<GameManager> {
    public static readonly int WINING_SCORE = 10;
    private int _score = 0;

    public event Action Lose; // Event that is triggered when the game is lost
    public event Action Win; // Event that is triggered when the game is won

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
        Win?.Invoke(); // raise the "Win" event
    }

    public void PublishLose(){
        Debug.Log("You Lose!");
        Lose?.Invoke(); // raise the "Lose" event
    }
}
