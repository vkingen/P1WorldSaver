using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashPatchWithAnimalsSpawner : MonoBehaviour
{
    InGameUI IGUI;
    TrashCollect2 tC2;
    Vector3 center; 
    [Tooltip("Size of zone to spawn trash")]
    public Vector3 size;
    Vector3 rotation;


    public GameObject[] trashPrefab; // Array of trash objects to spawn
    public GameObject[] animals; // array of animal objects to spawn
    GameObject animalClone; 

    [HideInInspector]
    public List<GameObject> trashArray; // list of trash that is checked and when empty, the animal is saved
    bool missionComplete = false;
    int objectsToRemove;
    float animationMoveSpeed = 3; // the speed of the animal when rescued

    bool hasAddedFuel = false; // a bool to prevent the InGameUI.Refuel method of looping the refuel



    int objectsToSpawn; // The amount the trash objects to spawn
    public int maxObjectsTospawn, minObjectsToSpawn;
    int objectsSpawned;
    public TMP_Text trashCounterText;
    private void Start()
    {
        IGUI = FindObjectOfType<InGameUI>();
        tC2 = FindObjectOfType<TrashCollect2>();

        objectsToSpawn = Random.Range(minObjectsToSpawn, maxObjectsTospawn); // Setting the amount of trash spawned within a range
        objectsSpawned = objectsToSpawn; // Set objects spawned to the amount defined above.
        center = transform.position; // Setting the center variable to this components transforms position (x,y,z)
        animalClone = Instantiate(animals[Random.Range(0, animals.Length)], center, Quaternion.identity); // Spawning a random animal at the center position of this position
        animalClone.transform.position += new Vector3(0, 2, 0); // Offsetting the position of the animal because it spawned below the water
        trashCounterText.text = objectsToSpawn.ToString(); // Set the UI text of trash counter to the objectsToSpawn variable
    }

    private void FixedUpdate()
    {
        if (objectsToSpawn > 0) 
        {
            objectsToSpawn--; // if objectsToSpawn is bigger than 0, then we reduce it by 1 and 
            SpawnTheTrash(); // spawn a peice of trash
        }
        objectsToRemove = objectsSpawned; // before looping through alle the game objects in the list, reset the values
        foreach (var obj in trashArray)
        {
            if (obj == null)
            {
                // objectsToRemove value is set to the amount of objects spawned above the foreach and reducing the value here when an object is 
                // removed from the list. The tashcounter text is updated to the value.
                objectsToRemove--; 
                trashCounterText.text = objectsToRemove.ToString();
            }
        }
        if (objectsToRemove == 0)
        {
            animalClone.transform.position += Vector3.down * Time.deltaTime * animationMoveSpeed; // Animating the animalClone to translate downwards
            animalClone.gameObject.GetComponentInChildren<Animator>().SetBool("Dive", true); // Activating the animalsClones Dive animation

            trashCounterText.gameObject.SetActive(false); // Deactivating the Trash counter text object 

            if(!hasAddedFuel) 
            {
                IGUI.Refuel(); // Add fuel via InGameUI script
                tC2.animalsCounter++; // Adding 1 to animalsCounter to track how many animals has been saved
                hasAddedFuel = true; // Set the hasAddedFuel to true, so fuel can't be added again.
            }
                
        }
    }

    // Method of spawning trash within a certain range. 
    // First getting a possition within an area and setting the rotation of each trash object with a different value
    // Secondly a random trash object is instantiated in the world with the position and rotation stated above
    // At last that specific trash object is placed in a list, that is used to check 
    public void SpawnTheTrash()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        rotation = new Vector3(0, Random.Range(0, 359));
        GameObject trashClone = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], pos, Quaternion.Euler(rotation));
        trashArray.Add(trashClone);
    }
}
