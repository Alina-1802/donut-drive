using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private bool isTimeUp = false;
    private bool? isLevelWon = null;
    private bool isLevelCompleted;

    private const float levelTime = 5.0f;
    private float currentTime = 0.0f;

    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        isLevelCompleted = spawnManager.GetIsLevelCompleted();

        currentTime = Time.time;
        isTimeUp = (currentTime >= levelTime);

        if (isTimeUp && !isLevelCompleted)
        {
            isLevelWon = false;
            Debug.Log("You lost!");
        }
        else if(!isTimeUp && isLevelCompleted)
        {
            isLevelWon = true; 
            Debug.Log("You won!");
        }
    }
}
