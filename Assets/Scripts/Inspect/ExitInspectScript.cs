using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInspectScript : MonoBehaviour {

    public GameObject InspectButton;

    public void ExitInspect()
    {
        foreach (Transform child in Camera.main.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        InspectButton.SetActive(false);
        Item.isInspecting = false;
    }
}
