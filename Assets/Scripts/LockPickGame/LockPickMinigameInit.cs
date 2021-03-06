﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickMinigameInit : MonoBehaviour
{
    public GameObject lockPickGameLocation;

    public GameObject inventoryBar;
    public GameObject pauseButton;
    public GameObject resetButton;

    private GameObject CamCon;

    public static bool hasLockpick;
    public static bool hasLockpickWrench;
        
    private void Update()
    {
        if (Input.touchCount > 0 && ItemPickup.hasPaperclip == true && ItemPickup.hasPaperclip2 == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
            if (Physics.Raycast(ray, out Hit))
            {
                if(Hit.collider.GetComponent<LockPickMinigameInit>() != null&&this.GetComponent<AnimateOnClick>().lockpickgame ==true)
                {

                    Move();
                }
                else
                {
                    return;
                }
            }
        }
    }

    void Move()
    {
        inventoryBar.SetActive(false);
        pauseButton.SetActive(false);
        resetButton.SetActive(false);

        Camera.main.GetComponent<GyroController>().enabled = false;

        CamCon = GameObject.Find("CameraContainer");
        CamCon.transform.position = lockPickGameLocation.transform.position;
        Camera.main.transform.rotation = lockPickGameLocation.transform.rotation;

    }

}
