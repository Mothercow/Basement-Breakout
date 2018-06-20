using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue Pdialogue;
    public Dialogue Ndialogue;
    public bool solved = false;


    public void TriggerDialogue ()
	{
        
        if (solved == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Pdialogue);
        }
        else if(solved == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Ndialogue);
        }
		
	}
    
}
