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

    [SerializeField] //gør bool public for inspectoren i unity, men ikke tilgængelig for andre scripts.
    bool isPlayerOne;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOne) //Player1 movement. "Vertical" and "Horizontal" are controls decided in unity's Input Manager.
        {
            vInput = Input.GetAxis("Vertical") * moveSpeed;
            hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        }
        else //Player 2 movement. "Vertical2" and "Horizontal2" are controls decided in unity's Input Manager.
        {
            vInput = Input.GetAxis("Vertical2") * moveSpeed;
            hInput = Input.GetAxis("Horizontal2") * rotateSpeed;
        }
        
    }

    private void FixedUpdate() //Any physics- or Rigidbody-related code always goes inside FixedUpdate.
    {
        Vector3 rotation = Vector3.up * hInput; //Decides the rotation with a Vector 3 variable.
        
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime); 
        // 4
        rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        // 5
        rb.MoveRotation(rb.rotation * angleRot);
    }

}
