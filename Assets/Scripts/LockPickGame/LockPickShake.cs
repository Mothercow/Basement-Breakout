using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickShake : MonoBehaviour
{
    public GameObject lockPick;
    public GameObject lockPickPivotRot;
    public GameObject wrenchPivot;
    public GameObject winScreen;
    float shakenum = 1.0f;
    public static bool startShaking = false;
    public static bool isInCorrectArea = false;

    private Vector3 startPos;

    Vector3 pickObjectRot;
    float tempRot;
    float tempWrenchRot;
    float speed = 1f;
    float amount = 1f;

    private void Start()
    {
        startPos = lockPick.transform.localRotation.eulerAngles;
        pickObjectRot = lockPick.transform.localRotation.eulerAngles;
    }

    void Update ()
    {
        
        tempRot = lockPickPivotRot.GetComponent<AngleClamp>().currentRotation.y;
        tempWrenchRot = wrenchPivot.GetComponent<AngleClamp>().currentRotation.y;
       // Debug.Log(isInCorrectArea);
      //  Debug.Log(startShaking);
       // Debug.Log(tempRot);
        //Debug.Log(startPos);

        if (tempRot > 45 && tempRot < 90 )
        {
            isInCorrectArea = true;
        }
        else
        {
            isInCorrectArea = false;
        }

        if (tempWrenchRot > 90 && tempWrenchRot < 100)
        {
            Debug.Log("Unlocked");
            winScreen.SetActive(true);
        }

        if(startShaking == true)
        {
            //Shake();
            Debug.Log("Shaking");
        }
        
        if(LockPickGameRotate.resetPickPos == true)
        {
            StopShake();
            Debug.Log("Stopping shake");
            LockPickGameRotate.resetPickPos = false;
        }

    }

    public void Shake()
    {
        //lockPick.transform.localRotation = Quaternion.Euler(pickObjectRot);
        if(shakenum<2f)
        {
            shakenum += 0.2f;
        }
        else if(shakenum >=2f)
        {
            shakenum -= 0.2f;
        }

        this.transform.localRotation = Quaternion.Euler(shakenum, shakenum,shakenum);
    }

    public void StopShake()
    {
        lockPick.transform.localRotation = Quaternion.Euler(startPos);
    }
}
