using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollision : MonoBehaviour
{
    public GameObject inspectCloseButton;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pipe"))
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = false;
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
    }
}
