using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrashDetection : MonoBehaviour
{
    public static RaycastTrashDetection instance;

    public AudioSource ropeSound;
    bool ropeIsTearing = false;
    public float ropeTearMaxVolume = 1;

    public GameObject playerTwo;
    public float maxRange;

    public int trashCounter;
    public int trashLimit = 10;

    Movement movementScript;

    public float distance;
    public float distanceToTear;
    public float width = 1f;

    LineRenderer lR;

    public Transform p1, p2;

    InGameUI IGUI;

    public bool isTeared = false;
    

    private void Start()
    {
        movementScript = GetComponent<Movement>();

        lR = GetComponent<LineRenderer>();
        lR.startColor = Color.black;
        lR.endColor = Color.black;
        lR.startWidth = width;
        lR.endWidth = width;
        lR.positionCount = 2;
        lR.useWorldSpace = true;
        //lR.material = new Material(Shader.Find("Sprites/Default"));

        IGUI = FindObjectOfType<InGameUI>();
        //IGUI.plasticPickUp();
    }

    public void SetLineRendererPos()
    {
        lR.SetPosition(0, transform.position);
        lR.SetPosition(1, playerTwo.transform.position);
    }

   

    void Tear() //Measures the distance between the players and enables tearing when 'distance' becomes greater than 'distanceToTear'.
    {
        distance = Vector3.Distance(p1.position, p2.position); //Measures the distance between the players.
        if (distance > distanceToTear && isTeared == false)
        {
            isTeared = true;
            //Application.LoadLevel(Application.loadedLevel); //temporary
            Debug.Log("ROPE TEAR");
        }
    }

    void ChangeColor()
    {
        if (distance > 0 && distance < 50)
        {
            ropeIsTearing = false;
            lR.startColor = Color.green;
            lR.endColor = Color.green;

        }
        else if (distance > 50 && distance < 65)
        {
            ropeIsTearing = false;
            lR.startColor = Color.yellow;
            lR.endColor = Color.yellow;

        }
        else if (distance > 65 && distance < 75)
        {
            ropeIsTearing = true;
            lR.startColor = Color.red;
            lR.endColor = Color.red;
        }
    }

    public void RopeTear()
    {
        if (ropeIsTearing)
        {
            ropeSound.volume = ropeTearMaxVolume;
        }
        else
        {
            ropeSound.volume = 0;
        }

        if(isTeared)
            ropeSound.volume = 0;

    }

    void HitDetection()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, (playerTwo.transform.position - transform.position), out hit, maxRange))
        {
            if (trashCounter < trashLimit)
            {
                if (hit.transform.tag == "Plastic")
                {
                    //Debug.Log(hit.transform.name + " is picked up");
                    Destroy(hit.transform.gameObject);

                    trashCounter++;

                    IGUI.plasticPickUp();
                }
            }
            if(hit.transform.tag == "Obstacle")
            {
                // Reset position for players
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
        }
        else
        {
            RopeTear();
            lR.enabled = false;
        }


    }
}