using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool isTimeUp = false;
    private bool? isLevelWon = null;
    private bool isLevelCompleted = false;

    public float levelTime = 60.0f;
    private float currentTime = 0.0f;
    private float countingOffset = 3.0f;

    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        isTimeUp = false;
        isLevelWon = null;
        isLevelCompleted = false;

        currentTime = 0.0f;

        // level1
        levelTime = 30.0f;

        //level2
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            InitializeLevel2();
        }

        levelTime += countingOffset;
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
        currentTime = Time.timeSinceLevelLoad;
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

    private void InitializeLevel2()
    {
        levelTime = 60.0f;
    }

    public float GetCountingOffset()
    {
        return countingOffset;
    }

}
