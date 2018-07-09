using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCollision : MonoBehaviour
{
    public GameObject inspectCloseButton;
    public GameObject gasParticles;
    public GameObject hacksawAnim;

    public static bool hasAnimationEnded = false;
    public static bool startTimer = false;
    public static bool gasStart = false;

    private float timerAnimation = 3.0f;

    Animator sawAnimator;

    private void Start()
    {
        sawAnimator = hacksawAnim.GetComponent<Animator>();
        hacksawAnim.SetActive(false);
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
            Inventory.instance.Remove(Inventory.instance.itemOnHand);
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Collider>().isTrigger = false;
            this.GetComponent<ItemPickup>().enabled = true;
            hacksawAnim.SetActive(false);
            gasParticles.SetActive(true);
            gasStart = true;
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
            hacksawAnim.SetActive(true);
            sawAnimator.enabled = true;
            startTimer = true;
            //sawAnimator.SetBool("IsContactWithPipe", true);
            //Debug.Log("stuff");
        }
        else
        {
            return;
        }
    }

}
