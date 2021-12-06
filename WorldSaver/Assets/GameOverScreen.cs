using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public GameObject gameOverScreen;



    RaycastTrashDetection raycastTrashDetection;

    private void Start()
    {
        raycastTrashDetection = FindObjectOfType<RaycastTrashDetection>();
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        if (raycastTrashDetection.isTeared == true)
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;

    }

    public void PlayAgain()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene());

        Application.LoadLevel(Application.loadedLevel);


    }

        
}



