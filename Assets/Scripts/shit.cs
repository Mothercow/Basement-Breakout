using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shit : MonoBehaviour
{
    //public Animator animator;
    public GameObject sweetspot;
  //  public GameObject magnifyingglass;

    private void Start()
    {
        this.transform.localRotation  = Quaternion.Euler(90, 0, 0);
        sweetspot = GameObject.Find("Sweetspot");
    }

    private void OnTriggerEnter(Collider sweetspot)
    {
        //Debug.Log(this.transform.rotation.x);
        if (this.transform.rotation.x <= -0.45 && this.transform.rotation.x > -0.54)
        {

            print("magnify");
            //  animator.Play("Magnify");
            this.GetComponent<Animator>().SetBool("Magnifying", true);
           // Debug.Log("anim");
        }

    }
    private void OnTriggerExit(Collider sweetspot)
    {
        //  animator.Play("Unmagnify");
        this.GetComponent<Animator>().SetBool("Magnifying", false);
    }

}
