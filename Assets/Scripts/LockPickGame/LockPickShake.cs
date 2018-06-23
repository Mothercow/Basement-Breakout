using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickShake : MonoBehaviour
{
    public GameObject lockPick;
    public GameObject lockPickPivotRot;
    public GameObject wrenchPivot;

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
        Debug.Log(isInCorrectArea);
        Debug.Log(startShaking);
        Debug.Log(startPos);

        if (tempRot > 45 && tempRot < 90 )
        {
            isInCorrectArea = true;
        }
        else
        {
            isInCorrectArea = false;
        }

        if (tempWrenchRot > 80 && tempWrenchRot <90)
        {
            Debug.Log("Unlocked");
        }

        if(startShaking == true)
        {
            Shake();
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
        pickObjectRot.y += 10f;
        lockPick.transform.localRotation = Quaternion.Euler(pickObjectRot);
    }

    public void StopShake()
    {
        lockPick.transform.localRotation = Quaternion.Euler(startPos);
    }
}
