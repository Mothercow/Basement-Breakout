using System.Collections;
using UnityEngine;

public class LockPickGameRotate : MonoBehaviour
{
    public GameObject pickPivot;
    public GameObject wrenchPivot;
    public bool isPick;
    public bool isWrench;

    public static bool resetPickPos = false;

    void Update()
    {
        //For one touch
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
            if (Physics.Raycast(ray, out Hit))
            {
                if (Hit.collider.GetComponent<LockPickGameRotate>() != null)
                {
                    if(Hit.collider.GetComponent<LockPickGameRotate>().isPick == true)
                    {
                        pickPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    }
                    if(Hit.collider.GetComponent<LockPickGameRotate>().isWrench == true)
                    {
                        if(LockPickShake.isInCorrectArea == true)
                        {
                            //Debug.Log("Rotating Wrench");
                            wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x*-1f, Space.World);
                            wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.y*-1f, Space.World);
                        }
                        else
                        {
                            LockPickShake.startShaking = true;
                            /*
                            if(this.GetComponent<LockPickShake>() != null)
                            {
                                this.GetComponent<LockPickShake>().Shake();
                            }
                            else
                            {
                                return;
                            }*/
                        }
                        
                    }
                   
                }
                else
                {
                    return;
                }

            }

        }

        //For 2 touches
        if (Input.touchCount == 2)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray ray2 = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
            RaycastHit Hit;
            RaycastHit Hit2;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
            Debug.DrawRay(ray2.origin, ray2.direction * 10, Color.blue);

            //1st touch
            if (Physics.Raycast(ray, out Hit))
            {
                if (Hit.collider.GetComponent<LockPickGameRotate>() != null)
                {
                    if (Hit.collider.GetComponent<LockPickGameRotate>().isPick == true)
                    {
                        pickPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x, Space.World);
                    }
                    if (Hit.collider.GetComponent<LockPickGameRotate>().isWrench == true)
                    {
                        if (LockPickShake.isInCorrectArea == true)
                        {
                            wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x * -1f, Space.World);
                            wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.y * -1f, Space.World);
                        }
                        else
                        {
                            LockPickShake.startShaking = true;
                        }
                    }
                    
                }
                else
                {
                    return;
                }

            }
            //2nd touch
            if (Physics.Raycast(ray2, out Hit2))
            {
                if (Hit2.collider.GetComponent<LockPickGameRotate>() != null)
                {
                    if (Hit2.collider.GetComponent<LockPickGameRotate>().isPick == true)
                    {
                        pickPivot.transform.Rotate(0f, 0f, Input.GetTouch(1).deltaPosition.x, Space.World);
                    }
                    if (Hit2.collider.GetComponent<LockPickGameRotate>().isWrench == true)
                    {
                        if (LockPickShake.isInCorrectArea == true)
                        {
                            wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.x * -1f, Space.World);
                            wrenchPivot.transform.Rotate(0f, 0f, Input.GetTouch(0).deltaPosition.y * -1f, Space.World);
                        }
                        else
                        {
                            LockPickShake.startShaking = true;
                        }
                    }
                    
                }
                else
                {
                    return;
                }

            }

        }

        //0 touches
        if (Input.touchCount == 0)
        {
            if(LockPickShake.startShaking == true)
            {
                LockPickShake.startShaking = false;
                resetPickPos = true;
                
            }
        }
    }
}
