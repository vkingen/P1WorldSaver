using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public string player1, player2, avoidTrash;
    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag != player1 || other.tag != player2 || other.tag != avoidTrash)
        //{
        //    Debug.Log( other.gameObject.name); 
        //    Destroy(this.gameObject);
        //    Debug.Log("Trash Removed");
        //}
        if (other.tag == player1 || other.tag == player2 || other.tag == avoidTrash)
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
