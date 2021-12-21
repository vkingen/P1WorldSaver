using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapscript : MonoBehaviour
{
    public Transform player; // Reference to a player 

    void LateUpdate() // using late update because we only want to update the minimap after the player has moved: Late Update is running after update and fixed update
    { 
        Vector3 newPosition = player.position; // defining a vector3 to the players position

        newPosition.y = transform.position.y; // setting the y value of the newPosition to this positions y value
        transform.position = newPosition; // changing the minimap position to the new position
    }
}
