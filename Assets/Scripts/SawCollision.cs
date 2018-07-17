using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCollision : MonoBehaviour
{
    public GameObject inspectCloseButton;
    public GameObject gasParticles;
    public GameObject hacksawAnim;
    public GameObject hacksawAnim2;
    public GameObject pipeObject;

    public static bool hasAnimationEnded = false;
    public static bool startTimer = false;
    public static bool gasStart = false;

    private float timerAnimation = 3.0f;
    private float timerAnimation2 = 3.0f;

    bool startTimer2 = false;
    bool hasAnimationEnded2 = false;

    Animator sawAnimator;
    Animator sawAnimator2;

    private void Start()
    {
        sawAnimator = hacksawAnim.GetComponent<Animator>();
        sawAnimator2 = hacksawAnim2.GetComponent<Animator>();
        hacksawAnim.SetActive(false);
        hacksawAnim2.SetActive(false);
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

        if(startTimer2 == true)
        {
            if (timerAnimation2 > 0)
            {
                timerAnimation2 -= Time.deltaTime;
            }
        }


        if (timerAnimation <= 0)
        {
            hasAnimationEnded = true;
            timerAnimation = 3.0f;
            startTimer = false;
            startTimer2 = true;
        }

        if (timerAnimation2 <= 0)
        {
            hasAnimationEnded2 = true;
            timerAnimation2 = 3.0f;
            startTimer2 = false;
        }

        if(hasAnimationEnded == true)
        {
            hacksawAnim.SetActive(false);
            hacksawAnim2.SetActive(true);
            sawAnimator2.enabled = true;
            hasAnimationEnded = false;
        }

        if(hasAnimationEnded2 == true)
        {
            hacksawAnim2.SetActive(false);
            pipeObject.GetComponent<Rigidbody>().useGravity = true;
            pipeObject.GetComponent<Collider>().isTrigger = false;
            pipeObject.GetComponent<ItemPickup>().enabled = true;
            gasParticles.SetActive(true);
            gasStart = true;
            hasAnimationEnded2 = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hacksaw"))
        {
            if (inspectCloseButton.gameObject.activeInHierarchy == true)
            {
                inspectCloseButton.SetActive(false);
            }
            foreach (Transform child in Camera.main.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Item.isInspecting = false;
            Inventory.instance.Remove(Inventory.instance.itemOnHand);
            hacksawAnim.SetActive(true);
            sawAnimator.enabled = true;
            startTimer = true;

        }
        else
        {
            return;
        }
    }

}
