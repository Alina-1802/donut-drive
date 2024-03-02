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

        spawnLocationsPositions[0] = new Vector3(-0.0299999993f, 0.02f, 77.7699966f);
        spawnLocationsPositions[1] = new Vector3(85.1999969f, 0.02f, 148.399994f);
        spawnLocationsPositions[2] = new Vector3(114.800003f, 0.02f, 12.3999996f);
        spawnLocationsPositions[3] = new Vector3(69.0999985f, 0.02f, -78.3000031f);
        spawnLocationsPositions[4] = new Vector3(-125.699997f, 0.02f, -89.8000031f);
        spawnLocationsPositions[5] = new Vector3(-203.300003f, 0.02f, 66.3000031f);
        spawnLocationsPositions[6] = new Vector3(-3.29999995f, 0.02f, 52.0999985f);
        spawnLocationsPositions[7] = new Vector3(-3.20000005f, 0.02f, -75.3000031f);
    }
}
