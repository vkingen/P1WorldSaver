using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrashDetection : MonoBehaviour
{
    public GameObject playerTwo;
    public float maxRange;

    Movement movementScript;

    public float distance;
    public float distanceToTear;

    LineRenderer lR;

    public Transform p1, p2;

    InGameUI IGUI;
    

    private void Start()
    {
        movementScript = GetComponent<Movement>();

        lR = GetComponent<LineRenderer>();
        lR.startColor = Color.black;
        lR.endColor = Color.black;
        lR.startWidth = 0.1f;
        lR.endWidth = 0.1f;
        lR.positionCount = 2;
        lR.useWorldSpace = true;
        lR.material = new Material(Shader.Find("Sprites/Default"));

        IGUI = FindObjectOfType<InGameUI>();
        IGUI.plasticPickUp();
    }

    private void FixedUpdate()
    {
        lR.SetPosition(0, transform.position);
        lR.SetPosition(1, playerTwo.transform.position);
    }

    void Tear() //Measures the distance between the players and enables tearing when 'distance' becomes greater than 'distanceToTear'.
    {
        distance = Vector3.Distance(p1.position, p2.position); //Measures the distance between the players.
        if (distance > distanceToTear)
        {
            //Application.LoadLevel(Application.loadedLevel); //temporary
            Debug.Log("ROPE TEAR");
        }
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (playerTwo.transform.position - transform.position), out hit, maxRange))
        {
            if (hit.transform.tag == "Plastic")
            {
                Debug.Log(hit.transform.name + " is picked up");
                Destroy(hit.transform.gameObject);
                InGameUI.instance.plasticPickUp();
            }
        }

        Tear();

        if (distance > 0 && distance < 25)
        {
            lR.startColor = Color.green;
            lR.endColor = Color.green;

        }
        else if(distance > 25 && distance < 50)
        {
            lR.startColor = Color.yellow;
            lR.endColor = Color.yellow;

        }
        else if (distance > 50 && distance < 75)
        {
           
            lR.startColor = Color.red;
            lR.endColor = Color.red;
        }
    }
}
