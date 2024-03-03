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
    public GameObject retryButton;
    public GameObject nextLevelButton;
    public GameObject quitButton;

    private LevelManager levelManager;
    private SpawnManager spawnManager;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        levelWon.SetActive(false);
        levelLost.SetActive(false);

        nextLevelButton.SetActive(false);
        retryButton.SetActive(false);
        quitButton.SetActive(false);
    }

    void Update()
    {
        ShowTimer();
        ShowLocationsNumber();

        if (levelManager.GetIsGameWon() != null)
        {
            ShowGameOver();

            if(levelManager.GetIsGameWon() == true)
            {
                nextLevelButton.SetActive(true);
            }

            retryButton.SetActive(true);
            quitButton.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
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
}
