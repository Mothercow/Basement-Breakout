using System.Collections;
using UnityEngine;

public class RotObject : MonoBehaviour
{
    float rotSpeed = 20;
    public float rotX;
    public float rotY;

    /*
    void Update()
    {
       
    }

    
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX, Space.World);
        transform.Rotate(Vector3.right, -rotY, Space.World);

        Debug.Log("Rotating");
    }
    */
    public Transform objectToBeRotated;
    public Transform target;
    float speed;
    void Update()
    {

        if (Input.touchCount == 1)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);
            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                objectToBeRotated.transform.Rotate(0f, -touch0.deltaPosition.x, -touch0.deltaPosition.y, Space.World);

            }

        }


    }
}
