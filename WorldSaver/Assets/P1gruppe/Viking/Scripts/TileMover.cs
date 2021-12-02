using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    public Vector3 moveDir;
    private void FixedUpdate()
    {
        transform.position += moveDir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestroyTile")
        {
            Destroy(this.gameObject);
        }
    }
}
