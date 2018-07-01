using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCollision : MonoBehaviour
{
    Animator sawAnimator;
    public GameObject hacksawAnim;
    public GameObject hacksawOnAnim;
    public GameObject pipeFall;
    public GameObject inspectCloseButton;

    public bool isHackSawOnAnim;

    public static bool hasAnimationEnded = false;
    public static bool startTimer = false;

    private float timerAnimation = 3.0f;
    

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

    private void Update()
    {
       // Debug.Log(hasAnimationEnded);
        //Debug.Log(timerAnimation);
//Debug.Log(startTimer);


        if(startTimer == true)
        {
            if (timerAnimation > 0)
            {
                timerAnimation -= Time.deltaTime;
            }
        }
        if (timerAnimation <= 0)
        {
            hasAnimationEnded = true;
        }

        if(hasAnimationEnded == true)
        {
            if(isHackSawOnAnim == true)
            {
                if(inspectCloseButton.gameObject.activeInHierarchy == true)
                {
                    inspectCloseButton.SetActive(false);
                }
                this.gameObject.SetActive(false);
                pipeFall.GetComponent<Rigidbody>().useGravity = true;
                pipeFall.GetComponent<Collider>().isTrigger = false;
                pipeFall.GetComponent<ItemPickup>().enabled = true;
            }
            else
            {
                return;
            }
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
        startTimer = true;
        sawAnimator.SetBool("IsContactWithPipe", true);
        Debug.Log("stuff");
    }

}
