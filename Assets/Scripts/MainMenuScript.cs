using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Playing Game");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
	
    public void Credits()
    {
        Debug.Log("Going into credits");
        SceneManager.LoadScene("Credits");
    }
}
