using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject locationPrefab;

    private static int locationsNumber = 5;
    private int currentLocationsNumber; // how many left to spawn

    private PlayerController playerController;

    Vector3[] spawnLocationsPositions = new Vector3[locationsNumber];

    private bool isGameWon = false;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        currentLocationsNumber = locationsNumber;

        // for now specific positions, to randomize in the future
        spawnLocationsPositions[0] = new Vector3(0, 0, 0);
        spawnLocationsPositions[1] = new Vector3(10, 0, 0);
        spawnLocationsPositions[2] = new Vector3(5, 0, -15);
        spawnLocationsPositions[3] = new Vector3(0, 0, 7);
        spawnLocationsPositions[4] = new Vector3(-4, 0, 0);

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
            if (currentLocationsNumber > 0)
            {
                int i = locationsNumber - currentLocationsNumber;
                Instantiate(locationPrefab, spawnLocationsPositions[i], locationPrefab.transform.rotation);
                currentLocationsNumber--;
            }
            else if (currentLocationsNumber == 0)
            {
                isGameWon = true;
                Debug.Log("You won!");
            }

            playerController.SetIsLocationFound(false);
        }
    }

    public bool GetIsGameWon()
    {
        return isGameWon;
    }
}
