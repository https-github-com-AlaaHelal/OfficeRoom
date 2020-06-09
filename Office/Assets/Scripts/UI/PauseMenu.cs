using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;


    private void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        // to play the game back
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        // to freeze thee game
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitTheGame()

    {
        Debug.Log("QuitTheGame");
        Application.Quit();
    }




    public void exitcanvas()
    {

        PauseMenuUI.SetActive(false);
    }



  
}
