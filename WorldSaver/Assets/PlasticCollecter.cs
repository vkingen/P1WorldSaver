using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticCollecter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plastic")
            Destroy(other.gameObject);
        
    }
}
