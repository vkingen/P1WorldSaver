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

    public float playerOneFuel = 100;
    public float playerTwoFuel = 100;
    public float removeFuel = 1;
    private float fullFuel = 100;

    //public float plasticCollected = 0;
    public int trashCounter;
    //public float addPlastic = 1;
    //public float fullPlastic = 10;
    public int trashLimit;

    public Slider playerOneFuelSlider, playerTwoFuelSlider;
    //public Slider plasticMeter;
    public TMP_Text plasticCounter;

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

        GOS = FindObjectOfType<GameOverScreen>();

        //plasticMeter.value = plasticCollected;
        playerOneFuelSlider.value = playerOneFuel;
        playerTwoFuelSlider.value = playerTwoFuel;

        //plasticCounter.text = plasticCollected.ToString() + " / " + fullPlastic.ToString();
        plasticCounter.text = trashCounter.ToString() + " / " + trashLimit.ToString();
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
        if (playerOneFuel <= 0)
            EmptyFuelPlayerOne();
    }

    public void RemoveFuelPlayerTwo()
    {
        playerTwoFuel = playerTwoFuel - removeFuel * Time.deltaTime;
        playerTwoFuelSlider.value = playerTwoFuel;
        if (playerTwoFuel <= 0)
            EmptyFuelPlayerTwo();
    }

    public void EmptyFuelPlayerOne()
    {
        
        Debug.Log("P1 fuel empty");
        playerOneFuel = fullFuel;
        playerTwoFuel = fullFuel;
        playerOneFuelSlider.gameObject.SetActive(false);
        playerTwoFuelSlider.gameObject.SetActive(false);
        //healthIconP1.SetActive(false);
        //healthIconP2.SetActive(false);
        GOS.GameOver();
    }

    public void EmptyFuelPlayerTwo()
    {
        Debug.Log("P2 fuel empty");
        playerOneFuel = fullFuel;
        playerTwoFuel = fullFuel;
        playerOneFuelSlider.gameObject.SetActive(false);
        playerTwoFuelSlider.gameObject.SetActive(false);
        plasticCounter.gameObject.SetActive(false);
        //healthIconP1.SetActive(false);
        //healthIconP2.SetActive(false);
        GOS.GameOver();
    }

    //public void plasticPickUp()
    //{
    //    plasticCollected = plasticCollected + addPlastic;
    //    plasticCounter.text = plasticCollected.ToString() + " / " + fullPlastic.ToString();
    //}

    public void plasticPickUp()
    {
        trashCounter = RcTD.trashCounter;
        trashLimit = RcTD.trashLimit;
        plasticCounter.text = trashCounter.ToString() + " / " + trashLimit.ToString();
    }
}
