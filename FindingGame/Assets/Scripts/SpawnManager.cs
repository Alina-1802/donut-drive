using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject locationPrefab;

    private const int locationsNumber = 6;
    private int currentLocationsNumber; // how many left to spawn
    private int foundLocationsNumber;

    private PlayerController playerController;

    Vector3[] spawnLocationsPositions = new Vector3[locationsNumber];

    private bool isLevelCompleted = false;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        currentLocationsNumber = locationsNumber;

        // for now specific positions, to randomize in the future
        spawnLocationsPositions[0] = new Vector3(12.6472425f, 7.62939453e-06f, -49.7871704f);
        spawnLocationsPositions[1] = new Vector3(-137.699997f, 7.62939453e-06f, 38.7999992f);
        spawnLocationsPositions[2] = new Vector3(82.9000015f, 7.62939453e-06f, 31.2999992f);
        spawnLocationsPositions[3] = new Vector3(128.199997f, 7.62939453e-06f, -87.5999985f);
        spawnLocationsPositions[4] = new Vector3(-87.8000031f, 7.62939453e-06f, -82.4000015f);
        spawnLocationsPositions[5] = new Vector3(62.2000008f, 7.62939453e-06f, -20.3999996f);

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
}
