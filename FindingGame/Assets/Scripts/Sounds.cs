using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioSource locationSound;
    public AudioSource levelWonSound;
    public AudioSource levelLostSound;

    PlayerController playerController;
    LevelManager levelManager;

    private bool hasPlayed = false;
    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        levelManager = GameObject.Find("LevelManager").GetComponent <LevelManager>();
    }
    
    void Update()
    {
        if(playerController.GetIsLocationFound())
        {
            locationSound.Play();
        }

        if (levelManager.GetIsGameWon() ==  true && hasPlayed == false)
        {
            levelWonSound.Play();
            hasPlayed = true;
        }
        else if(levelManager.GetIsGameWon() == false && hasPlayed == false)
        {
            levelLostSound.Play();
            hasPlayed = true;
        }
        
    }
}
