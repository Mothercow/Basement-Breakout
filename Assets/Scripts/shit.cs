using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shit : MonoBehaviour {

    public GameObject sweetspot;
    public GameObject magnifyingglass;

    private void OnTriggerEnter(Collider sweetspot)
    {
        Debug.Log("shit");   
        if(this.transform.rotation.x >= 0.64&& this.transform.rotation.x <0.8)
        {
            this.GetComponent<Animator>().SetBool("Magnifying", true);
            Debug.Log("anim");
        }
      
    }
    private void OnTriggerExit(Collider sweetspot)
    {
        this.GetComponent<Animator>().SetBool("Magnifying", false);
    }
    
}
