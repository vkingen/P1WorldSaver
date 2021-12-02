using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltMovement : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody rb;
    public bool isPlayerOne;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isPlayerOne)
        {
            float horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, 0);
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal2");
            rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, 0);
        }
    }
}
