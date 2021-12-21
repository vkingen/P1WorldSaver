using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSound : MonoBehaviour
{
    AudioSource aS;
    public Movement[] players;
    public float movingPitch, idlePitch;

    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (players[0].isMoving || players[1].isMoving) // changing the pitch depending on whether one of the players are moving or not
            aS.pitch = movingPitch;
        else
            aS.pitch = idlePitch;
    }
}
