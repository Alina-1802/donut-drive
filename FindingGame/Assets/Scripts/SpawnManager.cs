using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject locationPrefab;

    private static int locationsNumber = 6;
    private int currentLocationsNumber; // how many left to spawn
    private int foundLocationsNumber = 0;

    private PlayerController playerController;

    Vector3[] spawnLocationsPositions = new Vector3[locationsNumber];

    private bool isLevelCompleted = false;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        currentLocationsNumber = locationsNumber;

        // level 1
        spawnLocationsPositions[0] = new Vector3(12.6472425f, 7.62939453e-06f, -49.7871704f);
        spawnLocationsPositions[1] = new Vector3(-137.699997f, 7.62939453e-06f, 38.7999992f);
        spawnLocationsPositions[2] = new Vector3(82.9000015f, 7.62939453e-06f, 31.2999992f);
        spawnLocationsPositions[3] = new Vector3(128.199997f, 7.62939453e-06f, -87.5999985f);
        spawnLocationsPositions[4] = new Vector3(-87.8000031f, 7.62939453e-06f, -82.4000015f);
        spawnLocationsPositions[5] = new Vector3(62.2000008f, 7.62939453e-06f, -20.3999996f);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // level 2
            InitializeLevel2();
        }

        Instantiate(locationPrefab, spawnLocationsPositions[0], locationPrefab.transform.rotation);
        currentLocationsNumber--;
    }

    void Update()
    {
        SpawnLocations();
    }

    void SpawnLocations()
    {
        if (playerController.GetIsLocationFound())
        {
            foundLocationsNumber++;
            Debug.Log(foundLocationsNumber);

            if (currentLocationsNumber > 0)
            {
                int i = locationsNumber - currentLocationsNumber;
                Instantiate(locationPrefab, spawnLocationsPositions[i], locationPrefab.transform.rotation);
                currentLocationsNumber--;
            }
            else if (currentLocationsNumber == 0)
            {
                isLevelCompleted = true;
            }

            playerController.SetIsLocationFound(false);
        }
    }

    public bool GetIsLevelCompleted()
    {
        return isLevelCompleted;
    }

    public int GetLeftLocationsNumber()
    {
        return locationsNumber - foundLocationsNumber;
    }

    private void InitializeLevel2()
    {
        locationsNumber = 8;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(63.4940834f, 0.015f, 30.7000008f);
        spawnLocationsPositions[1] = new Vector3(133.5f, 0.015f, 111.900002f);
        spawnLocationsPositions[2] = new Vector3(194.300003f, 0.02f, -28.1000004f);
        spawnLocationsPositions[3] = new Vector3(134.199997f, 0.015f, -120.300003f);
        spawnLocationsPositions[4] = new Vector3(-52.7000008f, 0.02f, -128.699997f);
        spawnLocationsPositions[5] = new Vector3(-134.899994f, 0.015f, 18.1000004f);
        spawnLocationsPositions[6] = new Vector3(63.4000015f, 0.015f, 11.5f);
        spawnLocationsPositions[7] = new Vector3(63.4000015f, 0.015f, -125.099998f);
    }
}
