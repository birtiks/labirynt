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
    [SerializeField] private int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    AudioSource audioSource;
    public AudioClip resumeGameCLip;
    public AudioClip pauseGameCLip;
    public AudioClip winGameCLip;
    public AudioClip loseGameCLip;
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
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 0, 1);
    }

    void Update()
    {
        PauseCheck();
        PickUpCheck();
    }

    public void PLayCLip(AudioClip audioCLip)
    {
        audioSource.clip = audioCLip;
;
        audioSource.Play();
    }
    private void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log($"Actual time: {timeToEnd}");
            Debug.Log($"Red key: {redKey} green key: {greenKey}, gold key:{goldKey}");
            Debug.Log($"Points: {points}");
        }
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
      //  Debug.Log($"Time:{timeToEnd} s");
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
        PLayCLip(pauseGameCLip);
        Debug.Log("Game paused!");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        PLayCLip(resumeGameCLip);
        Debug.Log("Game resumed!");
        Time.timeScale = 1f;
        gamePaused = true;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            PLayCLip(winGameCLip);
            Debug.Log("You win!!! Reload?");
        }
        else
        {
            PLayCLip(loseGameCLip);
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
    public void Addkey(KeyColor keycolor)
    {
        switch(keycolor)
        {
            case KeyColor.Red:
                redKey++;
                break;
            case KeyColor.Green:
                greenKey++;
                break;
            case KeyColor.Gold:
                goldKey++;
                break;
        }

    }
}
