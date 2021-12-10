using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashPatchWithAnimalsSpawner : MonoBehaviour
{
    InGameUI IGUI;
    TrashCollect2 tC2;
    public Vector3 center;
    public Vector3 size;
    Vector3 rotation;


    public GameObject[] trashPrefab;
    public GameObject[] animals;
    public GameObject animalClone;

    public List<GameObject> trashArray;
    bool missionComplete = false;
    int objectsToRemove;
    float animationMoveSpeed = 3;

    bool hasAddedFuel = false;



    int objectsToSpawn = 10;
    public int maxObjectsTospawn, minObjectsToSpawn;
    int objectsSpawned;
    public TMP_Text trashCounterText;
    private void Start()
    {
        objectsToSpawn = Random.Range(minObjectsToSpawn, maxObjectsTospawn);
        tC2 = FindObjectOfType<TrashCollect2>();
        objectsSpawned = objectsToSpawn;
        center = transform.position; // Setting the center variable to this components transforms position (x,y,z)
        animalClone = Instantiate(animals[Random.Range(0, animals.Length)], center, Quaternion.identity); // Spawning a random animal at the center position
        animalClone.transform.position += new Vector3(0, 2, 0); // Offsetting the position of the animal 
        trashCounterText.text = objectsToSpawn.ToString();


        IGUI = FindObjectOfType<InGameUI>();
    }



    private void FixedUpdate()
    {
        if (objectsToSpawn > 0)
        {
            objectsToSpawn--;

            SpawnTheTrash();
        }
        objectsToRemove = objectsSpawned;
        foreach (var obj in trashArray)
        {
            if (obj == null)
            {
                objectsToRemove--;
                trashCounterText.text = objectsToRemove.ToString();
            }
        }
        if (objectsToRemove == 0)
        {
            animalClone.transform.position += Vector3.down * Time.deltaTime * animationMoveSpeed;
            animalClone.gameObject.GetComponentInChildren<Animator>().SetBool("Dive", true);

            trashCounterText.gameObject.SetActive(false);

            if(!hasAddedFuel)
            {
                IGUI.Refuel();
                tC2.animalsCounter++;
                hasAddedFuel = true;
            }
                
        }
    }



    public void SpawnTheTrash()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        rotation = new Vector3(0, Random.Range(0, 359));
        GameObject trashClone = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], pos, Quaternion.Euler(rotation));
        trashArray.Add(trashClone);
    }
}
