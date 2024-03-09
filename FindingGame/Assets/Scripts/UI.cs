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
    public TextMeshProUGUI locationsNumber;
    public TextMeshProUGUI counting;
    public GameObject retryButton;
    public GameObject nextLevelButton;
    public GameObject quitButton;
    public GameObject pauseMenu;

    private LevelManager levelManager;
    private SpawnManager spawnManager;

    private bool isGamePaused = false;
    private bool firstPressing = true;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        levelWon.SetActive(false);
        levelLost.SetActive(false);
        pauseMenu.SetActive(false);

        nextLevelButton.SetActive(false);
        retryButton.SetActive(false);
        quitButton.SetActive(false);

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

                if (levelManager.GetIsGameWon() != null)
                {
                    ShowGameOver();

                    if (levelManager.GetIsGameWon() == true)
                    {
                        nextLevelButton.SetActive(true);
                    }

                    retryButton.SetActive(true);
                    quitButton.SetActive(true);
                }
            }
        }



        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (firstPressing)
            {
                isGamePaused = true;
                firstPressing = false;
                pauseMenu.SetActive(true);

            }
            else
            {
                isGamePaused = false;
                firstPressing = true;
                pauseMenu.SetActive(false);
            }
        }
    }

    private void ShowTimer()
    {
        float currentTime = levelManager.GetCurrentTime();
        if(currentTime <= 0f)
        {
            currentTime = 0f;
        }

        float levelTime = levelManager.GetLevelTime();
        float leftTime = levelTime - currentTime;
        timer.text = leftTime.ToString("F2") + " s";
    }

    private void ShowGameOver()
    {
        if(levelManager.GetIsGameWon() == true)
        {
            levelWon.SetActive(true);
        }
        else if(levelManager.GetIsGameWon() == false)
        {
            levelLost.SetActive(true);
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
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public bool GetIsGamePaused()
    {
        return isGamePaused;
    }
}
