using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnItemCameraMove : Interactable
{

    public GameObject cameraChangePos;
    public GameObject CamCon;

    private void Start()
    {
      //  FindObjectOfType<"CameraC">
    }

    public override void Interact()
    {
        Debug.Log("Camera moving is happening");
        ChangeCamPos();
        this.gameObject.GetComponent<OnItemCameraMove>().hasInteracted = false;
    }
    
    void ChangeCamPos()
    {
        Debug.Log("Changing Camera Position..");

        CamCon = GameObject.Find("CameraContainer");
        CamCon.transform.position = cameraChangePos.transform.position;

       // Camera.main.GetComponentInParent<Transform>().position = cameraChangePos.transform.position;

    }
}
