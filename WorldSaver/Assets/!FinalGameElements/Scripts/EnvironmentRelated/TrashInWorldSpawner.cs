using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInWorldSpawner : MonoBehaviour
{
    Vector3 center;
    [Tooltip("Size of zone to spawn trash")]
    public Vector3 size;
    Vector3 rotation;

    public GameObject[] trashPrefab; //Array of trash objects to spawn

    public int objectsToSpawn = 10; // The amount the trash objects to spawn
    private void Start()
    {
        center = transform.position; // Setting the center variable to this components transforms position (x,y,z)
    }

    private void Update()
    {
        if (objectsToSpawn > 0)
        {
            objectsToSpawn--; // if objectsToSpawn is bigger than 0, then we reduce it by 1 and 
            SpawnTheTrash(); // spawn a peice of trash
        }
    }

    // Method of spawning trash within a certain range. 
    // First getting a possition within an area and setting the rotation of each trash object with a different value
    // Secondly a random trash object is instantiated in the world with the position and rotation stated above
    public void SpawnTheTrash()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        rotation = new Vector3(0, Random.Range(0, 359));
        GameObject trashClone = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], pos, Quaternion.Euler(rotation));
    }
}
