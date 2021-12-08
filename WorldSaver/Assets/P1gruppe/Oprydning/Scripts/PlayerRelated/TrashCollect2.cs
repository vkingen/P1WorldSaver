using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TrashCollect2 : MonoBehaviour
{
    public static TrashCollect2 instance;

    InGameUI IGUI;

    public TMP_Text boatCapacity;
    int range;
    public int boatMaxCapacity = 5;

    RaycastTrashDetection rTD;
    public int shipTrashCounter;

    public GameObject[] containerArray;

    private void Start()
    {
        IGUI = FindObjectOfType<InGameUI>();
        range = shipTrashCounter / 10;
        boatCapacity.text = range.ToString() + " / " + boatMaxCapacity.ToString();

        rTD = FindObjectOfType<RaycastTrashDetection>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            shipTrashCounter += rTD.trashCounter;
            rTD.trashCounter = 0;
            IGUI.trashCounterUpdate();
            //IGUI.shipTrashCounterUpdate();
            Debug.Log("resetRope");
            rTD.isTeared = false;
            rTD.isResetted = true;

            range = shipTrashCounter / 10;
            switch (range)
            {
                case 1:
                    containerArray[0].SetActive(true);
                    break;
                case 2:
                    containerArray[1].SetActive(true);
                    break;
                case 3:
                    containerArray[2].SetActive(true);
                    break;
                case 4:
                    containerArray[3].SetActive(true);
                    break;
                case 5:
                    containerArray[4].SetActive(true);
                    break;
                case 6:
                    containerArray[5].SetActive(true);
                    break;
                case 7:
                    containerArray[6].SetActive(true);
                    break;
                case 8:
                    containerArray[7].SetActive(true);
                    break;
                case 9:
                    containerArray[8].SetActive(true);
                    break;
                case 10:
                    containerArray[9].SetActive(true);
                    break;
                case 11:
                    containerArray[10].SetActive(true);
                    break;
                case 12:
                    containerArray[11].SetActive(true);
                    break;
                case 13:
                    containerArray[12].SetActive(true);
                    break;
                case 14:
                    containerArray[13].SetActive(true);
                    break;
                case 15:
                    containerArray[14].SetActive(true);
                    break;
                case 16:
                    containerArray[15].SetActive(true);
                    break;
                case 17:
                    containerArray[16].SetActive(true);
                    break;
                case 18:
                    containerArray[17].SetActive(true);
                    break;
                case 19:
                    containerArray[18].SetActive(true);
                    break;
                case 20:
                    containerArray[19].SetActive(true);
                    break;
                case 21:
                    containerArray[20].SetActive(true);
                    break;
                case 22:
                    containerArray[21].SetActive(true);
                    break;
                case 23:
                    containerArray[22].SetActive(true);
                    break;
                case 24:
                    containerArray[23].SetActive(true);
                    break;
                case 25:
                    containerArray[24].SetActive(true);
                    break;
                case 26:
                    containerArray[25].SetActive(true);
                    break;
                case 27:
                    containerArray[26].SetActive(true);
                    break;
                case 28:
                    containerArray[27].SetActive(true);
                    break;
            }
            boatCapacity.text = range.ToString() + " / " + boatMaxCapacity.ToString();

            if(range == boatMaxCapacity)
            {
                // Change scene?
                Debug.Log("Change scene and/or show newspaper");
            }
        }
    }
}
