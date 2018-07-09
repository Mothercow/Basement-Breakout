using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnspot: MonoBehaviour
{

    public GameObject sweetspot;
    public GameObject feetrope;
    public int Seconds = 2;


    private void OnTriggerEnter(Collider sweetspot)
    {
        
            
        StartCoroutine("LoseTime");
        Debug.Log("anim");
       

    }
    private void OnTriggerExit(Collider sweetspot)
    {
        StopCoroutine("LoseTime");
        
        Seconds = 2;

    }

    public void ropebreak()
    {
        if(Seconds <= 0)
        {
            Debug.Log("Broke");
            feetrope.GetComponent<Animator>().SetBool("break", true);
        }
    }
    public void Update()
    {
        ropebreak();
       // Debug.Log(feetrope.GetComponent<Animator>().GetBool("break"));
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Seconds--;
        }
    }
}
