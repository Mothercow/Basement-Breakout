using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowelCollisionScript : MonoBehaviour
{
    public bool isTowelOnAnim;

    static GameObject towelOnAnim;

    void OnTriggerEnter(Collider other)
    {
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
    }

}
