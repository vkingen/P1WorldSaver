using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //Allows the script to manage UI objects in Unity
using UnityEngine.SceneManagement;      //Allows the script to manage scene objects in Unity
using TMPro;                            //Allows the script to manage TMPro objects in Unity

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;    //Makes this script, InGameUI, accessible via other scripts
    RaycastTrashDetection RcTD;         //Makes the script RaycastTrashDetection accessible via the name RcTD
    GameOverScreen GOS;                 //Makes the script GameOverScreen accessible via the name GOS

    public float playerOneFuel = 100;   //Sets the float value of playerOneFuel to 100
    public float playerTwoFuel = 100;   //Sets the float value of playerTwoFuel to 100
    public float removeFuel = 1;        //Sets the float value of removeFuel to 1
    private float fullFuel = 100;       //Sets the float value of fullFuel to 100
    public float refillFuel = 25;       //Sets the float value of refillFuelto 25

    public int trashCounter;            //Makes the integer, trashCounter, accessible
    public int trashLimit;              //Makes the integer, trashLimit, accessible

    public Slider playerOneFuelSlider, playerTwoFuelSlider; //Makes the two sliders, playerOneFuelSlider, and playerTwoFuelSlider, accessible
    public Image playerOneFuelIcon, playerTwoFuelIcon;      //Makes the two images, playerOneFuelIcon, and playerTwoFuelIcon, accessible
    public Image playerOneFill, playerTwoFill;              //Makes the two images, playerOneFill, and playerTwoFill, accessible
    public TMP_Text trashCounterText;                       //Makes the TMP_Text, trashCounterText, accessible
    public TMP_Text playerOneFuelText, playerTwoFuelText;   //Makes the two TMP_Text, playerOneFuel, and playerTwoFuelText, accessible

    void Start()                                                                                //A method that runs when the game starts
    {
        RcTD = FindObjectOfType<RaycastTrashDetection>();                                       //Finds the object, of which the RaycastTrashDetection script is applied to
        trashCounter = RcTD.trashCounter;                                                       //Makes the integer value of trashCounter equal to the integer value of trashCounter variable found in the RcTD script
        trashLimit = RcTD.trashLimit;                                                           //Makes the integer value of trashLimit equal to the integer value of trashLimit variable found in the RcTD script

        trashCounterText.text = trashCounter.ToString() + " / " + trashLimit.ToString();        //Makes the text value of trashCounterText equal to the string value of trashCounter, " / ", and the string value of trashLimit

        GOS = FindObjectOfType<GameOverScreen>();                                               //Finds the object, of which the GameOverScript is applied to

        playerOneFuelSlider.value = playerOneFuel;                                              //Makes the float value of playerOneFuelSlider equal to the float value of playerOneFuel
        playerTwoFuelSlider.value = playerTwoFuel;                                              //Makes the float value of playerTwoFuelSlider equal to the float value of playerTwoFuel
    }

    public void RemoveFuelPlayerOne()                                   //A method called in Movement script
    {
        playerOneFuel = playerOneFuel - removeFuel * Time.deltaTime;    //Makes the float value of playerOneFuel equal to the same value minus the float value of removeFuel times how fast the time runs in the game
        playerOneFuelSlider.value = playerOneFuel;                      //Makes the float value of playerOneFuelSlider equal to the float value of playerOneFuel

        playerOneFuelText.text = playerOneFuel.ToString("F1") + " %";   //Makes the text value of playerOneFuelText equal to the string value of playerOneFuel with one decimal, and " %"

        if (playerOneFuel <= 0)                                         //An if statements which checks whether playerOneFuel is under or equal to zero
            EmptyFuelPlayerOne();                                       //If the if statement falls through, the method EmptyFuelPlayerOne is called

        if (playerOneFuel <= 100 && playerOneFuel > 66.6)                                //An if statement which checks whether playerOneFuel is under or equal to 100 and over 66.6
            playerOneFill.GetComponent<Image>().color = new Color32(0, 255, 0, 255);    //If the if statement falls through, the color value of the image component of playerOneFill gets changed to green

        else if (playerOneFuel <= 66.6 && playerOneFuel > 33.3)                         //An if statement which checks whether playerOneFuel is under or equal to 66.6 and over 33.3
            playerOneFill.GetComponent<Image>().color = new Color32(255, 255, 0, 255);  //If the if statement falls through, the color value of the image component of playerOneFill gets changed to yellow

        else if (playerOneFuel <= 33.3)                                                 //An if statement which checks whether playerOneFuel is under or equal to 33.3
            playerOneFill.GetComponent<Image>().color = new Color32(255, 0, 0, 255);    //If the if statement falls through, the color value of the image component of playerOneFill gets changed to red
    }

    public void RemoveFuelPlayerTwo()                                   //A method called in Movement script
    {
        playerTwoFuel = playerTwoFuel - removeFuel * Time.deltaTime;    //Makes the float value of playerTwoFuel equal to the same value minus the float value of removeFuel times how fast the time runs in the game
        playerTwoFuelSlider.value = playerTwoFuel;                      //Makes the float value of playerTwoFuelSlider equal to the float value of playerTwoFuel

        playerTwoFuelText.text = playerTwoFuel.ToString("F1") + " %";   //Makes the text value of playerTwoFuelText equal to the string value of playerTwoFuel with one decimal, and " %"

        if (playerTwoFuel <= 0)                                         //An if statements which checks whether playerTwoFuel is under or equal to zero
            EmptyFuelPlayerTwo();                                       //If the if statement falls through, the method EmptyFuelPlayerTwo is called

        if (playerTwoFuel <= 100 && playerOneFuel > 66.6)                               //An if statement which checks whether playerTwoFuel is under or equal to 100 and over 66.6
            playerTwoFill.GetComponent<Image>().color = new Color32(0, 255, 0, 255);    //If the if statement falls through, the color value of the image component of playerOneFill gets changed to green

        else if (playerTwoFuel <= 66.6 && playerOneFuel > 33.3)                         //An if statement which checks whether playerTwoFuel is under or equal to 66.6 and over 33.3
            playerTwoFill.GetComponent<Image>().color = new Color32(255, 255, 0, 255);  //If the if statement falls through, the color value of the image component of playerTwoFill gets changed to yellow

        else if (playerTwoFuel <= 33.3)                                                 //An if statement which checks whether playerTwoFuel is under or equal to 33.3
            playerTwoFill.GetComponent<Image>().color = new Color32(255, 0, 0, 255);    //If the if statement falls through, the color value of the image component of playerTwoFill gets changed to red
    }

    public void EmptyFuelPlayerOne()    //A method called in RemoveFuelPlayerOne
    {
        FuelIsEmptyMethod();            //Calls the FuelIsEmptyMethod
    }

    public void EmptyFuelPlayerTwo()    //A method called in RemoveFuelPlayerTwo
    {
        FuelIsEmptyMethod();            //Calls the FuelisEmpthyMethod
    }

    public void FuelIsEmptyMethod()                         //A method called in RemoveFuelPlayerOne and RemoveFuelPlayerTwo
    {
        playerOneFuel = fullFuel;                           //Makes playerOneFuel equal to fullFuel
        playerTwoFuel = fullFuel;                           //Makes playerTwoFuel equal to fullFuel
        playerOneFuelSlider.gameObject.SetActive(false);    //Sets the gameobject of playerOneFuelSlider to false
        playerTwoFuelSlider.gameObject.SetActive(false);    //Sets the gameobject of playerTwoFuelSlider to false
        trashCounterText.gameObject.SetActive(false);       //Sets the gameobject of trashCounterText to false
        playerOneFuelIcon.gameObject.SetActive(false);      //Sets the gameobject of playerOneFuelIcon to false
        playerTwoFuelIcon.gameObject.SetActive(false);      //Sets the gameobject of playerOneFuelIcon to false
        GOS.GameOver();                                     //Calls the method, GameOver, in the GameOverScript
    }

    public void Refuel()                                    //A method called in ?
    {
        playerOneFuel = playerOneFuel + refillFuel;         //Makes the float value of PlayerOneFuel equal to the same + refillFuel
        if (playerOneFuel >= fullFuel)                      //An if statement checking if playerOneFuel is lower or equal to fullFuel
            playerOneFuel = fullFuel;                       //If the if statement falls true, playerOneFuel is set equal to fullFuel
        playerTwoFuel = playerTwoFuel + refillFuel;         //Makes the float value of PlayerTwoFuel equal to the same + refillFuel
        if (playerTwoFuel >= fullFuel)                      //An if statement checking if playerTwoFuel is lower or equal to fullFuel
            playerTwoFuel = fullFuel;                       //If the if statement falls true, playerTwoFuel is set equal to fullFuel
    }

    public void trashCounterUpdate()                                                        //A method called in ?
    {
        trashCounter = RcTD.trashCounter;                                                   //Sets the integer value of trashCounter equal to the integer value of trashCounter in the RcTD script
        trashLimit = RcTD.trashLimit;                                                       //Sets the integer value of trashLimit equal to the integer value of trashLimit in the RcTD script
        trashCounterText.text = trashCounter.ToString() + " / " + trashLimit.ToString();    //Sets the text value of trashCounterText equal to the string value of trashCounter and " / " and the string value of trashLimit
    }
}
