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

        InitializeCurrentLevel();

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
        levelTime = 50.0f;
    }
    private void InitializeLevel2_2()
    {
        levelTime = 30.0f;
    }
    private void InitializeLevel2_3()
    {
        levelTime = 30.0f;
    }
    private void InitializeLevel3_1()
    {
        levelTime = 40.0f;
    }

    private void InitializeCurrentLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        switch (currentLevelIndex)
        {
            case 0:
                {
                    InitializeLevel1_1();
                    break;
                }
            case 1:
                {
                    InitializeLevel1_2();
                    break;
                }
            case 2:
                {
                    InitializeLevel1_3();
                    break;
                }
            case 3:
                {
                    InitializeLevel1_4();
                    break;
                }
            case 4:
                {
                    InitializeLevel1_5();
                    break;
                }
            case 5:
                {
                    InitializeLevel2_1();
                    break;
                }
            case 6:
                {
                    InitializeLevel2_2();
                    break;
                }
            case 7:
                {
                    InitializeLevel2_3();
                    break;
                }
            case 8:
                {
                    InitializeLevel3_1();
                    break;
                }
        }
    }

    public float GetCountingOffset()
    {
        return countingOffset;
    }


}
