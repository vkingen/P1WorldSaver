using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject[] objectsToDisable;

    public TMP_Text trashCollected, animalsSaved;

    TrashCollect2 tC2;

    private void Start()
    {
        tC2 = FindObjectOfType<TrashCollect2>();
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
        trashCollected.text = tC2.shipTrashCounter.ToString() + "mt trash collected";
        if(tC2.animalsCounter == 1)
            animalsSaved.text = tC2.animalsCounter.ToString() + " animal saved";
        else
            animalsSaved.text = tC2.animalsCounter.ToString() + " animals saved";
        Time.timeScale = 0f;//sætter alt på pause

    }

}
