using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cupboard"))
        {
            Destroy(other.gameObject);
            Debug.Log("hitting shit");
        }
    }
}
