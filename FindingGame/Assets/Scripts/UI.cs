using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameObject gameWon;
    public GameObject gameLost;
    public TextMeshProUGUI locationsNumber;

    private LevelManager levelManager;
    private SpawnManager spawnManager;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        gameWon.SetActive(false);
        gameLost.SetActive(false);
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
        timer.text = currentTime.ToString("F2") + " s";
    }

    private void ShowGameOver()
    {
        if(levelManager.GetIsGameWon() == true)
        {
            gameWon.SetActive(true);
        }
        else if(levelManager.GetIsGameWon() == false)
        {
            gameLost.SetActive(true);
        }
    }

    private void ShowLocationsNumber()
    {
        int leftLocationsNumber = spawnManager.GetLeftLocationsNumber();
        locationsNumber.text = leftLocationsNumber.ToString();
    }
}
