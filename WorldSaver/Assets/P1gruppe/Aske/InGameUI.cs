using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;

    public int playerOneFuel = 100;
    public int playerTwoFuel = 100;
    private int fullFuel = 100;
    private int removeFuel = 1;

    public Slider playerOneFuelSlider, playerTwoFuelSlider;
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
        playerOneFuelSlider.value = playerOneFuel;
        playerTwoFuelSlider.value = playerTwoFuel;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOneFuel == 0)
        {
            playerOneFuel = fullFuel;
            playerTwoFuel = fullFuel;
            playerOneFuelSlider.gameObject.SetActive(false);
            playerTwoFuelSlider.gameObject.SetActive(false);
            //healthIconP1.SetActive(false);
            //healthIconP2.SetActive(false);
            SceneManager.LoadScene("P2Wins");
        }
        else if (playerTwoFuel == 0)
        {
            playerOneFuel = fullFuel;
            playerTwoFuel = fullFuel;
            playerOneFuelSlider.gameObject.SetActive(false);
            playerTwoFuelSlider.gameObject.SetActive(false);
            //healthIconP1.SetActive(false);
            //healthIconP2.SetActive(false);
            SceneManager.LoadScene("P1Wins");
        }
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
        playerOneFuel -= removeFuel;
        playerOneFuelSlider.value = playerOneFuel;
    }

    public void RemoveFuelPlayerTwo()
    {
        playerTwoFuel -= removeFuel;
        playerTwoFuelSlider.value = playerTwoFuel;
    }
}
