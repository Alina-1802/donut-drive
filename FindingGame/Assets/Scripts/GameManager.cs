using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int numberCompletedLevels = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void IncreaseCompletedLevelsNumber()
    {
        numberCompletedLevels++;
    }

    public int GetNumberCompletedLevels()
    {
        return numberCompletedLevels; 
    }
}
