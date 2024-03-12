using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject locationPrefab;

    private static int locationsNumber = 12;
    private int currentLocationsNumber; // how many left to spawn
    private int foundLocationsNumber = 0;

    private PlayerController playerController;

    Vector3[] spawnLocationsPositions = new Vector3[locationsNumber];

    private bool isLevelCompleted = false;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        InitializeCurrentLevel();

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

    private void InitializeLevel1_1()
    {
        locationsNumber = 12;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(14.1999998f, 3.81469727e-06f, -114.699997f);
        spawnLocationsPositions[1] = new Vector3(-12.3999996f, 3.81469727e-06f, -79.3000031f);
        spawnLocationsPositions[2] = new Vector3(9.69999981f, 3.81469727e-06f, -53.4000015f);
        spawnLocationsPositions[3] = new Vector3(10.3000002f, 3.81469727e-06f, -1.5f);
        spawnLocationsPositions[4] = new Vector3(59.4000015f, 3.81469727e-06f, 16.5f);
        spawnLocationsPositions[5] = new Vector3(98.1999969f, 3.81469727e-06f, 43.0999985f);
        spawnLocationsPositions[6] = new Vector3(127f, 3.81469727e-06f, 6f);
        spawnLocationsPositions[7] = new Vector3(145.600006f, 3.81469727e-06f, -29.3999996f);
        spawnLocationsPositions[8] = new Vector3(145.600006f, 3.81469727e-06f, -89.5f);
        spawnLocationsPositions[9] = new Vector3(88f, 3.81469727e-06f, -100.699997f);
        spawnLocationsPositions[10] = new Vector3(23.8999996f, 3.81469727e-06f, -106.599998f);
        spawnLocationsPositions[11] = new Vector3(0f, 3.81469727e-06f, -135.699997f);
    }

    private void InitializeLevel1_2()
    {
        locationsNumber = 13;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(72.1999969f, 0.00999999978f, -103.099998f);
        spawnLocationsPositions[1] = new Vector3(21.5f, 0.00999999978f, -113.199997f);
        spawnLocationsPositions[2] = new Vector3(-27.8999996f, 0.00999999978f, -115.5f);
        spawnLocationsPositions[3] = new Vector3(-82.3000031f, 0.00999999978f, -113f);
        spawnLocationsPositions[4] = new Vector3(-116.099998f, 0.00999999978f, -82.0999985f);
        spawnLocationsPositions[5] = new Vector3(-89.5f, 0.00999999978f, -57.0999985f);
        spawnLocationsPositions[6] = new Vector3(-58.5999985f, 0.00999999978f, -26.3999996f);
        spawnLocationsPositions[7] = new Vector3(-6.4000001f, 0.00999999978f, -13.6000004f);
        spawnLocationsPositions[8] = new Vector3(53f, 0.00999999978f, 6.80000019f);
        spawnLocationsPositions[9] = new Vector3(60.5f, 0.00999999978f, -29.7000008f);
        spawnLocationsPositions[10] = new Vector3(58.9000015f, 0.00999999978f, -75.5999985f);
        spawnLocationsPositions[11] = new Vector3(-2f, 0.00999999978f, -75.5999985f);
        spawnLocationsPositions[12] = new Vector3(15.3000002f, 0.00999999978f, -113.300003f);
    }

    private void InitializeLevel1_3()
    {
        locationsNumber = 14;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(-18.7199993f, -3.81469727e-06f, 110.833702f);
        spawnLocationsPositions[1] = new Vector3(-12f, -3.81469727e-06f, 53.9000015f);
        spawnLocationsPositions[2] = new Vector3(-2.20000005f, -3.81469727e-06f, 24.7999992f);
        spawnLocationsPositions[3] = new Vector3(-25.5f, -3.81469727e-06f, -0.5f);
        spawnLocationsPositions[4] = new Vector3(-34.2999992f, -3.81469727e-06f, -22.5f);
        spawnLocationsPositions[5] = new Vector3(-71.9000015f, -3.81469727e-06f, -37.9000015f);
        spawnLocationsPositions[6] = new Vector3(-64.5f, -3.81469727e-06f, -81.1999969f);
        spawnLocationsPositions[7] = new Vector3(-8.10000038f, -3.81469727e-06f, -76.9000015f);
        spawnLocationsPositions[8] = new Vector3(19f, -3.81469727e-06f, -100f);
        spawnLocationsPositions[9] = new Vector3(37.2999992f, -3.81469727e-06f, -146.100006f);
        spawnLocationsPositions[10] = new Vector3(83.5f, -3.81469727e-06f, -178.899994f);
        spawnLocationsPositions[11] = new Vector3(139.800003f, -3.81469727e-06f, -155.600006f);
        spawnLocationsPositions[12] = new Vector3(118.5f, -3.81469727e-06f, -102.5f);
        spawnLocationsPositions[13] = new Vector3(89.5f, -3.81469727e-06f, -76.0999985f);
    }

    private void InitializeLevel1_4()
    {
        locationsNumber = 5;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(12.6999998f, 0.00999999978f, -15.8000002f);
        spawnLocationsPositions[1] = new Vector3(89.8000031f, 0.00999999978f, -63.5f);
        spawnLocationsPositions[2] = new Vector3(-3.5f, 0.00999999978f, -136.800003f);
        spawnLocationsPositions[3] = new Vector3(-31.7999992f, 0.00999999978f, 39.7999992f);
        spawnLocationsPositions[4] = new Vector3(63.7000008f, 0.00999999978f, 88.1999969f);
    }

    private void InitializeLevel1_5()
    {
        locationsNumber = 10;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(-11.8999996f, 0.0199999996f, -80.4000015f);
        spawnLocationsPositions[1] = new Vector3(30.7000008f, 0.0199999996f, -71.6999969f);
        spawnLocationsPositions[2] = new Vector3(62.2000008f, 0.0199999996f, -49.5f);
        spawnLocationsPositions[3] = new Vector3(105.400002f, 0.0199999996f, -50.2999992f);
        spawnLocationsPositions[4] = new Vector3(140.5f, 0.0199999996f, -70.6999969f);
        spawnLocationsPositions[5] = new Vector3(125.5f, 0.0199999996f, -94.0999985f);
        spawnLocationsPositions[6] = new Vector3(71.5f, 0.0199999996f, -101.199997f);
        spawnLocationsPositions[7] = new Vector3(44.5999985f, 0.0199999996f, -145.399994f);
        spawnLocationsPositions[8] = new Vector3(-1f, 0.0199999996f, -152.800003f);
        spawnLocationsPositions[9] = new Vector3(-3.29999995f, 0.0199999996f, -86.3000031f);
        spawnLocationsPositions[9] = new Vector3(12.8999996f, 0.0199999996f, -49.7999992f);
    }

    private void InitializeLevel2_1()
    {
        locationsNumber = 7;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(0.0900000036f, 1.15999997f, -9.82199669f);
        spawnLocationsPositions[1] = new Vector3(39.7000008f, 1.15999997f, 25.5400009f);
        spawnLocationsPositions[2] = new Vector3(50.7999992f, 1.15999997f, 40.5999985f);
        spawnLocationsPositions[3] = new Vector3(47.0999985f, 1.15999997f, 56.9000015f);
        spawnLocationsPositions[4] = new Vector3(8.30000019f, 1.15999997f, 73.8000031f);
        spawnLocationsPositions[5] = new Vector3(-19.3999996f, 1.15999997f, 88.5f);
        spawnLocationsPositions[6] = new Vector3(-2.79999995f, 1.15999997f, 110.900002f);
    }

    private void InitializeLevel2_2()
    {
        locationsNumber = 5;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(-0.100000001f, 1.01999998f, -10.6000004f);
        spawnLocationsPositions[1] = new Vector3(-35.4000015f, 1.01999998f, 24f);
        spawnLocationsPositions[2] = new Vector3(62.7999992f, 1.01999998f, 45.5999985f);
        spawnLocationsPositions[3] = new Vector3(53.7999992f, 1.01999998f, -9.19999981f);
        spawnLocationsPositions[4] = new Vector3(82.8000031f, 1.01999998f, -8.19999981f);
    }

    private void InitializeLevel2_3()
    {
        locationsNumber = 5;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(0f, 1.19000006f, -7f);
        spawnLocationsPositions[1] = new Vector3(44.7999992f, 1.19000006f, 41.4000015f);
        spawnLocationsPositions[2] = new Vector3(44.7999992f, 1.19000006f, 79.0999985f);
        spawnLocationsPositions[3] = new Vector3(-25.7999992f, 1.19000006f, 78.5999985f);
        spawnLocationsPositions[4] = new Vector3(-80f, 1.19000006f, 78.5999985f);
    }

    private void InitializeLevel3_1()
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

    private void InitializeCurrentLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        switch (currentLevelIndex)
        {
            case 0:
                {
                    InitializeLevel1_1();
                    break;
                }
            case 1: 
                {
                    InitializeLevel1_2();
                    break;
                }
            case 2:
                {
                    InitializeLevel1_3();
                    break;
                }
            case 3:
                {
                    InitializeLevel1_4();
                    break;
                }
            case 4:
                {
                    InitializeLevel1_5();
                    break;
                }
            case 5:
                {
                    InitializeLevel2_1();
                    break;
                }
            case 6:
                {
                    InitializeLevel2_2();
                    break;
                }
            case 7:
                {
                    InitializeLevel2_3();
                    break;
                }
            case 8:
                {
                    InitializeLevel3_1();
                    break;
                }
        }
    }
}
