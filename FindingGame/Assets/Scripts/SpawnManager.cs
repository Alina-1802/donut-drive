using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject locationPrefab;

    private static int locationsNumber = 8;
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
        spawnLocationsPositions[0] = new Vector3(7f, 7.62939453e-06f, -114.5f);
        spawnLocationsPositions[1] = new Vector3(-1.79999995f, 7.62939453e-06f, -68.0999985f);
        spawnLocationsPositions[2] = new Vector3(40.9000015f, 7.62939453e-06f, -68.0999985f);
        spawnLocationsPositions[3] = new Vector3(95.6999969f, 7.62939453e-06f, -55.4000015f);
        spawnLocationsPositions[4] = new Vector3(99.1999969f, 7.62939453e-06f, -103.699997f);
        spawnLocationsPositions[5] = new Vector3(33.4000015f, 7.62939453e-06f, -103.199997f);
        spawnLocationsPositions[6] = new Vector3(1.79999995f, 7.62939453e-06f, -123.800003f);
        spawnLocationsPositions[7] = new Vector3(26.8999996f, 7.62939453e-06f, -152.100006f);

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
