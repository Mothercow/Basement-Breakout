using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingProblem : MonoBehaviour {

    
    void OnCollisionStay(Collision Collision)
    {
        
        Debug.Log("triggering");
      //  this.GetComponent<Animator>().SetBool("Magnifying", true);
    }
}
