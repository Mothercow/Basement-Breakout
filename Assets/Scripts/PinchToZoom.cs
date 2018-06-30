using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    float initDistance = 0f;
    float curDistance = 0f;
    float objDistance = 0f;
    float speed = 20f;


    // Update is called once per frame
    void Update ()
    {
        Debug.Log(objDistance);

        objDistance = Vector3.Distance(this.transform.position, Camera.main.transform.position);


        if ( Input.touchCount == 2)
        {
            //Get init distance on initial touch
            if(Input.touches[1].phase == TouchPhase.Began)
            {
                initDistance = Vector2.Distance(Input.touches[1].position, Input.touches[0].position);
            }

            //Get current distance on fingers moving
            if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
            {
                curDistance = Vector2.Distance(Input.touches[1].position, Input.touches[0].position);

                // Normalize the delta.
                // smaller curDistance means positive value
                // bigger curDistance means negative value
                float direction = curDistance / initDistance - 1f;

                if (objDistance > 1.5f || objDistance < 5f)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.transform.position, Time.deltaTime * direction * speed);
                }

                
              
            }
        
        }
        if (objDistance > 2.5f)
        {
            
            this.transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.transform.position, 0.25f);

        }
        else if (objDistance < 0.8f)
        {
            
            this.transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.transform.position, -0.25f);
        }
        
    }


    /*public void Update()
    {
        if(Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 prevTouchPosition0 = touch0.position - touch0.deltaPosition;
            Vector2 prevTouchPosition1 = touch1.position - touch1.deltaPosition;

            float touchDistance = (touch1.position - touch0.position).magnitude;
            float prevTouchDistance = (prevTouchPosition1 - prevTouchPosition1).magnitude;

            float touchChangeMultiplier = touchDistance / prevTouchDistance;

            Vector3 focalPoint = Camera.main.transform.position;
            Vector3 direction = this.transform.position - focalPoint;

            float newDistance = direction.magnitude / touchChangeMultiplier;

            this.transform.position = newDistance * direction.normalized;

            this.transform.LookAt(focalPoint);
        }
        
    }*/
}
