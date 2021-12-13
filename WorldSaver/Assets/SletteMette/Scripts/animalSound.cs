using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalSound : MonoBehaviour
    // The scribt activates the sound of an animal in pain,
    // when the player enters the box collider around it, and stops the sound when both players have exited.


{
    public AudioSource AnimalPain;
    int numberOfPlayerEntered = 0;
    // this variable describes the number of players inside the box colider
    int player = 1;

    private void Start()
    {
        AnimalPain = GetComponent<AudioSource>();
    }

    // The following 2 methods adds or decrease the int variable.

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            numberOfPlayerEntered++;
            CheckPlayerStatus();
        }
        if (other.tag == "Player2")
        {
            numberOfPlayerEntered++;
            CheckPlayerStatus();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1")
        {
            numberOfPlayerEntered--;
            CheckPlayerStatus();
        }
        if (other.tag == "Player2")
        {
            numberOfPlayerEntered--;
            CheckPlayerStatus();
        }
    }

    // the following method states that if 1 or more players have entered the box collider
    // the sound will play, but if 0 players are inside it, it will stop
    void CheckPlayerStatus()
    {
        if(numberOfPlayerEntered >=player)
            
        {
            AnimalPain.Play();
        }

        else
       
        {
            AnimalPain.Stop();
        }
    }
    }
