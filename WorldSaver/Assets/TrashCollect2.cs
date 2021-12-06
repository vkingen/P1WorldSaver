using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollect2 : MonoBehaviour
{
    RaycastTrashDetection rTD;
    public int shipTrashCounter;

    private void Start()
    {
        rTD = FindObjectOfType<RaycastTrashDetection>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            shipTrashCounter += rTD.trashCounter;
            rTD.trashCounter = 0;

            int range = shipTrashCounter / 10;
            switch (range)
            {
                case 1:
                    Debug.Log("10");
                    break;
                case 2:
                    Debug.Log("20");
                    break;
                case 3:
                    Debug.Log("30");
                    break;
            }
        }
    }
}
