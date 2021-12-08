using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject[] objectsToDisable;

    private void Start()
    {
        winMenu.SetActive(false);//så menuen ikke er der fra start

    }

    public void StartNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }


    public void WinGame()//method til at pause
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
        winMenu.SetActive(true);
        
        Time.timeScale = 0f;//sætter alt på pause

    }

}
