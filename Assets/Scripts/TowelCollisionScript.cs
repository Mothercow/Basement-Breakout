using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowelCollisionScript : MonoBehaviour
{
    //public bool isTowelOnAnim;
    public GameObject gasParticles;
    public GameObject inspectCloseButton;
    public GameObject towelOnAnim;

    GasDamageScript gasDamageScript;

    private void Start()
    {
        gasDamageScript = this.GetComponent<GasDamageScript>();
        towelOnAnim.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Towel") && SawCollision.gasStart == true)
        {
            towelOnAnim.SetActive(true);
            gasParticles.SetActive(false);
            gasDamageScript.gasTimer = 40.0f;
            SawCollision.gasStart = false;
            GasDamageScript.gasProblemSolved = true;
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
        }
        else
        {
            return;
        }
        
        /*
        if (isTowelOnAnim == true)
        {
            return;
        }
        else
        {
            towelOnAnim.SetActive(true);
        }
        this.gameObject.SetActive(false);
        //towelAnimator.enabled = true;
        //startTimer = true;
        //towelAnimator.SetBool("IsContactWithTowel", true);
        */
    }

}
