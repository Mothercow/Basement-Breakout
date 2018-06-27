using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue Pdialogue;
    public Dialogue Ndialogue;
    public bool solved = false;
    public int timeLeft;


    void Start()
    {
        StartCoroutine("LoseTime");
    }

    public void TriggerDialogue()
    {

        if (solved == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Pdialogue);
        }
        else if (solved == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Ndialogue);
        }

    }
    void Update()
    {
        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            FindObjectOfType<DialogueManager>().Clear();
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}