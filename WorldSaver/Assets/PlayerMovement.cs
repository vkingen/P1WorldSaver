using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody rb;
    public bool isPlayerOne;
    public bool isMoving = true;
    AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isPlayerOne)
        {
            if (isMoving)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);

                if (rb.velocity.x != 0 || rb.velocity.z != 0)
                {
                    if (!aS.isPlaying)
                    {
                        aS.Play();
                        //Debug.Log("Play");
                    }
                }
                else
                    aS.Stop();
            }

        }
        else
        {
            if (isMoving)
            {
                float horizontal = Input.GetAxis("Horizontal2");
                float vertical = Input.GetAxis("Vertical2");
                rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);

                if (rb.velocity.x != 0 || rb.velocity.z != 0)
                {
                    if (!aS.isPlaying)
                    {
                        aS.Play();
                        //Debug.Log("Play");
                    }
                }
                else
                    aS.Stop();
            }

        }
    }
}
