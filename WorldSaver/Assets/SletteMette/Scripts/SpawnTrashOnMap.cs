using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrashAndAnimal : MonoBehaviour
{
    public Vector3 center; 
    public Vector3 size;
    Vector3 rotation;

    public GameObject[] trashPrefab;

    public int objectsToSpawn = 10;
    private void Start()
    {
        center = transform.position; // Setting the center variable to this components transforms position (x,y,z)
       
    }

    private void Update()
    {
        if (objectsToSpawn > 0)
        {
            objectsToSpawn--;
            SpawnTheTrash();
        }
    } 
    public void SpawnTheTrash()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        rotation = new Vector3(0,Random.Range(0,359));
        GameObject trashClone = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], pos, Quaternion.Euler(rotation));
    }
}
