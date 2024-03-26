using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI timer;

    public GameObject levelWon;
    public GameObject levelLost;
    public GameObject pauseText;
    public GameObject menu;

    public TextMeshProUGUI locationsNumber;
    public TextMeshProUGUI counting;

    private LevelManager levelManager;
    private SpawnManager spawnManager;

    private Menu menuScript;

    private bool isGamePaused = false;
    private bool firstPressing = true;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        menuScript = menu.GetComponent<Menu>();

        levelWon.SetActive(false);
        levelLost.SetActive(false);
        pauseText.SetActive(true);

        counting.gameObject.SetActive(true);
        counting.text = string.Empty;
    }

    void Update()
    {

        if (isGamePaused == false)
        {
            if (levelManager.GetCurrentTime() <= 3)
            {
                ShowCounting();
            }
            else
            {
                counting.gameObject.SetActive(false);
                ShowTimer();
                ShowLocationsNumber();

                if (levelManager.GetIsLevelWon() != null)
                {
                    ShowGameOver();
                    menu.SetActive(true);
                    menuScript.mainPanel.SetActive(true);
                    isGamePaused = true;

                    if (levelManager.GetIsLevelWon() == true)
                    {
                        menuScript.ActivateNextLevelButton();

                        if(menuScript.GetCurrentLevelIndex() == SceneManager.GetActiveScene().buildIndex)
                        {
                            menuScript.IncreaseCurrentLevelIndex();
                        }
                    }
                    else if(levelManager.GetIsLevelWon() == false && (menuScript.GetCurrentLevelIndex() > SceneManager.GetActiveScene().buildIndex))
                    {
                        menuScript.ActivateNextLevelButton();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && levelManager.GetIsLevelWon() == null && !menuScript.levelsPanel.activeSelf)
        {
            if (firstPressing)
            {
                isGamePaused = true;
                firstPressing = false;
                menuScript.mainPanel.SetActive(true);
                menu.SetActive(true);
                counting.gameObject.SetActive(false);

                if(menuScript.CheckNextLevelButtonActivation() == true)
                {
                    menuScript.ActivateNextLevelButton();
                }
            }
            else
            {
                isGamePaused = false;
                firstPressing = true;
                menuScript.mainPanel.SetActive(false);
                menu.SetActive(false);
                counting.gameObject.SetActive(true);
            }
        }
    }

    private void ShowTimer()
    {
        float leftTime = levelManager.GetLeftTime();

        if (leftTime <= 0f)
        {
            leftTime = 0f;
        }
        timer.text = leftTime.ToString("F2") + " s";
    }

    private void ShowGameOver()
    {
        if(levelManager.GetIsLevelWon() == true)
        {
            levelWon.SetActive(true);
            pauseText.SetActive(false);
        }
        else if(levelManager.GetIsLevelWon() == false)
        {
            levelLost.SetActive(true);
            pauseText.SetActive(false);
        }
    }

    private void ShowLocationsNumber()
    {
        int leftLocationsNumber = spawnManager.GetLeftLocationsNumber();
        locationsNumber.text = leftLocationsNumber.ToString();
    }

    private void ShowCounting()
    {
        string[] time = { "3", "2", "1" };

        if(levelManager.GetCurrentTime() <= 1)
        {
            counting.text = time[0];
        }
        else if(levelManager.GetCurrentTime() > 1 && levelManager.GetCurrentTime() <= 2)
        {
            counting.text = time[1];
        }
        else if(levelManager.GetCurrentTime() >= 2 && levelManager.GetCurrentTime() <= 3)
        {
            counting.text = time[2];
        }
        else
        {
            counting.text = String.Empty;
        }
    }

    public bool GetIsGamePaused()
    {
        return isGamePaused;
    }
}
