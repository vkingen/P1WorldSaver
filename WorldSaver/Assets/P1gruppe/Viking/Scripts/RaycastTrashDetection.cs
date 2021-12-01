using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrashDetection : MonoBehaviour
{
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, maxRange))
        {
            if (hit.transform == player)
            {
                // In Range and i can see you!
            }
        }
    }
}
