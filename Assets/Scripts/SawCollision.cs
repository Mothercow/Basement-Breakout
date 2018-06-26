using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCollision : MonoBehaviour
{
    Animator sawAnimator;
    public GameObject hacksawAnim;
    public GameObject hacksawOnAnim;

    public bool isHackSawOnAnim;

    private void Start()
    {
        hacksawAnim = GameObject.Find("hacksaw_animation");
        hacksawOnAnim = hacksawAnim.transform.Find("hacksaw001").gameObject;

        if(isHackSawOnAnim == true)
        {
            return;
        }
        else
        {
            sawAnimator = hacksawAnim.GetComponentInParent<Animator>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isHackSawOnAnim == true)
        {
            return;
        }
        else
        {
            hacksawOnAnim.SetActive(true);
        }
        this.gameObject.SetActive(false);
        sawAnimator.enabled = true;
        sawAnimator.SetBool("IsContactWithPipe", true);
        Debug.Log("stuff");
    }

}
