using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeConnectionPoint : MonoBehaviour
{
    public Transform position;

    private void Update()
    {
        transform.position = position.position;
    }
}
