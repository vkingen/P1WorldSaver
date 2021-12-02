using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string whenPressingPlay;
    public void PlayGame()
    {
        SceneManager.LoadScene(whenPressingPlay);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //QuitButton calls this method, which quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
