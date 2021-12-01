using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrashDetection : MonoBehaviour
{
    public GameObject playerTwo;
    public float maxRange;

    LineRenderer lR;

    private void Start()
    {
        lR = GetComponent<LineRenderer>();
        lR.startColor = Color.black;
        lR.endColor = Color.black;
        lR.startWidth = 0.1f;
        lR.endWidth = 0.1f;
        lR.positionCount = 2;
        lR.useWorldSpace = true;
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
    }
}
