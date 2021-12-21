using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    private void Start()
    {
        pauseMenu.SetActive(false); // disable the pause menu UI from the start

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // if escape is pressed the then change between pause game and resume game
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }  
        }
    }



    public void PauseGame() // pause the game method
    {
        pauseMenu.SetActive(true); // enable the pause menu UI
        Time.timeScale = 0f; // Freeze time
        isPaused = true;
    }


    public void ResumeGame() // resume the game method
    {
        pauseMenu.SetActive(false); // disable the pause menu UI
        Time.timeScale = 1f; // unfreeze the time
        isPaused = false;
    }


}
