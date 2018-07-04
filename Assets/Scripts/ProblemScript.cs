using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProblemScript : MonoBehaviour
{
    public bool isGasProblem = false;
    public bool isLockProblem = false;

    public GameObject winScreenUI;
    public GameObject loseScreenUI;

    public Text gasTimer;

    public void Update()
    {
        if(gasTimer.GetComponent<Timer>().Seconds == 0)
        {
            loseScreenUI.SetActive(true);
        }
    }

    public void GasProblem()
    {
        Debug.Log("Gas is leaking");
        this.gameObject.GetComponent<Interactable>().hasInteracted = false;
        gasTimer.gameObject.SetActive(true);
    }
    
    public void LockProblem()
    {
        Debug.Log("It's unlocked");
        this.gameObject.GetComponent<Interactable>().hasInteracted = false;
        winScreenUI.SetActive(true);
    }
}
