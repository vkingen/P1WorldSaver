using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public GameObject gameOverScreen;

    public AudioSource p1, p2;

    RaycastTrashDetection raycastTrashDetection;

    private void Start()
    {
        Time.timeScale = 1f;
        raycastTrashDetection = FindObjectOfType<RaycastTrashDetection>();
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        
        //if (raycastTrashDetection.isTeared == true)
        //{
        //    GameOver();
        //}

    }

    public void GameOver()
    {
        p1.enabled = false;
        p2.enabled = false;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}



