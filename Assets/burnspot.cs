using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnspot : MonoBehaviour
{
    public Animator animator;
    public GameObject bspot;
    public GameObject feetrope;
    public GameObject CamCon;
    public GameObject smoke;
    public GameObject TeleportationPads;
    public GameObject gamemanager;
    public GameObject inspectCloseButton;
   // public GameObject thingstodestroy1;
    //public GameObject thingstodestroy2;
    //public GameObject thingstodestroy3;
    // public GameObject thingstodestroy4;
    //public GameObject thingstodestroy5;
    private int Secs = 4;
   // private int appear = 1;
    public int Seconds = 2;

    void Start()
    {
        inspectCloseButton = GameObject.Find("Inspect Close Button");
        gamemanager = GameObject.Find("Game Manager");
        bspot = GameObject.Find("hitarea");
     //   smoke = GameObject.Find("Wisp");
     //   TeleportationPads = GameObject.Find("Teleportation Pads");
    // smoke.SetActive(false);
     //TeleportationPads.SetActive(false);
    }
    private void OnTriggerEnter(Collider bspot)
    {
        
        
        StartCoroutine("LoseTime");
        gamemanager.GetComponent<DisableTelepads>().Smokeanim.SetActive(true);
        //  smoke.SetActive(true);
        Debug.Log("anim");


    }
    private void OnTriggerExit(Collider bspot)
    {
        StopCoroutine("LoseTime");
        gamemanager.GetComponent<DisableTelepads>().Smokeanim.SetActive(false);
        //     smoke.SetActive(false);

        Seconds = 2;

    }
    public void stand()
    {
        
        
        
        CamCon = GameObject.Find("CameraContainer");
        feetrope = GameObject.Find("Feet&Rope");
        // CamCon.transform.position 
        
        Vector3 pos = CamCon.transform.position;

        if (Secs <= 0)
        {
            if (pos.y <= 26)
            {
                for (int i = 0; i <= 3; i++)
                {
                    pos.y += 0.01f;
                    CamCon.transform.position = pos;
                    if (inspectCloseButton.gameObject.activeInHierarchy == true)
                    {
                        inspectCloseButton.SetActive(false);
                    }
                    foreach (Transform child in Camera.main.transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    Item.isInspecting = false;
                    Inventory.instance.Remove(Inventory.instance.itemOnHand);
                }

            }
            else
            {

                // TeleportationPads.SetActive(true);
                gamemanager.GetComponent<DisableTelepads>().Telepads.SetActive(true);
                Destroy(smoke);
                // Destroy(thingstodestroy2);
                Destroy(bspot);
                Destroy(feetrope);
                Destroy(this.gameObject);
            }


        }
      //  if (Secs < -1)
        //{

        //}



    }
    public void ropebreak()
    {
        if (Seconds <= 0)
        {

            print("break");
            feetrope.GetComponent<Animator>().SetBool("break", true);
            //animator.Play("Break", 0);
        }
    }
    public void Update()
    {
        
        ropebreak();
        Debug.Log(Secs);
        stand();
        // Debug.Log(feetrope.GetComponent<Animator>().GetBool("break"));
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Secs--;
            Seconds--;
        }
    }
}
