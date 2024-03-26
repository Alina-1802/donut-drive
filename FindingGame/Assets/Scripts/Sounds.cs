using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource levelWonSound;
    public AudioSource levelLostSound;
    public AudioSource count1Sound;
    public AudioSource count2Sound;
    public AudioSource count3Sound;
    public AudioSource levelMusic;

    PlayerController playerController;
    LevelManager levelManager;

    private bool hasPlayed = false;
    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        levelManager = GameObject.Find("LevelManager").GetComponent <LevelManager>();

        levelMusic.volume = 0.3f;
    }
    
    void Update()
    {
        if (levelManager.GetIsLevelWon() ==  true && hasPlayed == false)
        {
            levelWonSound.Play();
            hasPlayed = true;
        }
        else if(levelManager.GetIsLevelWon() == false && hasPlayed == false)
        {
            levelLostSound.Play();
            hasPlayed = true;
        }
    }

    public void PlayCount1Sound()
    {
        count1Sound.Play();
    }
    public void PlayCount2Sound()
    {
        count2Sound.Play();
    }

    public void PlayCount3Sound()
    {
        count3Sound.Play();
    }
}
