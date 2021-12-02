using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTask : MonoBehaviour
{
    public Rigidbody spawnHarborPorpoise;
    public Transform spawnPosition;
    bool isSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1" || other.tag == "Player2" && isSpawned == false)
        {
            Instantiate(spawnHarborPorpoise, spawnPosition.position, spawnPosition.rotation);
            Debug.Log("Instantiated");

            isSpawned = true;
        } 
    }
}

