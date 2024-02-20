using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameObject levelWon;
    public GameObject levelLost;
    public TextMeshProUGUI locationsNumber;

    private LevelManager levelManager;
    private SpawnManager spawnManager;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        levelWon.SetActive(false);
        levelLost.SetActive(false);
    }

    void Update()
    {
        ShowTimer();
        ShowLocationsNumber();

        if (levelManager.GetIsGameWon() != null)
        {
            ShowGameOver();
        }
    }

    private void ShowTimer()
    {
        float currentTime = levelManager.GetCurrentTime();
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
}
