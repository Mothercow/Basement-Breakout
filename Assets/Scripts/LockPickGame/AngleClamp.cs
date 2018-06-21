using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleClamp : MonoBehaviour
{
    public float minRotation;
    public float maxRotation;

    Vector3 currentRotation;

    private void Update()
    {
        
        currentRotation = transform.localRotation.eulerAngles;
        AngleLimits();
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    void AngleLimits()
    {
        if(currentRotation.y < 90 || currentRotation.y >270)
        {
            if(currentRotation.y > 180)
            {
                currentRotation.y -= 360;
            }
            if(maxRotation > 180)
            {
                maxRotation -= 360;
            }
            if(minRotation > 180)
            {
                minRotation -= 360;
            }
        }

        currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);

        if(currentRotation.y < 0)
        {
            currentRotation.y += 360;
        }
    }
}

/*
 function ClampAngle(angle: float, min: float, max: float): float {
 
     if (angle<90 || angle>270){       // if angle in the critic region...
         if (angle>180) angle -= 360;  // convert all angles to -180..+180
         if (max>180) max -= 360;
         if (min>180) min -= 360;
     }    
     angle = Mathf.Clamp(angle, min, max);
     if (angle<0) angle += 360;  // if angle negative, convert to 0..360
     return angle;
 }
     
     */
