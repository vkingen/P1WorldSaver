using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;
    RaycastTrashDetection RcTD;
    GameOverScreen GOS;
    //TrashCollect2 TC2;

    public float playerOneFuel = 100;
    public float playerTwoFuel = 100;
    public float removeFuel = 1;
    private float fullFuel = 100;
    public float refillFuel = 25;

    //public float plasticCollected = 0;
    public int trashCounter;
    //public float addPlastic = 1;
    //public float fullPlastic = 10;
    public int trashLimit;
    //public int shipTrashCounter;
    //public int shipTrashLimit;

    public Slider playerOneFuelSlider, playerTwoFuelSlider;
    public Image playerOneFuelIcon, playerTwoFuelIcon;
    public Image playerOneFill, playerTwoFill;
    //public Slider plasticMeter;
    public TMP_Text trashCounterText;
    //public TMP_Text shipTrashCounterText;
    //public TMP_Text outOfFueltext;
    public TMP_Text playerOneFuelText, playerTwoFuelText;

    //public GameObject healthIconP1, healthIconP2;

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }

    //}

    // Start is called before the first frame update
    void Start()
    {
        RcTD = FindObjectOfType<RaycastTrashDetection>();
        trashCounter = RcTD.trashCounter;
        trashLimit = RcTD.trashLimit;

        //plasticCounter.text = plasticCollected.ToString() + " / " + fullPlastic.ToString();
        trashCounterText.text = trashCounter.ToString() + " / " + trashLimit.ToString();

        GOS = FindObjectOfType<GameOverScreen>();

        //TC2 = FindObjectOfType<TrashCollect2>();
        //shipTrashCounter = TC2.shipTrashCounter;

        //shipTrashCounterText.text = shipTrashCounter.ToString() + " / " + shipTrashLimit.ToString();

        //plasticMeter.value = plasticCollected;
        playerOneFuelSlider.value = playerOneFuel;
        playerTwoFuelSlider.value = playerTwoFuel;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (playerOneFuel <= 0)
        //{
        //    Debug.Log("P1 fuel empty");
        //    playerOneFuel = fullFuel;
        //    playerTwoFuel = fullFuel;
        //    playerOneFuelSlider.gameObject.SetActive(false);
        //    playerTwoFuelSlider.gameObject.SetActive(false);
        //    //healthIconP1.SetActive(false);
        //    //healthIconP2.SetActive(false);
        //    SceneManager.LoadScene("P2Wins");
        //}
        //else if (playerTwoFuel <= 0)
        //{
        //    Debug.Log("P2 fuel empty");
        //    playerOneFuel = fullFuel;
        //    playerTwoFuel = fullFuel;
        //    playerOneFuelSlider.gameObject.SetActive(false);
        //    playerTwoFuelSlider.gameObject.SetActive(false);
        //    //healthIconP1.SetActive(false);
        //    //healthIconP2.SetActive(false);
        //    SceneManager.LoadScene("P1Wins");
        //}
    }
    /*  public void ShowUI()
    {
        playerOneFuelSlider.gameObject.SetActive(true);
        playerTwoFuelSlider.gameObject.SetActive(true);
        //healthIconP1.SetActive(true);
        //healthIconP2.SetActive(true);
    } */

    public void RemoveFuelPlayerOne()
    {
        playerOneFuel = playerOneFuel - removeFuel * Time.deltaTime;
        playerOneFuelSlider.value = playerOneFuel;

        playerOneFuelText.text = playerOneFuel.ToString("F1") + " %";

        if (playerOneFuel <= 0)
            EmptyFuelPlayerOne();

        if (playerOneFuel <=100 && playerOneFuel > 66.6)
            playerOneFill.GetComponent<Image>().color = new Color32(0, 255, 0, 255);

        else if (playerOneFuel <= 66.6 && playerOneFuel > 33.3)
            playerOneFill.GetComponent<Image>().color = new Color32(255, 255, 0, 255);

        else if (playerOneFuel <= 33.3)
            playerOneFill.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }

    public void RemoveFuelPlayerTwo()
    {
        playerTwoFuel = playerTwoFuel - removeFuel * Time.deltaTime;
        playerTwoFuelSlider.value = playerTwoFuel;

        playerTwoFuelText.text = playerTwoFuel.ToString("F1") + " %";

        if (playerTwoFuel <= 0)
            EmptyFuelPlayerTwo();

        if (playerTwoFuel <= 100 && playerOneFuel > 66.6)
            playerTwoFill.GetComponent<Image>().color = new Color32(0, 255, 0, 255);

        else if (playerTwoFuel <= 66.6 && playerOneFuel > 33.3)
            playerTwoFill.GetComponent<Image>().color = new Color32(255, 255, 0, 255);

        else if (playerTwoFuel <= 33.3)
            playerTwoFill.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }

    public void EmptyFuelPlayerOne()
    {
        FuelIsEmptyMethod();
        //Debug.Log("P1 fuel empty");
        //playerOneFuel = fullFuel;
        //playerTwoFuel = fullFuel;
        //playerOneFuelSlider.gameObject.SetActive(false);
        //playerTwoFuelSlider.gameObject.SetActive(false);
        //playerOneFuelIcon.gameObject.SetActive(false);
        //playerTwoFuelIcon.gameObject.SetActive(false);
        ////outOfFueltext.text = "You ran out of fuel"; // This should be a variable.
        //GOS.GameOver();
    }

    public void EmptyFuelPlayerTwo()
    {
        FuelIsEmptyMethod();
        //Debug.Log("P2 fuel empty");
        //playerOneFuel = fullFuel;
        //playerTwoFuel = fullFuel;
        //playerOneFuelSlider.gameObject.SetActive(false);
        //playerTwoFuelSlider.gameObject.SetActive(false);
        //trashCounterText.gameObject.SetActive(false);
        //playerOneFuelIcon.gameObject.SetActive(false);
        //playerTwoFuelIcon.gameObject.SetActive(false);
        ////outOfFueltext.text = "You ran out of fuel"; // This should be a variable.
        //GOS.GameOver();
    }

    public void FuelIsEmptyMethod()
    {
        playerOneFuel = fullFuel;
        playerTwoFuel = fullFuel;
        playerOneFuelSlider.gameObject.SetActive(false);
        playerTwoFuelSlider.gameObject.SetActive(false);
        trashCounterText.gameObject.SetActive(false);
        playerOneFuelIcon.gameObject.SetActive(false);
        playerTwoFuelIcon.gameObject.SetActive(false);
        //outOfFueltext.text = "You ran out of fuel"; // This should be a variable.
        GOS.GameOver();
    }

    public void Refuel()
    {
        playerOneFuel = playerOneFuel + refillFuel;
        if (playerOneFuel >= fullFuel)
            playerOneFuel = fullFuel;
        playerTwoFuel = playerTwoFuel + refillFuel;
        if (playerTwoFuel >= fullFuel)
            playerTwoFuel = fullFuel;
        Debug.Log(playerOneFuel);
        Debug.Log("Adding Fuel");
    }

    //public void plasticPickUp()
    //{
    //    plasticCollected = plasticCollected + addPlastic;
    //    plasticCounter.text = plasticCollected.ToString() + " / " + fullPlastic.ToString();
    //}

    public void trashCounterUpdate()
    {
        trashCounter = RcTD.trashCounter;
        trashLimit = RcTD.trashLimit;
        trashCounterText.text = trashCounter.ToString() + " / " + trashLimit.ToString();
    }

    //public void shipTrashCounterUpdate()
    //{
    //    shipTrashCounter = TC2.shipTrashCounter;
    //    shipTrashCounterText.text = shipTrashCounter.ToString() + " / " + shipTrashLimit.ToString();
    //}
}
