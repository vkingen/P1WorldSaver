using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrashAndAnimal : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    Vector3 rotation;

    public GameObject[] trashPrefab;
    public GameObject[] animals;
    public GameObject animalClone;
    public int objectsToSpawn = 50;
    private void Start()
    {
        center = transform.position;
        animalClone = Instantiate(animals[Random.Range(0,animals.Length)], center, Quaternion.identity);
        animalClone.transform.Rotate(0,0, 180);
    }

    private void Update()
    {
        if (objectsToSpawn > 0)
        {
            SpawnTheTrash();
        }
    }

    

    public void SpawnTheTrash()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        rotation = new Vector3(0,Random.Range(0,359));
        GameObject trashClone = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], pos, Quaternion.Euler(rotation));
        objectsToSpawn--;
    }
}
