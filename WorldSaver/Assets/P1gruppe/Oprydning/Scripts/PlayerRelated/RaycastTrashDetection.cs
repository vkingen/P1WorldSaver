using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrashDetection : MonoBehaviour
{
    public static RaycastTrashDetection instance; // Aske is this used??
    LineRenderer lR; 
    Movement movementScript; 

    private AudioSource ropeTearingSound, ropeTearedSpeak, ropeSnap, trashSound, fullCapacity; // Different audio source references

    private bool ropeIsTearing = false; // bool used in other scripts

    [HideInInspector]
    public int trashCounter; // amount of trash collected

    [HideInInspector]
    public bool isResetted = true; // reset bool used in other scripts

    float distance; // distance between players
    [Header("Raycast and Line Renderer")]
    [Tooltip("Max distance for the rope")]
    public float distanceToTear;
    [Tooltip("Width of the rope")]
    public float width = 1f;
    [Tooltip("Max trash that can be collected")]
    public int trashLimit = 10;

    [Header("Player References")]
    [Tooltip("Drag both players here (To calculate distance)")]
    public Transform p1;
    public Transform p2;

    InGameUI IGUI; 

    [HideInInspector]
    public bool isTeared = false;
    
    private void Start()
    {
        // Following 5 lines of code finds Audio Sources through child objects of this gameobject
        ropeTearingSound = this.gameObject.transform.Find("RopeIsTearing").GetComponent<AudioSource>();
        ropeTearedSpeak = this.gameObject.transform.Find("RopeTearedSpeak").GetComponent<AudioSource>();
        ropeSnap = this.gameObject.transform.Find("RopeSnap").GetComponent<AudioSource>();
        trashSound = this.gameObject.transform.Find("TrashCollectSound").GetComponent<AudioSource>();
        fullCapacity = this.gameObject.transform.Find("MaxCapacitySound").GetComponent<AudioSource>();

        movementScript = GetComponent<Movement>(); // Getting the Movement component
        IGUI = FindObjectOfType<InGameUI>(); // Finding the InGameUI script in the scene

        // Following lines is setting the line renderer values
        lR = GetComponent<LineRenderer>();
        lR.startColor = Color.green;
        lR.endColor = Color.green;
        lR.startWidth = width;
        lR.endWidth = width;
        lR.positionCount = 2;
        lR.useWorldSpace = true;    
    }

    public void SetLineRendererPos()
    {
        if(!isTeared)
        {
            lR.enabled = true;
            lR.SetPosition(0, transform.position);
            lR.SetPosition(1, p2.transform.position);
        }
        else
        {
            lR.enabled = false;
        }
    }

    void Tear() //Measures the distance between the players and enables tearing when 'distance' becomes greater than 'distanceToTear'.
    {
        distance = Vector3.Distance(p1.position, p2.position); //Measures the distance between the players.
        if (distance > distanceToTear && isTeared == false) // if the distance is too far set isTeared to true
        {
            isTeared = true;
        }
    }

    void ChangeColor()
    {
        if (distance > 0 && distance < 50) // if distance is in between these values set the line renderer color to green
        {
            ropeIsTearing = false;
            lR.startColor = Color.green;
            lR.endColor = Color.green;
        }
        else if (distance > 50 && distance < 65) // if distance is in between these values set the line renderer color to yellow
        {
            ropeIsTearing = false;
            lR.startColor = Color.yellow;
            lR.endColor = Color.yellow;
        }
        else if (distance > 65 && distance < 75) // if distance is in between these values set the line renderer color to red
        {
            ropeIsTearing = true;
            lR.startColor = Color.red;
            lR.endColor = Color.red;
        }
    }

    public void RopeTear() // This method is to change the volume of rope tearing sound
    {
        if (ropeIsTearing)
        {
            ropeTearingSound.volume = 1;
        }
        else
        {
            ropeTearingSound.volume = 0;
        }

        if(isTeared)
            ropeTearingSound.volume = 0;
    }

    void HitDetection()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (p2.position - transform.position), out hit, distanceToTear))
        {
            if  (hit.transform.tag == "Plastic") // only detect the tag "Plastic"
            {
                if (trashCounter < trashLimit)
                {
                    trashSound.Play(); // Play audio when picked up
                    Destroy(hit.transform.gameObject); // destroy the hit gameobject

                    trashCounter++; // add 1 to the trash counter
                    if (trashCounter == trashLimit && isResetted)
                    {
                        fullCapacity.Play(); // play audio when full capacity
                        isResetted = false; // the player needs to reset this value when delivering the plastic at the cargo ship
                    }
                    IGUI.trashCounterUpdate();
                }
            }
        }
    }

    private void Update()
    {
        if(!isTeared)
        {
            SetLineRendererPos();
            HitDetection();
            Tear();
            ChangeColor();
            RopeTear();
            ropeTearedSpeak.Play();
            ropeSnap.Play();
        }
        else
        {
            RopeTear();
            lR.enabled = false;            
        }
    }
}
