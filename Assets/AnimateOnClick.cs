using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnClick : Interactable
{
    public Animator animator;
    public bool Table;
    public bool Door;
    public bool lockpickgame=false;
    public GameObject gamemanager;
	// Use this for initialization


    public override void Interact()
    {
        //GetComponent<DialogueTrigger>().TriggerDialogue();
        Debug.Log("animating");
        Animate();
        this.GetComponent<AnimateOnClick>().hasInteracted = false;
      
    }
    public void Animate()
    {
        if(Table==true)
        {
            

            animator.Play("drawing");
        }
        if(Door == true)
        {
            if(gamemanager.GetComponent<Inventory>().PC1 == false || gamemanager.GetComponent<Inventory>().PC2 == false)
            {
                animator.Play("shake");
               
            }
        else if(gamemanager.GetComponent<Inventory>().PC1 == true && gamemanager.GetComponent<Inventory>().PC2 == true)
            {
                lockpickgame = true;
            }
        }

    }
}
