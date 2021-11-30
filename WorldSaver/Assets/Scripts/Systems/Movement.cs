using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;

    private float vInput;
    private float hInput;

    [SerializeField]
    bool isPlayerOne;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOne)
        {
            vInput = Input.GetAxis("Vertical") * moveSpeed;
            hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        }
        else
        {
            vInput = Input.GetAxis("Vertical2") * moveSpeed;
            hInput = Input.GetAxis("Horizontal2") * rotateSpeed;
        }
        
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        // 3
        Quaternion angleRot = Quaternion.Euler(rotation *
        Time.fixedDeltaTime);
        // 4
        rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        // 5
        rb.MoveRotation(rb.rotation * angleRot);
    }

}
