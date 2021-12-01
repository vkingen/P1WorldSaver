using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrashDetection : MonoBehaviour
{
    public GameObject playerTwo;
    public float maxRange;

    Movement movementScript;

    LineRenderer lR;

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
    }

    private void FixedUpdate()
    {
        lR.SetPosition(0, transform.position);
        lR.SetPosition(1, playerTwo.transform.position);
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
            }
        }

        if(movementScript.distance > 0 && movementScript.distance < 5)
        {
            lR.startColor = Color.green;
            lR.endColor = Color.green;

        }
        else if(movementScript.distance > 5 && movementScript.distance < 10)
        {
            lR.startColor = Color.green;
            lR.endColor = Color.green;

        }
        else if (movementScript.distance > 10 && movementScript.distance < 15)
        {
            lR.startColor = Color.yellow;
            lR.endColor = Color.yellow;
        }
        else if (movementScript.distance > 15 && movementScript.distance < 20)
        {
            lR.startColor = Color.red;
            lR.endColor = Color.red;
        }


    }
}
