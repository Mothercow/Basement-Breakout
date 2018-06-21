using System.Collections;
using UnityEngine;

public class LockPickGameRotate : MonoBehaviour
{
    public GameObject pickPivot;
    public GameObject wrenchPivot;
    public bool isPick;
    public bool isWrench;
    //public Transform objectToBeRotated;

    void Update()
    {
        
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
            if (Physics.Raycast(ray, out Hit))
            {
                Debug.Log("Shit is happening");
                if (Hit.collider.GetComponent<LockPickGameRotate>() != null)
                {
                    if(Hit.collider.GetComponent<LockPickGameRotate>().isPick == true)
                    {
                        pickPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    }
                    if(Hit.collider.GetComponent<LockPickGameRotate>().isWrench == true)
                    {
                        wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    }
                   //objectToBeRotated.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                   //objectToBeRotated.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.y, Space.World);
                }
                else
                {
                    return;
                }

            }

        }

        
        if (Input.touchCount == 2)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray ray2 = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
            RaycastHit Hit;
            RaycastHit Hit2;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
            Debug.DrawRay(ray2.origin, ray2.direction * 10, Color.blue);


            if (Physics.Raycast(ray, out Hit))
            {
                Debug.Log("Shit is happening");
                if (Hit.collider.GetComponent<LockPickGameRotate>() != null)
                {
                    if (Hit.collider.GetComponent<LockPickGameRotate>().isPick == true)
                    {
                        Debug.Log("Tatering");
                        pickPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    }
                    if (Hit.collider.GetComponent<LockPickGameRotate>().isWrench == true)
                    {
                        Debug.Log("Tatering");
                        wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    }
                    //objectToBeRotated.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    //objectToBeRotated.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.y, Space.World);
                }
                else
                {
                    return;
                }

            }

            if (Physics.Raycast(ray2, out Hit2))
            {
                Debug.Log("Shit is happening2");
                if (Hit2.collider.GetComponent<LockPickGameRotate>() != null)
                {
                    if (Hit2.collider.GetComponent<LockPickGameRotate>().isPick == true)
                    {
                        Debug.Log("Tatering2");
                        pickPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    }
                    if (Hit2.collider.GetComponent<LockPickGameRotate>().isWrench == true)
                    {
                        Debug.Log("Tatering2");
                        wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    }
                    //objectToBeRotated.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    //objectToBeRotated.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.y, Space.World);
                }
                else
                {
                    return;
                }

            }

        }
        
    }
}
