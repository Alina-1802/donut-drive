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
        locationsNumber = 17;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(10.8999996f, 1.21f, -137.699997f);
        spawnLocationsPositions[1] = new Vector3(2.5f, 1.21f, -111.5f);
        spawnLocationsPositions[2] = new Vector3(-1.60000002f, 1.21f, -84.3000031f);
        spawnLocationsPositions[3] = new Vector3(4.4000001f, 1.21f, -55f);
        spawnLocationsPositions[4] = new Vector3(13.3000002f, 1.21f, -15.8999996f);
        spawnLocationsPositions[5] = new Vector3(42.9000015f, 1.21f, 3.20000005f);
        spawnLocationsPositions[6] = new Vector3(78f, 1.21f, 22.7999992f);
        spawnLocationsPositions[7] = new Vector3(119.699997f, 1.21f, 23.3999996f);
        spawnLocationsPositions[8] = new Vector3(139.600006f, 1.21f, 3.29999995f);
        spawnLocationsPositions[9] = new Vector3(148.699997f, 1.21f, -33.5999985f);
        spawnLocationsPositions[10] = new Vector3(150.800003f, 1.21f, -69.4000015f);
        spawnLocationsPositions[11] = new Vector3(138.5f, 1.21f, -95.9000015f);
        spawnLocationsPositions[12] = new Vector3(103f, 1.21f, -102.900002f);
        spawnLocationsPositions[13] = new Vector3(57.4000015f, 1.21f, -103.900002f);
        spawnLocationsPositions[14] = new Vector3(26.3999996f, 1.21f, -112.300003f);
        spawnLocationsPositions[15] = new Vector3(-3.29999995f, 1.21f, -127.800003f);
        spawnLocationsPositions[16] = new Vector3(6.5999999f, 1.21f, -151f);
    }

    private void InitializeLevel1_2()
    {
        locationsNumber = 13;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(88.5999985f, 1.21000004f, -102.800003f);
        spawnLocationsPositions[1] = new Vector3(42f, 1.21000004f, -101.900002f);
        spawnLocationsPositions[2] = new Vector3(4f, 1.21000004f, -109.199997f);
        spawnLocationsPositions[3] = new Vector3(-30.1999969f, 1.21000004f, -123f);
        spawnLocationsPositions[4] = new Vector3(-66f, 1.21000004f, -119.300003f);
        spawnLocationsPositions[5] = new Vector3(-103.199997f, 1.21000004f, -99.9000015f);
        spawnLocationsPositions[6] = new Vector3(-88.3000031f, 1.21000004f, -59.4000015f);
        spawnLocationsPositions[7] = new Vector3(-35.8000031f, 1.21000004f, -26.9000015f);
        spawnLocationsPositions[8] = new Vector3(-4.19999695f, 1.21000004f, -15.1999969f);
        spawnLocationsPositions[9] = new Vector3(27.8999996f, 1.21000004f, 9.69999981f);
        spawnLocationsPositions[10] = new Vector3(57.5999985f, 1.21000004f, -0.200000003f);
        spawnLocationsPositions[11] = new Vector3(63.9000015f, 1.21000004f, -43.0999985f);
        spawnLocationsPositions[12] = new Vector3(53f, 1.21000004f, -76.8000031f);
    }

    private void InitializeLevel1_3()
    {
        locationsNumber = 15;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(-19.5f, 1.20999908f, 106.099998f);
        spawnLocationsPositions[1] = new Vector3(-12.5999985f, 1.20999908f, 52.5f);
        spawnLocationsPositions[2] = new Vector3(-19.0999985f, 1.20999908f, 8.5f);
        spawnLocationsPositions[3] = new Vector3(-37.0999985f, 1.20999908f, -23.7000008f);
        spawnLocationsPositions[4] = new Vector3(-72.9000015f, 1.20999908f, -38.5999985f);
        spawnLocationsPositions[5] = new Vector3(-86.3000031f, 1.20999908f, -67.1999969f);
        spawnLocationsPositions[6] = new Vector3(-49.0999985f, 1.20999908f, -79.6999969f);
        spawnLocationsPositions[7] = new Vector3(-7.5f, 1.20999908f, -85.8000031f);
        spawnLocationsPositions[8] = new Vector3(26.2999992f, 1.20999908f, -115.900002f);
        spawnLocationsPositions[9] = new Vector3(61.2000008f, 1.20999908f, -157.600006f);
        spawnLocationsPositions[10] = new Vector3(105.199997f, 1.20999908f, -172.899994f);
        spawnLocationsPositions[11] = new Vector3(133.5f, 1.20999908f, -143.5f);
        spawnLocationsPositions[12] = new Vector3(129.100006f, 1.20999908f, -105.699997f);
        spawnLocationsPositions[13] = new Vector3(117.400002f, 1.20999908f, -67.6999969f);
        spawnLocationsPositions[14] = new Vector3(79.8000031f, 1.20999908f, -45.4000015f);
    }

    private void InitializeLevel1_4()
    {
        locationsNumber = 5;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(12.6999998f, 1.20999908f, -15.8000002f);
        spawnLocationsPositions[1] = new Vector3(89.8000031f, 1.20999908f, -63.5f);
        spawnLocationsPositions[2] = new Vector3(-3.5f, 1.20999908f, -136.800003f);
        spawnLocationsPositions[3] = new Vector3(-31.7999992f, 1.20999908f, 39.7999992f);
        spawnLocationsPositions[4] = new Vector3(63.7000008f, 1.20999908f, 88.1999969f);
    }

    private void InitializeLevel1_5()
    {
        locationsNumber = 10;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(-11.8999996f, 1.20999908f, -80.4000015f);
        spawnLocationsPositions[1] = new Vector3(30.7000008f, 1.20999908f, -71.6999969f);
        spawnLocationsPositions[2] = new Vector3(62.2000008f, 1.20999908f, -49.5f);
        spawnLocationsPositions[3] = new Vector3(105.400002f, 1.20999908f, -50.2999992f);
        spawnLocationsPositions[4] = new Vector3(140.5f, 1.20999908f, -70.6999969f);
        spawnLocationsPositions[5] = new Vector3(125.5f, 1.20999908f, -94.0999985f);
        spawnLocationsPositions[6] = new Vector3(71.5f, 1.20999908f, -101.199997f);
        spawnLocationsPositions[7] = new Vector3(44.5999985f, 1.20999908f, -145.399994f);
        spawnLocationsPositions[8] = new Vector3(-1f, 1.20999908f, -152.800003f);
        spawnLocationsPositions[9] = new Vector3(-3.29999995f, 1.20999908f, -86.3000031f);
        spawnLocationsPositions[9] = new Vector3(12.8999996f, 1.20999908f, -49.7999992f);
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

    private void InitializeLevel2_4()
    {
        locationsNumber = 9;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(-0.180000007f, 1.11000001f, -9.76000023f);
        spawnLocationsPositions[1] = new Vector3(21.8999996f, 1.11000001f, -9f);
        spawnLocationsPositions[2] = new Vector3(54.2999992f, 1.11000001f, -30.2999992f);
        spawnLocationsPositions[3] = new Vector3(-1.79999995f, 1.11000001f, -51.5999985f);
        spawnLocationsPositions[4] = new Vector3(-51.5999985f, 1.11000001f, -92.5f);
        spawnLocationsPositions[5] = new Vector3(28.2999992f, 1.11000001f, -72.0999985f);
        spawnLocationsPositions[6] = new Vector3(51.2999992f, 1.11000001f, -111.800003f);
        spawnLocationsPositions[7] = new Vector3(9.10000038f, 1.11000001f, -111.099998f);
        spawnLocationsPositions[8] = new Vector3(8.60000038f, 1.11000001f, -161.399994f);
    }
    private void InitializeLevel2_5()
    {
        locationsNumber = 7;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(0f, 1.13f, -10.3999996f);
        spawnLocationsPositions[1] = new Vector3(33.0999985f, 1.13f, 24.6000004f);
        spawnLocationsPositions[2] = new Vector3(12.1999998f, 1.13f, 27.1000004f);
        spawnLocationsPositions[3] = new Vector3(6.69999981f, 1.13f, 60.9000015f);
        spawnLocationsPositions[4] = new Vector3(25.2999992f, 1.13f, 77f);
        spawnLocationsPositions[5] = new Vector3(53.4000015f, 1.13f, 83.6999969f);
        spawnLocationsPositions[6] = new Vector3(75.6999969f, 1.13f, 62.2999992f);
    }

    private void InitializeLevel3_1()
    {
        locationsNumber = 13;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];
        spawnLocationsPositions[0] = new Vector3(67f, 1.21000004f, -59.4000015f);
        spawnLocationsPositions[1] = new Vector3(63.5f, 1.21000004f, 11.3999996f);
        spawnLocationsPositions[2] = new Vector3(63.2999992f, 1.21000004f, 72.4000015f);
        spawnLocationsPositions[3] = new Vector3(89f, 1.21000004f, 110.400002f);
        spawnLocationsPositions[4] = new Vector3(170.100006f, 1.21000004f, 111.099998f);
        spawnLocationsPositions[5] = new Vector3(201.899994f, 1.21000004f, 70.5999985f);
        spawnLocationsPositions[6] = new Vector3(174.600006f, 1.21000004f, 12.5f);
        spawnLocationsPositions[7] = new Vector3(99.6999969f, 1.21000004f, 12.3000002f);
        spawnLocationsPositions[8] = new Vector3(6.9000001f, 1.21000004f, 12.1000004f);
        spawnLocationsPositions[9] = new Vector3(-55.0999985f, 1.21000004f, -24f);
        spawnLocationsPositions[10] = new Vector3(-54.9000015f, 1.21000004f, -101.599998f);
        spawnLocationsPositions[11] = new Vector3(7.5f, 1.21000004f, -127.5f);
        spawnLocationsPositions[12] = new Vector3(63.2000008f, 1.21000004f, -102.199997f);
    }

    private void InitializeLevel3_2()
    {
        locationsNumber = 9;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(-135.199997f, 1.21000004f, 41.5f);
        spawnLocationsPositions[1] = new Vector3(-91.3000031f, 1.21000004f, 12.3999996f);
        spawnLocationsPositions[2] = new Vector3(-57.5999985f, 1.21000004f, -40.5999985f);
        spawnLocationsPositions[3] = new Vector3(-21.5f, 1.21000004f, -127.300003f);
        spawnLocationsPositions[4] = new Vector3(63.4000015f, 1.21000004f, -101.300003f);
        spawnLocationsPositions[5] = new Vector3(64.0999985f, 1.21000004f, -22.3999996f);
        spawnLocationsPositions[6] = new Vector3(132.199997f, 1.21000004f, 11.6000004f);
        spawnLocationsPositions[7] = new Vector3(201.899994f, 1.21000004f, 56.2000008f);
        spawnLocationsPositions[8] = new Vector3(133.300003f, 1.21000004f, 111.199997f);
    }

    private void InitializeLevel3_3()
    {
        locationsNumber = 9;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(202.550003f, 1.21000004f, 70.5999985f);
        spawnLocationsPositions[1] = new Vector3(164.100006f, 1.21000004f, 12.6000004f);
        spawnLocationsPositions[2] = new Vector3(65.5999985f, 1.21000004f, 12.5f);
        spawnLocationsPositions[3] = new Vector3(-11.8999996f, 1.21000004f, 12.5f);
        spawnLocationsPositions[4] = new Vector3(-57f, 1.21000004f, -48.7999992f);
        spawnLocationsPositions[5] = new Vector3(-7.80000019f, 1.21000004f, -129f);
        spawnLocationsPositions[6] = new Vector3(133.399994f, 1.21000004f, -117.900002f);
        spawnLocationsPositions[7] = new Vector3(205.199997f, 1.21000004f, -95.1999969f);
        spawnLocationsPositions[8] = new Vector3(183.899994f, 1.21000004f, -28.8999996f);
    }

    private void InitializeLevel3_4()
    {
        locationsNumber = 14;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(63f, 1.21000004f, 32.2999992f);
        spawnLocationsPositions[1] = new Vector3(71.0999985f, 1.21000004f, -22.5f);
        spawnLocationsPositions[2] = new Vector3(86.1999969f, 1.21000004f, -36.0999985f);
        spawnLocationsPositions[3] = new Vector3(113.900002f, 1.21000004f, -38.2000008f);
        spawnLocationsPositions[4] = new Vector3(146.899994f, 1.21000004f, -36.4000015f);
        spawnLocationsPositions[5] = new Vector3(192.699997f, 1.21000004f, -42.0999985f);
        spawnLocationsPositions[6] = new Vector3(205.600006f, 1.21000004f, -76.1999969f);
        spawnLocationsPositions[7] = new Vector3(188.899994f, 1.21000004f, -132.600006f);
        spawnLocationsPositions[8] = new Vector3(157.199997f, 1.21000004f, -120.900002f);
        spawnLocationsPositions[9] = new Vector3(137.199997f, 1.21000004f, -97.6999969f);
        spawnLocationsPositions[10] = new Vector3(101.699997f, 1.21000004f, -101.5f);
        spawnLocationsPositions[11] = new Vector3(70.3000031f, 1.21000004f, -124.199997f);
        spawnLocationsPositions[12] = new Vector3(26.5f, 1.21000004f, -134.899994f);
        spawnLocationsPositions[13] = new Vector3(-43.7999992f, 1.21000004f, -118.800003f);

    }
    private void InitializeLevel3_5()
    {
        locationsNumber = 1;
        currentLocationsNumber = locationsNumber;

        spawnLocationsPositions = null;
        spawnLocationsPositions = new Vector3[locationsNumber];

        spawnLocationsPositions[0] = new Vector3(-82.9000015f, 1.21000004f, 35.0999985f);
    }

    private void InitializeCurrentLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        switch (currentLevelIndex)
        {
            case 1:
                {
                    InitializeLevel1_1();
                    break;
                }
            case 2: 
                {
                    InitializeLevel1_2();
                    break;
                }
            case 3:
                {
                    InitializeLevel1_3();
                    break;
                }
            case 4:
                {
                    InitializeLevel1_4();
                    break;
                }
            case 5:
                {
                    InitializeLevel1_5();
                    break;
                }
            case 6:
                {
                    InitializeLevel2_1();
                    break;
                }
            case 7:
                {
                    InitializeLevel2_2();
                    break;
                }
            case 8:
                {
                    InitializeLevel2_3();
                    break;
                }
            case 9:
                {
                    InitializeLevel2_4();
                    break;
                }
            case 10:
                {
                    InitializeLevel2_5();
                    break;
                }
            case 11:
                {
                    InitializeLevel3_1();
                    break;
                }
            case 12:
                {
                    InitializeLevel3_2();
                    break;
                }
            case 13:
                {
                    InitializeLevel3_3();
                    break;
                }
            case 14:
                {
                    InitializeLevel3_4();
                    break;
                }
            case 15:
                {
                    InitializeLevel3_5();
                    break;
                }
        }
    }
}
