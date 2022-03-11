using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        if(timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
        InvokeRepeating("Stopper", 0, 1);
    }

    void Update()
    {
        PauseCheck();
    }

    private void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time:{timeToEnd} s");
        if(timeToEnd <=0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if(endGame)
        {
            EndGame();
        }
    }
    public void PauseGame()
    {
        Debug.Log("Game paused!");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Game resumed!");
        Time.timeScale = 1f;
        gamePaused = true;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You win!!! Reload?");
        }
        {
            Debug.Log("You lose!!! Reload?");
        }
    }
    public void AddPoints(int points)
    {
        this.points  += points;

    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }
    public void FrezeeTime( int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1);
    }
}
