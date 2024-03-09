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
    private UI ui;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        ui = GameObject.Find("UI").GetComponent<UI>();

        isTimeUp = false;
        isLevelWon = null;
        isLevelCompleted = false;

        currentTime = 0.0f;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            // level1.1
            InitializeLevel1_1();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //level1.2
            InitializeLevel1_2();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //level1.3
            InitializeLevel1_3();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            //level1.4
            InitializeLevel1_4();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            //level1.5
            InitializeLevel1_5();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            //level2.1
            InitializeLevel2_1();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            //level3.1
            InitializeLevel3_1();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            //level3.2
            InitializeLevel3_2();
        }

        levelTime += countingOffset;
    }

    void Update()
    {
        if(isLevelWon == null && !ui.GetIsGamePaused())
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
        currentTime += Time.deltaTime;
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

    public bool? GetIsLevelWon()
    {
        return isLevelWon;
    }

    public void SetIsLevelWon(bool state)
    {
        isLevelWon = state;
    }

    private void InitializeLevel1_1()
    {
        levelTime = 30.0f;
    }

    private void InitializeLevel1_2()
    {
        levelTime = 30.0f;
    }

    private void InitializeLevel1_3()
    {
        levelTime = 25.0f;
    }

    private void InitializeLevel1_4()
    {
        levelTime = 30.0f;
    }

    private void InitializeLevel1_5()
    {
        levelTime = 25.0f;
    }

    private void InitializeLevel2_1()
    {
        levelTime = 40.0f;
    }
    private void InitializeLevel3_1()
    {
        levelTime = 50.0f;
    }
    private void InitializeLevel3_2()
    {
        levelTime = 30.0f;
    }

    public float GetCountingOffset()
    {
        return countingOffset;
    }

}
