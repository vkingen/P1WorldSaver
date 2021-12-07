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
        pauseMenu.SetActive(false);//s� menuen ikke er der fra start

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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



    public void PauseGame()//method til at pause
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;//s�tter alt p� pause
        isPaused = true;
    }


    public void ResumeGame()//method til at resume spillet igen
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;//s�tter spillet igang igen
        isPaused = false;
    }


}
