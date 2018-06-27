using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnItemCameraMove : Interactable
{

    public GameObject cameraChangePos;

    public override void Interact()
    {
        Debug.Log("Camera moving is happening");
        ChangeCamPos();
    }
    
    void ChangeCamPos()
    {
        Debug.Log("Changing Camera Position..");
        Camera.main.GetComponentInParent<Transform>().position = cameraChangePos.transform.position;

    }
}
