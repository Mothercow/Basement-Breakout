using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLoseScreenScript : MonoBehaviour
{
    Scene curScene;

    private void Start()
    {
        curScene = SceneManager.GetActiveScene();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(curScene.name);
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
