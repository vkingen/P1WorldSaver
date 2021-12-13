using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [Tooltip("String of scene name when pressing play")]
    public string whenPressingPlay; 
    public void PlayGame()
    {
        SceneManager.LoadScene(whenPressingPlay); // Loading scene via scenemanger with the "whenPressingPlay" string
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Loarding MainMenu scene
    }

    public void QuitGame()
    {
        Application.Quit(); //QuitButton calls this method, which quits the game
    }
}
