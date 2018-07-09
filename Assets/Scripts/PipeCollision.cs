using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollision : MonoBehaviour
{
    public GameObject inspectCloseButton;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cupboard"))
        {
            other.GetComponent<Animator>().enabled = true;
            this.gameObject.SetActive(false);
            inspectCloseButton = GameObject.Find("Inspect Close Button");
            if (inspectCloseButton.gameObject.activeInHierarchy == true)
            {
                inspectCloseButton.SetActive(false);
            }
        }
    }
}
