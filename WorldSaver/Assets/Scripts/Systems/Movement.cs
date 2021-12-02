using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    InGameUI IGUI;
    private float playerOneFuel;
    private float playerTwoFuel;

    Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;

    private float vInput;
    private float hInput;


    

    //[Range(0,20)] //Creates a visual sliding bar in the inspector named 'distance'. 
    

    bool isTeared = false;

    [SerializeField] //Makes the bool public in the inspector in unity but not accessible for other scripts.
    bool isPlayerOne;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        IGUI = FindObjectOfType<InGameUI>();
        //IGUI.ShowUI();

        playerOneFuel = GameObject.Find("InGameUI").GetComponent<InGameUI>().playerOneFuel;
        playerTwoFuel = GameObject.Find("InGameUI").GetComponent<InGameUI>().playerTwoFuel;

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOne) //Player1 movement. "Vertical" and "Horizontal" are controls decided in unity's Input Manager.
        {
            vInput = Input.GetAxis("Vertical") * moveSpeed;
            hInput = Input.GetAxis("Horizontal") * rotateSpeed;
            if (vInput != 0 || hInput != 0)
            {
                IGUI.RemoveFuelPlayerOne();
            }
        }
        else //Player 2 movement. "Vertical2" and "Horizontal2" are controls decided in unity's Input Manager.
        {
            vInput = Input.GetAxis("Vertical2") * moveSpeed;
            hInput = Input.GetAxis("Horizontal2") * rotateSpeed;
            if (vInput != 0 || hInput != 0)
            {
                IGUI.RemoveFuelPlayerTwo();
            }
        }
        
    }

   

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput; //Decides the rotation with a Vector 3 variable.
        
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime); //Page 194, in C# book

        rb.velocity = transform.forward * vInput;
        //rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime); //Page 194, in C# book

        rb.MoveRotation(rb.rotation * angleRot); //Page 194, in C# book
    }
}
