using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private bool isTimeUp = false;
    private bool? isLevelWon = null;
    private bool isLevelCompleted;

    public float levelTime = 60.0f;
    private float currentTime = 0.0f;

    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        if(isLevelWon == null)
        {
            UpdateTime();
            SetLevelState(); 
        }
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public float GetLevelTime()
    {
        return levelTime;
    }

    private void UpdateTime()
    {
        currentTime = Time.time;
        isTimeUp = (currentTime >= levelTime);
    }

    private void SetLevelState()
    {
        isLevelCompleted = spawnManager.GetIsLevelCompleted();

        if (isTimeUp && !isLevelCompleted)
        {
            isLevelWon = false;
            Debug.Log("You lost!");
        }
        else if (!isTimeUp && isLevelCompleted)
        {
            isLevelWon = true;
            Debug.Log("You won!");
        }
    }

    public bool? GetIsGameWon()
    {
        return isLevelWon;
    }
}
