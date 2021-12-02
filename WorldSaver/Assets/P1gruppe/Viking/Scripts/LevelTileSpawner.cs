using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTileSpawner : MonoBehaviour
{
    public float waitTime;
    public GameObject[] trashToSpawn;

    public Transform[] spawnLocation;
    private void Start()
    {

        //Instantiate(tilesToSpawn[Random.Range(0, tilesToSpawn.Length)], spawnLocation.position, Quaternion.identity);
        StartCoroutine(CreateWithDelay());
    }
    IEnumerator CreateWithDelay()
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(trashToSpawn[Random.Range(0, trashToSpawn.Length)], spawnLocation[Random.Range(0, spawnLocation.Length)].position, Quaternion.identity);
        StartCoroutine(CreateWithDelay());
    }
}
