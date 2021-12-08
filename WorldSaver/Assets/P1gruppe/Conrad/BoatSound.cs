using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSound : MonoBehaviour
{
    AudioSource aS;
    public Movement[] players;
    public float movingPitch, idlePitch;

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (players[0].isMoving || players[1].isMoving)
            aS.pitch = movingPitch;
        else
            aS.pitch = idlePitch;
    }
}
