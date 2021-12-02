using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.SceneManagement;

public class MovementTest : MonoBehaviour
{
    InGameUI IGUI;
    private int playerOneFuel;
    private int playerTwoFuel;

    Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;

    private float vInput;
    private float hInput;

    public ObiRope OR;
    public ObiStructuralElement rope;

    public Transform p1, p2;

    [Range(0,20)] //Creates a visual sliding bar in the inspector named 'distance'. 
    public float distance;
    public float distanceToTear = 20;

    bool isTeared = false;

    [SerializeField] //Makes the bool public in the inspector in unity but not accessible for other scripts.
    bool isPlayerOne;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rope = OR.GetComponent<ObiStructuralElement>();

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
            if (rb.velocity.magnitude > 0)
                    {
                        InGameUI.instance.RemoveFuelPlayerOne();
                    }
        }
        else //Player 2 movement. "Vertical2" and "Horizontal2" are controls decided in unity's Input Manager.
        {
            vInput = Input.GetAxis("Vertical2") * moveSpeed;
            hInput = Input.GetAxis("Horizontal2") * rotateSpeed;
            if (rb.velocity.magnitude > 0)
                    {
                        InGameUI.instance.RemoveFuelPlayerTwo();
                    }
        }
        
    }

    void Tear() //Measures the distance between the players and enables tearing when 'distance' becomes greater than 'distanceToTear'.
    {
        distance = Vector3.Distance(p1.position, p2.position); //Measures the distance between the players.
        if (distance > distanceToTear)
        {
            OR.tearingEnabled = true;

            Application.LoadLevel(Application.loadedLevel); //temporary
        }
    }

    private void FixedUpdate()
    {
        Tear();

        Vector3 rotation = Vector3.up * hInput; //Decides the rotation with a Vector 3 variable.
        
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime); //Page 194, in C# book

        rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime); //Page 194, in C# book
       
        rb.MoveRotation(rb.rotation * angleRot); //Page 194, in C# book
    }

}
