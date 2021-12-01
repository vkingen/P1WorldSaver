using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour
{
    LineRenderer lR;
    public Transform player1, player2;

    public float distance;

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
        lR.SetPosition(0, player1.position);
        lR.SetPosition(1, player2.position);

        distance = Vector3.Distance(player1.position, player2.position);

        RaycastHit hit;
        if (Physics.Raycast(player1.position, (player2.position - player1.position), out hit, 100))
        {
            if (hit.transform.tag == "Test")
            {
                Debug.Log("BOOM");
                // In Range and i can see you!
            }
        }
        Debug.DrawRay(player1.position, (player2.position - player1.position), Color.green);

        //// Does the ray intersect any objects excluding the player layer
        //if (Physics.Raycast(player1.position, player2.position, out hit))
        //{
        //    Debug.DrawRay(player1.position, player2.position, Color.green);
        //    if (hit.transform.gameObject.tag == "Test")
        //        Debug.Log("hit");
        //}
    }
}
