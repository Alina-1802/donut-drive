using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int numberCompletedLevels = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(numberCompletedLevels);
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
