using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shit : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("shit");
        this.GetComponent<Animator>().SetBool("Magnifying", true);
    }
    private void OnTriggerExit(Collider other)
    {
        this.GetComponent<Animator>().SetBool("Magnifying", false);
    }
}
