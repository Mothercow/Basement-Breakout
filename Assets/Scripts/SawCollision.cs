using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCollision : MonoBehaviour
{
    public GameObject pipeFall;
    public GameObject inspectCloseButton;
    public GameObject gasParticles;
   
    public bool isHackSawAnim;

    public static bool hasAnimationEnded = false;
    public static bool startTimer = false;
    public static bool gasStart = false;

    static Animator sawAnimator;
    static GameObject hacksawAnim;

    private float timerAnimation = 3.0f;
    

    private void Start()
    {
        if(isHackSawAnim == true)
        {
            hacksawAnim = this.gameObject;
            sawAnimator = hacksawAnim.GetComponent<Animator>();
            hacksawAnim.SetActive(false);
        }
        
    }

    private void Update()
    {
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
            if(isHackSawAnim == true)
            {
                if(inspectCloseButton.gameObject.activeInHierarchy == true)
                {
                    inspectCloseButton.SetActive(false);
                }
                this.gameObject.SetActive(false);
                pipeFall.GetComponent<Rigidbody>().useGravity = true;
                pipeFall.GetComponent<Collider>().isTrigger = false;
                pipeFall.GetComponent<ItemPickup>().enabled = true;
                gasParticles.SetActive(true);
                gasStart = true;
            }
            else
            {
                return;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (isHackSawAnim == true)
        {
            return;
        }
        else
        {
            hacksawAnim.SetActive(true);
        }
        this.gameObject.SetActive(false);
        sawAnimator.enabled = true;
        startTimer = true;
        //sawAnimator.SetBool("IsContactWithPipe", true);
        //Debug.Log("stuff");
    }

}
