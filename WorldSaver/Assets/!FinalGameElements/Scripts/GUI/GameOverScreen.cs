using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen;

    public AudioSource boatMoveAudio;

    RaycastTrashDetection raycastTrashDetection;

    private void Start()
    {
        Time.timeScale = 1f; // Setting the time scale to 1
        raycastTrashDetection = FindObjectOfType<RaycastTrashDetection>();
        gameOverScreen.SetActive(false); // disable the gameobject at first
    }

    public void GameOver()
    {
        boatMoveAudio.enabled = false; // disable the Audio Souce of the boat.
        gameOverScreen.SetActive(true);  // enable the gameobject of game over screen
        Time.timeScale = 0f; // Setting the time scale to 0 and freezing time
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the scene
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Back to main menu scene
    }
}



