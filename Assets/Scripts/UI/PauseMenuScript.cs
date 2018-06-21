using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUI;

    Scene curScene;

    private void Start()
    {
        curScene = SceneManager.GetActiveScene();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(curScene.name);
    }

    public void PauseAndResume()
    {
        if(Time.timeScale == 1f)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Time.timeScale == 0f)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    
}
