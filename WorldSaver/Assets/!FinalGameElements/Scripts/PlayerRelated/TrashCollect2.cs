using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TrashCollect2 : MonoBehaviour
{
    // Script references
    InGameUI IGUI;
    WinScreen wS;
    RadioFacts RF;
    RaycastTrashDetection rTD;

    public TMP_Text boatCapacity, totalTrashCollected;

    public int boatMaxCapacity = 5;
    public int shipTrashCounter;
    public int animalsCounter;
    int range;

    public GameObject[] containerArray;

    private void Start()
    {
        // Finding the scripts in the scene
        RF = FindObjectOfType<RadioFacts>();
        wS = FindObjectOfType<WinScreen>();
        IGUI = FindObjectOfType<InGameUI>();
        rTD = FindObjectOfType<RaycastTrashDetection>();

        boatCapacity.text = range.ToString() + " / " + boatMaxCapacity.ToString() + " full containers"; // Updating the boat capacity text
        totalTrashCollected.text = shipTrashCounter.ToString() + " tonnes of trash collected"; // Updating the total trash collected text
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            shipTrashCounter += rTD.trashCounter;
            totalTrashCollected.text = shipTrashCounter.ToString() + " tonnes of trash collected"; // Updating the total trash collected text
            rTD.trashCounter = 0; // resetting the trashcounter of RaycastTrashDetection script
            IGUI.trashCounterUpdate(); 
            rTD.isTeared = false;
            rTD.isResetted = true;

            range = shipTrashCounter / 10;
            switch (range)
            {
                case 1:
                    containerArray[0].SetActive(true);
                    RF.PlaySound();
                    break;
                case 2:
                    containerArray[1].SetActive(true);
                    RF.PlaySound();
                    break;
                case 3:
                    containerArray[2].SetActive(true);
                    RF.PlaySound();
                    break;
                case 4:
                    containerArray[3].SetActive(true);
                    RF.PlaySound();
                    break;
                case 5:
                    containerArray[4].SetActive(true);
                    RF.PlaySound();
                    break;
                case 6:
                    containerArray[5].SetActive(true);
                    RF.PlaySound();
                    break;
                case 7:
                    containerArray[6].SetActive(true);
                    RF.PlaySound();
                    break;
                case 8:
                    containerArray[7].SetActive(true);
                    RF.PlaySound();
                    break;
                case 9:
                    containerArray[8].SetActive(true);
                    RF.PlaySound();
                    break;
                case 10:
                    containerArray[9].SetActive(true);
                    RF.PlaySound();
                    break;
                case 11:
                    containerArray[10].SetActive(true);
                    RF.PlaySound();
                    break;
                case 12:
                    containerArray[11].SetActive(true);
                    RF.PlaySound();
                    break;
                case 13:
                    containerArray[12].SetActive(true);
                    RF.PlaySound();
                    break;
                case 14:
                    containerArray[13].SetActive(true);
                    RF.PlaySound();
                    break;
                case 15:
                    containerArray[14].SetActive(true);
                    RF.PlaySound();
                    break;
                case 16:
                    containerArray[15].SetActive(true);
                    RF.PlaySound();
                    break;
                case 17:
                    containerArray[16].SetActive(true);
                    RF.PlaySound();
                    break;
                case 18:
                    containerArray[17].SetActive(true);
                    RF.PlaySound();
                    break;
                case 19:
                    containerArray[18].SetActive(true);
                    RF.PlaySound();
                    break;
                case 20:
                    containerArray[19].SetActive(true);
                    RF.PlaySound();
                    break;
                case 21:
                    containerArray[20].SetActive(true);
                    RF.PlaySound();
                    break;
                case 22:
                    containerArray[21].SetActive(true);
                    RF.PlaySound();
                    break;
                case 23:
                    containerArray[22].SetActive(true);
                    RF.PlaySound();
                    break;
                case 24:
                    containerArray[23].SetActive(true);
                    RF.PlaySound();
                    break;
                case 25:
                    containerArray[24].SetActive(true);
                    RF.PlaySound();
                    break;
                case 26:
                    containerArray[25].SetActive(true);
                    RF.PlaySound();
                    break;
                case 27:
                    containerArray[26].SetActive(true);
                    RF.PlaySound();
                    break;
                case 28:
                    containerArray[27].SetActive(true);
                    RF.PlaySound();
                    break;
            }
            boatCapacity.text = range.ToString() + " / " + boatMaxCapacity.ToString() + " full containers"; // Updating the boat capacity text

            if (range == boatMaxCapacity)
            {
                wS.WinGame();
            }
        }
    }
}
