using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AandBPuzzle : Interactable
{
    public Item A;
    ProblemScript problemScript;

    private void Start()
    {
        problemScript = this.GetComponent<ProblemScript>();
    }

    private void Update()
    {
      //  Debug.Log(this.hasInteracted);

        if(Inventory.instance.itemOnHand != null)
        {
         //   Debug.Log(Inventory.instance.itemOnHand.name);
        }
  
    }

    public override void Interact()
    {
        Solving();
    }

    void Solving()
    {
        if(Inventory.instance.itemOnHand != null)
        {
            if (A.name == Inventory.instance.itemOnHand.name)
            {
                Debug.Log("Solved");
                if (problemScript.isGasProblem == true)
                {
                    problemScript.GasProblem();
                }
                else if (problemScript.isLockProblem == true)
                {
                    problemScript.LockProblem();
                }
            }
        }
        else
        {
            Debug.Log("No item or wrong item");
            this.hasInteracted = false;
        }
    }
}


/*
 * for (int i = 0; i < 8; i++)
        {
            if (A.name == Inventory.instance.itemOnHand.name)
            {
                Debug.Log("Solved");
                if (problemScript.isGasProblem == true)
                {
                    problemScript.GasProblem();
                }
                else if (problemScript.isLockProblem == true)
                {
                    problemScript.LockProblem();
                }
            }
            else
            {
                Debug.Log("Wrong Item");
            }
        }
 * 
*/
