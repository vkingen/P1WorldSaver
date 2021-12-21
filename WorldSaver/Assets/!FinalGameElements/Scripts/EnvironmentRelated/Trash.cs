using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [Header("Tag names")]
    [Tooltip("Tag name: If trash spawns inside these objects, destroy this")]
    public string player1, player2, avoidTrash; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == player1 || other.tag == player2 || other.tag == avoidTrash)
        {
        }
        else
        {
            Destroy(this.gameObject); // Destroy this object if the colllided tag is not equal to the above stated tags
        }
    }
}
