using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickShake : MonoBehaviour
{
    public GameObject lockPick;
    public Transform lockPickPivot;

    Transform tempLockPickPos;
    float speed = 1.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes

    private void Start()
    {
        tempLockPickPos.position = lockPick.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if(lockPickPivot.rotation.y > 0 || lockPickPivot.rotation.y < 30 )
        {
            //tempLockPickPos.position.x = Mathf.Sin(Time.time * speed) * amount;
        }

       //transform.position.x = Mathf.Sin(Time.time * speed) * amount;
    }
}
